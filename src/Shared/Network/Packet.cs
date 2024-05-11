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
using System.Reflection;


namespace Shared.Network
{
    public class Packet
    {
        public byte[] readableBuffer = new byte[64];
        private int readPos;
        private int writePos = 6;
        public int protocolID = 0;
        /// <summary>Creates a new empty packet (without an ID).</summary>
        public Packet()
        {
            readPos = 6; // Set readPos to 0
            writePos = 6;
        }

        /// <summary>Creates a new packet with a given ID. Used for sending.</summary>
        /// <param name="_id">The packet ID.</param>
        public Packet(int id)
        {
            readPos = 6; // Set readPos to 0
            writePos = 6;
            readableBuffer[4] = Convert.ToByte(id);


        }

        public Packet(byte id)
        {
            readPos = 6; // Set readPos to 0
            writePos = 6;
            readableBuffer[4] = id;


        }



        /// <summary>Creates a packet from which data can be read. Used for receiving.</summary>
        /// <param name="_data">The bytes to add to the packet.</param>
        public Packet(byte[] _data)
        {
            readPos = 6; // Set readPos to 0
            writePos = 6;
            SetBytes(_data);
        }

        public void Dump()
        {
            Console.WriteLine(NetworkUtil.DumpPacket(readableBuffer, readableBuffer.Length));
            //LogFactory.GetLog(name).LogInfo($"dumping packet proto {packet.protocolID}.");
           // LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
        }

        #region Functions
        /// <summary>Sets the packet's content and prepares it to be read.</summary>
        /// <param name="_data">The bytes to add to the packet.</param>
        public void SetBytes(byte[] _data)
        {

            readableBuffer = _data;
            protocolID = BitConverter.ToUInt16(readableBuffer, 4);
        }


        /// <summary>Gets the packet's content in array form.</summary>
        public byte[] ToArray()
        {
            return readableBuffer;
        }

        /// <summary>Gets the length of the packet's content.</summary>
        public int Length()
        {
            return readableBuffer.Length ; // Return the length of buffer
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
                readableBuffer = null;
                readPos = 6; // Reset readPos
                writePos = 6;
            }
            else
            {
                readPos -= 4; // "Unread" the last read int
            }
        }
        #endregion




        #region Write Data
        private void EnsureCapacity(int index)
        {
            if (index >= readableBuffer.Length)
            {
                Array.Resize(ref readableBuffer, index + 1);
            }
        }

        
        /*public void Write(byte _value)
        {
            //buffer.Add(_value);
        }*/
        
        public void Write(short _value)
        {
            //buffer.AddRange(BitConverter.GetBytes(_value));
        }
       
        public void Write(int value)
        {
            //buffer.AddRange(BitConverter.GetBytes(_value));
            EnsureCapacity(writePos + 2);
            byte[] intBytes = BitConverter.GetBytes(value);
            Array.Copy(intBytes, 0, readableBuffer, writePos, 2);
            writePos += 2;
        }
        

        /*public void Write(long _value)
        {
            //buffer.AddRange(BitConverter.GetBytes(_value));
        }*/
        
        public void Write(float _value)
        {
            //buffer.AddRange(BitConverter.GetBytes(_value));
        }
        
        public void Write(bool _value)
        {
            //buffer.AddRange(BitConverter.GetBytes(_value));
        }
        
        public void Write(string value)
        {
            //Write(_value.Length); // Add the length of the string to the packet
            //buffer.AddRange(Encoding.ASCII.GetBytes(_value)); // Add the string itself
            EnsureCapacity(writePos + value.Length);
            byte[] stringBytes = System.Text.Encoding.ASCII.GetBytes(value);
            Array.Copy(stringBytes, 0, readableBuffer, writePos, stringBytes.Length);

        }
       
        #endregion

        #region Read Data
        /// <summary>Reads a byte from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public byte ReadByte(bool _moveReadPos = true)
        {
            if (readableBuffer.Length > readPos)
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
        /*public byte[] ReadBytes(int _length, bool _moveReadPos = true)
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
        }*/

        /// <summary>Reads a short from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public short ReadShort(bool _moveReadPos = true)
        {
            if (readableBuffer.Length > readPos)
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
            if (readableBuffer.Length > readPos)
            {
                // If there are unread bytes
                int _value = BitConverter.ToInt32(readableBuffer, readPos); // Convert the bytes to an int
                if (_moveReadPos)
                {
                    // If _moveReadPos is true
                    readPos += 4; // Increase readPos by 4
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
        /*public long ReadLong(bool _moveReadPos = true)
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
        }*/

        /// <summary>Reads a float from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        /*public float ReadFloat(bool _moveReadPos = true)
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
        */
        /// <summary>Reads a bool from the packet.</summary>
        /// <param name="_moveReadPos">Whether or not to move the buffer's read position.</param>
        public bool ReadBool(bool _moveReadPos = true)
        {
            if (readableBuffer.Length > readPos)
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
