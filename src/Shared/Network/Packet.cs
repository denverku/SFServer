using Shared.Util.Log.Factories;
using Shared.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;


namespace Shared.Network
{
    public class Packet
    {
        private List<byte> buffer;
        public byte[] readableBuffer;
        private int readPos;
        private int writePos = 6;
        public int protocolID = 0;
        
        public Packet()
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 8; // Set readPos to 0
        }

        
        public Packet(int _id)
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 8; // Set readPos to 0
            //WriteInt(_id);
            buffer.Add(0x44);
            buffer.Add(0x46);
            buffer.Add((byte)(0));
            buffer.Add((byte)(0));
            buffer.Add((byte)(_id));

        }
        
        public Packet(byte[] _data)
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 8; // Set readPos to 0
            SetBytes(_data);
        }

        public void Dump()
        {
            Console.WriteLine(NetworkUtil.DumpPacket(ToArray(), ToArray().Length));
            //LogFactory.GetLog(name).LogInfo($"dumping packet proto {packet.protocolID}.");
            // LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
        }

        #region Functions
        
        public void SetBytes(byte[] _data)
        {
            Write(_data);
            readableBuffer = buffer.ToArray();
            //byte[] head = new byte[] { readableBuffer[6], readableBuffer[7] };
            protocolID = GetProtocolID(readableBuffer);
            //protocolID = BitConverter.ToUInt16(readableBuffer, 6) + BitConverter.ToUInt16(readableBuffer, 7);
            //byte[] opcode1 = new byte[] { readableBuffer[6], readableBuffer[7] };
            //UInt16 opcode = BitConverter.ToUInt16(opcode1, 0);
        }

        private int GetProtocolID(byte[] readableBuffer)
        {
            int protocolID = 0;

            // Check if the buffer has enough data to read protocolID
            try
            {
                if (readableBuffer.Length >= 8)
                {
                    // Extract bytes from positions 6 and 7 and combine them to get protocolID
                    protocolID  = (readableBuffer[7] << 8) | readableBuffer[6];
                }
                else
                {
                    // Handle the case when buffer size is smaller than expected
                    // You can log a warning or take appropriate action here
                    protocolID = BitConverter.ToUInt16(readableBuffer, 6);
                }
            }catch(Exception e)
            {
                protocolID = BitConverter.ToUInt16(readableBuffer, 6);
            }

            return protocolID;
        }


        public void WriteLength()
        {
            buffer.InsertRange(2, BitConverter.GetBytes(buffer.Count - 4)); // Insert the byte length of the packet at the very beginning
        }

        
        public void InsertInt(int _value)
        {
            buffer.InsertRange(0, BitConverter.GetBytes(_value)); // Insert the int at the start of the buffer
        }

        
        public byte[] ToArray()
        {
            readableBuffer = buffer.ToArray();
            return readableBuffer;
        }

        
        public int Length()
        {
            return buffer.Count; // Return the length of buffer
        }

        public int UnreadLength()
        {
            return Length() - readPos; // Return the remaining length (unread)
        }

        
        public void Reset(bool _shouldReset = true)
        {
            if (_shouldReset)
            {
                buffer.Clear(); // Clear buffer
                readableBuffer = null;
                readPos = 8; // Reset readPos
            }
            else
            {
                readPos -= 4; // "Unread" the last read int
            }
        }
        #endregion

        public void Write(byte[] _value)
        {
            buffer.AddRange(_value);
        }

        public void WriteByte(byte _value)
        {
            buffer.Add(_value);
        }

        public void WriteShort(short _value)
        {
            byte leastSignificantByte = (byte)(_value & 0xFF);
            buffer.Add(leastSignificantByte);
            //buffer.Add(Convert.ToByte(_value));
            //buffer.AddRange(BitConverter.GetBytes(_value));
        }

        /*public void WriteInt(int _value)
        {
            byte leastSignificantByte = (byte)(_value & 0xFF);
            buffer.Add(leastSignificantByte);
            //buffer.Add(Convert.ToByte(_value));
            //buffer.AddRange(BitConverter.GetBytes(_value));
        }*/
        public void WriteInt(int value)
        {
            buffer.Add((byte)(value));
            //byte[] bytes = BitConverter.GetBytes(value);
            //buffer.AddRange(bytes);
        }

        public void WriteBool(bool _value)
        {
            //buffer.AddRange(BitConverter.GetBytes(_value));
            buffer.Add(_value == true ? (byte)1 : (byte)0);
        }

        public void WriteString(string _value)
        {
            //WriteInt(_value.Length); // Add the length of the string to the packet
            //buffer.AddRange(Encoding.ASCII.GetBytes(_value)); // Add the string itself
            byte[] argEncoded = System.Text.Encoding.Default.GetBytes(_value);
            buffer.AddRange(argEncoded);
            //buffer.Add((byte)(_value.Length));
        }


        #region Read Data
        /// <summary>Reads a byte from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public byte ReadByte(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                byte _value = readableBuffer[readPos]; // Get the byte at readPos' position
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += 1; // Increase readPos by 1
                }
                return _value; // Return the byte
            }
            else
            {
                throw new Exception("Could not read value of type 'byte'!");
            }
        }

        /// <summary>Reads an array of bytes from the packet.</summary>
        /// <param name="_length">The length of the byte array.</param>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public byte[] ReadBytes(int _length, bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                byte[] _value = buffer.GetRange(readPos, _length).ToArray(); // Get the bytes at readPos' position with a range of _length
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += _length; // Increase readPos by _length
                }
                return _value; // Return the bytes
            }
            else
            {
                throw new Exception("Could not read value of type 'byte[]'!");
            }
        }

        /// <summary>Reads a short from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public short ReadShort(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                short _value = BitConverter.ToInt16(readableBuffer, readPos); // Convert the bytes to a short
                if (_moveReadPos)
                {
                    // If _moveReadPos is true and there are unread bytes
                    readPos += 2; // Increase readPos by 2
                }
                return _value; // Return the short
            }
            else
            {
                throw new Exception("Could not read value of type 'short'!");
            }
        }

        /// <summary>Reads an int from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public int ReadInt(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                int _value = BitConverter.ToInt32(readableBuffer, readPos); // Convert the bytes to an int
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += 2; // Increase readPos by 4
                }
                return _value; // Return the int
            }
            else
            {
                throw new Exception("Could not read value of type 'int'!");
            }
        }

        /// <summary>Reads a long from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public long ReadLong(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                long _value = BitConverter.ToInt64(readableBuffer, readPos); // Convert the bytes to a long
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += 4; // Increase readPos by 8
                }
                return _value; // Return the long
            }
            else
            {
                throw new Exception("Could not read value of type 'long'!");
            }
        }

        /// <summary>Reads a float from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public float ReadFloat(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                float _value = BitConverter.ToSingle(readableBuffer, readPos); // Convert the bytes to a float
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += 4; // Increase readPos by 4
                }
                return _value; // Return the float
            }
            else
            {
                throw new Exception("Could not read value of type 'float'!");
            }
        }

        /// <summary>Reads a bool from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public bool ReadBool(bool _moveReadPos = true)
        {
            if (buffer.Count > readPos)
            {
                // If there are unread bytes
                bool _value = BitConverter.ToBoolean(readableBuffer, readPos); // Convert the bytes to a bool
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += 1; // Increase readPos by 1
                }
                return _value; // Return the bool
            }
            else
            {
                throw new Exception("Could not read value of type 'bool'!");
            }
        }

        /// <summary>Reads a string from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public string ReadString(bool _moveReadPos = true)
        {
            try
            {

                int _length = readPos + 1; // Get the length of the string
                string _value = Encoding.ASCII.GetString(readableBuffer, readPos, _length); // Convert the bytes to a string
                if (_moveReadPos && _value.Length > 0)
                {
                    // If _moveReadPos is true string is not empty
                    readPos += _length + 1; // Increase readPos by the length of the string
                }
                return _value; // Return the string
            }
            catch
            {
                throw new Exception("Could not read value of type 'string'!");
            }
        }

        #endregion

    }
}
