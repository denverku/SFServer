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
    public class Packet : IDisposable
    {
        private List<byte> buffer;
        public byte[] readableBuffer;
        private int readPos;
        private int writePos = 6;
        public int protocolID = 0;
        /// <summary>Creates a new empty packet (without an ID).</summary>
        public Packet()
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 6; // Set readPos to 0
        }

        /// <summary>Creates a new packet with a given ID. Used for sending.</summary>
        /// <param name="_id">The packet ID.</param>
        public Packet(int _id)
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 6; // Set readPos to 0
                         // Write(_id); // Write packet id to the buffer
                         //Array.Clear(buffer, 0, buffer.Length);
                         //BitConverter.GetBytes(protocolID).CopyTo(buffer, 4);
            /*for (int i = 0; i < readPos; i++)
            {
                if (i == 4)
                {

                    //buffer.AddRange(BitConverter.GetBytes(_id));
                    buffer.Add(Convert.ToByte(_id));
                }
                else
                {
                    // buffer.Add(0x00);
                    buffer.Add(Convert.ToByte(0));
                }
            }*/
            //WriteProtocol(Convert.ToByte(_id));
            //buffer.AddRange(new byte[7]);

        }

        public Packet(byte id)
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 6; // Set readPos to 0
                         // Write(_id); // Write packet id to the buffer
                         //Array.Clear(buffer, 0, buffer.Length);
                         //BitConverter.GetBytes(protocolID).CopyTo(buffer, 4);
            /*for (int i = 0; i < readPos; i++)
            {
                if (i == 4)
                {

                    //buffer.AddRange(BitConverter.GetBytes(_id));
                    buffer.Add(id);
                }
                else
                {
                    // buffer.Add(0x00);
                    buffer.Add(Convert.ToByte(0));
                }
            }*/
            //buffer.AddRange(new byte[7]);
            
        }

        /// <summary>Creates a packet from which data can be read. Used for receiving.</summary>
        /// <param name="_data">The bytes to add to the packet.</param>
        public Packet(byte[] _data)
        {
            buffer = new List<byte>(); // Initialize buffer
            readPos = 6; // Set readPos to 0

            SetBytes(_data);
        }

        public void Dump()
        {
            Console.WriteLine(NetworkUtil.DumpPacket(ToArray(), ToArray().Length));
            //LogFactory.GetLog(name).LogInfo($"dumping packet proto {packet.protocolID}.");
            // LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
        }

        #region Functions
        /// <summary>Sets the packet's content and prepares it to be read.</summary>
        /// <param name="_data">The bytes to add to the packet.</param>
        public void SetBytes(byte[] _data)
        {
            Write(_data);
            readableBuffer = buffer.ToArray();
            protocolID = BitConverter.ToUInt16(readableBuffer, 4);
        }

        /// <summary>Inserts the length of the packet's content at the start of the buffer.</summary>
        public void WriteLength()
        {
            buffer.InsertRange(0, BitConverter.GetBytes(buffer.Count)); // Insert the byte length of the packet at the very beginning
        }

        /// <summary>Inserts the given int at the start of the buffer.</summary>
        /// <param name="_value">The int to insert.</param>
        public void InsertInt(int _value)
        {
            buffer.InsertRange(0, BitConverter.GetBytes(_value)); // Insert the int at the start of the buffer
        }

        /// <summary>Gets the packet's content in array form.</summary>
        public byte[] ToArray()
        {
            readableBuffer = buffer.ToArray();
            return readableBuffer;
        }

        /// <summary>Gets the length of the packet's content.</summary>
        public int Length()
        {
            return buffer.Count; // Return the length of buffer
        }

        /// <summary>Gets the length of the unread data contained in the packet.</summary>
        public int UnreadLength()
        {
            return Length() - readPos; // Return the remaining length (unread)
        }

        /// <summary>Resets the packet instance to allow it to be reused.</summary>
        /// <param name="_shouldReset">Whether or not to reset the packet.</param>
        public void Reset(bool _shouldReset = true)
        {
            if (_shouldReset)
            {
                buffer.Clear(); // Clear buffer
                readableBuffer = null;
                readPos = 6; // Reset readPos
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

        public void WriteProtocol(ushort protocolID)
        {
            EnsureCapacity(6); // Ensure buffer has at least 6 elements
            WriteUShort(protocolID, 4); // Write protocol at index 4
        }

        public void WriteByte(byte value)
        {
            EnsureCapacity(writePos + 1); // Ensure buffer has enough capacity
            buffer[writePos] = value;
            writePos++;
        }

        public void WriteShort(short value)
        {
            EnsureCapacity(writePos + 2); // Ensure buffer has enough capacity
            buffer[writePos] = (byte)(value & 0xFF);
            buffer[writePos + 1] = (byte)((value >> 8) & 0xFF);
            writePos += 2;
        }

        public void WriteInt(int value)
        {
            EnsureCapacity(writePos + 4); // Ensure buffer has enough capacity
            buffer[writePos] = (byte)(value & 0xFF);
            buffer[writePos + 1] = (byte)((value >> 8) & 0xFF);
            buffer[writePos + 2] = (byte)((value >> 16) & 0xFF);
            buffer[writePos + 3] = (byte)((value >> 24) & 0xFF);
            writePos += 4;
        }

        public void WriteString(string value)
        {
            byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(value);
            WriteShort((short)stringBytes.Length);
            EnsureCapacity(writePos + stringBytes.Length); // Ensure buffer has enough capacity
            Array.Copy(stringBytes, 0, buffer.ToArray(), writePos, stringBytes.Length);
            writePos += stringBytes.Length;
        }

        private void WriteUShort(ushort value, int index)
        {
            EnsureCapacity(index + 2); // Ensure buffer has enough capacity
            buffer[index] = (byte)(value & 0xFF);
            buffer[index + 1] = (byte)((value >> 8) & 0xFF);
        }

        private void EnsureCapacity(int requiredCapacity)
        {
            if (buffer.Count < requiredCapacity)
            {
                int additionalCapacity = requiredCapacity - buffer.Count;
                buffer.AddRange(new byte[additionalCapacity]);
            }
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

        private bool disposed = false;

        protected virtual void Dispose(bool _disposing)
        {
            if (!disposed)
            {
                if (_disposing)
                {
                    buffer = null;
                    readableBuffer = null;
                    readPos = 0;
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
