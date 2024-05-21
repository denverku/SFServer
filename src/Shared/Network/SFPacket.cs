using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Network
{
    public class SFPacket
    {
        public byte[] Buffer { get; set; }
        public int ReceivedSize { get; set; }
        public int ProtocolId { get; set; }
        public int DataSize { get; set; }
        public int ReadPosition { get; set; }
        public int WritePosition { get; set; }

        public SFPacket()
        {
            Buffer = new byte[1024]; // adjust buffer size as needed
            ReceivedSize = 0;
            ProtocolId = 0;
            DataSize = 0;
            ReadPosition = 0;
            WritePosition = 0;
        }

        public SFPacket(int protocolId)
        {
            Buffer = new byte[1024]; // adjust buffer size as needed
            ReceivedSize = 0;
            ProtocolId = protocolId;
            DataSize = 0;
            ReadPosition = 0;
            WritePosition = 0;
        }

        public bool IsValidPacket()
        {
            return ReceivedSize >= 6 && ReceivedSize >= DataSize + 6;
        }

        public void CopyToBuffer(byte[] buffer, int size)
        {
            Array.Copy(buffer, 0, Buffer, 0, size);
            ReceivedSize = size;
        }

        public void ReadData(string destination, int size)
        {
            if (ReadPosition + size > Buffer.Length || ReadPosition + size > DataSize + 6)
            {
                throw new Exception("Invalid read operation");
            }
            destination = Encoding.ASCII.GetString(Buffer, ReadPosition, size);
            ReadPosition += size;
        }

        public void ReadData(byte[] buffer, int size)
        {
            if (ReadPosition + size > Buffer.Length || ReadPosition + size > DataSize + 6)
            {
                throw new Exception("Invalid read operation");
            }
            Array.Copy(Buffer, ReadPosition, buffer, 0, size);
            ReadPosition += size;
        }

        /*public void WriteData(byte[] buffer, int size)
        {
            if (WritePosition + size > Buffer.Length)
            {
                throw new Exception("Invalid write operation");
            }
            Array.Copy(buffer, 0, Buffer, WritePosition, size);
            WritePosition += size;
            ReceivedSize += size;
            DataSize += size;
        }*/
        public void WriteData(byte[] buffer, int size)
        {
            if (WritePosition + size > Buffer.Length)
            {
                int newSize = Buffer.Length;
                while (newSize < WritePosition + size)
                {
                    newSize *= 2;
                }
                byte[] newBuffer = new byte[newSize];
                Array.Copy(Buffer, 0, newBuffer, 0, Buffer.Length);
                Buffer = newBuffer;
            }
            Array.Copy(buffer, 0, Buffer, WritePosition, size);
            WritePosition += size;
            ReceivedSize += size;
            DataSize += size;
        }

        public void WriteString(string source)
        {
            WriteData(Encoding.ASCII.GetBytes(source), source.Length + 1);
            
        }

        public void WriteInt(int source)
        {
            WriteData(BitConverter.GetBytes(source), 4);
            
        }

        public void WriteShort(short source)
        {
            WriteData(BitConverter.GetBytes(source), 2);
           
        }

        public void WriteByte(byte source)
        {
            WriteData(new byte[] { source }, 1);
            
        }

        public string ReadString()
        {
            string destination = "";
            int size = BitConverter.ToInt32(Buffer, ReadPosition);
            ReadData(destination, size + 1);
            return destination;
        }

        public byte ReadByte()
        {
            byte destination = new byte();
            //ReadData(destination, 1);
            return destination;
        }

        /*public Packet operator >>(ref int destination)
        {
            ReadData(destination, 4);
            return this;
        }

        public Packet operator >>(ref short destination)
        {
            ReadData(destination, 2);
            return this;
        }*/
    }
}
