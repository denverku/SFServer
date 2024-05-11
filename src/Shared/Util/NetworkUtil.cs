using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Shared.Util {
    public class NetworkUtil {
        public static string MacPattern = "%02X%s";

        public static string ParseMac(byte[] mac) {
            var result = "";
            for (var k = 0; k < mac.Length; k++)
                result += string.Format(MacPattern, mac[k], k < mac.Length - 1 ? ":" : "");
            return result;
        }

        public static byte[] StringToBytes(string str, int BufferLength = 0, bool endsWithF2 = false) {
            if (BufferLength != 0) {
                var result = str.Split(new[] {' '});
                var temp = new List<byte>();
                for (var i = 0; i < result.Length; i++) temp.Add(byte.Parse(result[i], NumberStyles.HexNumber));
                var oldCount = temp.Count;
                for (var i = 0; i < BufferLength - oldCount; i++) temp.Add(0);
                if (endsWithF2)
                    temp.ToArray()[temp.ToArray().Length - 1] = 0xF2;
                return temp.ToArray();
            } else {
                var result = str.Split(new[] {' '});
                var temp = new List<byte>();
                for (var i = 0; i < result.Length; i++) temp.Add(byte.Parse(result[i], NumberStyles.HexNumber));
                return temp.ToArray();
            }
        }

        /*public static byte[] StringToBytes(string str, int BufferLength = 0, bool endsWithF2 = false)
        {
            if (BufferLength != 0)
            {
                string[] result = str.Split(new char[] { ' ' });
                List<byte> temp = new List<byte>();
                for (int i = 0; i < result.Length; i++)
                {
                    temp.Add(byte.Parse((result[i]), System.Globalization.NumberStyles.HexNumber));
                }
                int oldCount = temp.Count;
                for (int i = 0; i < (BufferLength - oldCount); i++)
                {
                    temp.Add((byte)(0));
                }
                if (endsWithF2)
                    temp.ToArray()[temp.ToArray().Length - 1] = 0xF2;
                return temp.ToArray();
            }
            else
            {
                string[] result = str.Split(new char[] { ' ' });
                List<byte> temp = new List<byte>(1024);
                for (int i = 0; i < result.Length; i++)
                {
                    temp.Add(byte.Parse((result[i]), System.Globalization.NumberStyles.HexNumber));
                }
                return temp.ToArray();
            }
        }*/

        public static string BytesToString(byte[] buffer) {
            var builder = new StringBuilder();
            foreach (var b in buffer) {
                builder.Append(b.ToString("X2"));
                builder.Append(" ");
            }

            return builder.Remove(builder.Length - 1, 1).ToString();
        }

        /*public static string DumpPacket(byte[] packet) {
            var DataStr = "";
            var PacketLength = (ushort) packet.Length;
            for (var i = 0; i < Math.Ceiling((double) PacketLength / 16); i++) {
                var t = 16;
                if ((i + 1) * 16 > PacketLength)
                    t = PacketLength - i * 16;
                for (var a = 0; a < t; a++) DataStr += packet[i * 16 + a].ToString("X2") + " ";
                if (t < 16)
                    for (var a = t; a < 16; a++)
                        DataStr += "   ";
                DataStr += "   ; ";

                for (var a = 0; a < t; a++) DataStr += Convert.ToChar(packet[i * 16 + a]);
                DataStr += Environment.NewLine;
            }
            // 4 - dps do nome pra dai ter o id do user
            return DataStr.Replace(Convert.ToChar(0), '.').ToUpper();
        }*/

        /*public static string DumpPacket(byte[] packet, int byteRead)
        {
            var DataStr = "begin raw\n";
            DataStr += Environment.NewLine;
            var PacketLength = (ushort)byteRead;
            for (var i = 0; i < Math.Ceiling((double)PacketLength / 16); i++)
            {
                var t = 16;
                if ((i + 1) * 16 > PacketLength)
                    t = PacketLength - i * 16;
                for (var a = 0; a < t; a++) DataStr += packet[i * 16 + a].ToString("X2") + " ";
                if (t < 16)
                    for (var a = t; a < 16; a++)
                        DataStr += "   ";
                DataStr += "   ; ";

                for (var a = 0; a < t; a++) DataStr += Convert.ToChar(packet[i * 16 + a]);
                DataStr += Environment.NewLine;
            }
            DataStr += Environment.NewLine;
            DataStr += "end raw";
            // 4 - dps do nome pra dai ter o id do user
            return DataStr.Replace(Convert.ToChar(0), '.');
            //return DataStr.Replace(Convert.ToChar(0), '.').ToUpper();
        }*/

        public static string DumpPacket(byte[] packet, int byteRead)
        {
            var DataStr = "begin raw\n";
            DataStr += Environment.NewLine;
            var PacketLength = (ushort)byteRead;
            for (var i = 0; i < Math.Ceiling((double)PacketLength / 16); i++)
            {
                var offset = i * 16;
                var t = Math.Min(16, PacketLength - offset);

                // Offset
                DataStr += offset.ToString("X8") + "      ";

                // Hexadecimal representation
                for (var a = 0; a < t; a++)
                    DataStr += packet[offset + a].ToString("X2") + " ";

                // Padding for alignment
                if (t < 20)
                    for (var a = t; a < 20; a++)
                        DataStr += "   ";

                // ASCII representation
                DataStr += "       ";
                for (var a = 0; a < t; a++)
                {
                    var asciiChar = Convert.ToChar(packet[offset + a]);
                    if (char.IsControl(asciiChar))
                        DataStr += ".";
                    else
                        DataStr += asciiChar;
                }
                DataStr += Environment.NewLine;
            }
            DataStr += Environment.NewLine;
            DataStr += "end raw";
            return DataStr;
        }



       /* public static string DumpPacket(byte[] packet)
        {
            var DataStr = new StringBuilder();
            var PacketLength = (ushort)packet.Length;

            const int BytesPerLine = 16;

            for (var i = 0; i < Math.Ceiling((double)PacketLength / BytesPerLine); i++)
            {
                var bytesRemaining = PacketLength - i * BytesPerLine;
                var bytesThisLine = Math.Min(BytesPerLine, bytesRemaining);

                for (var a = 0; a < bytesThisLine; a++)
                {
                    DataStr.Append(packet[i * BytesPerLine + a].ToString("X2")).Append(" ");
                }

                if (bytesThisLine < BytesPerLine)
                {
                    for (var a = bytesThisLine; a < BytesPerLine; a++)
                    {
                        DataStr.Append("   ");
                    }
                }

                DataStr.Append("   ; ");

                for (var a = 0; a < bytesThisLine; a++)
                {
                    DataStr.Append(Convert.ToChar(packet[i * BytesPerLine + a]));
                }

                DataStr.AppendLine();
            }

            return DataStr.Replace(Convert.ToChar(0), '.').ToString().ToUpper();
        }*/


        public static List<IncorrectByte> ComparePacket(byte[] packet, string target)
        {
            string[] packetPieces = BytesToString(packet).Split(" ");
            string[] targetPieces = target.Split(" ");
            List<IncorrectByte> diff = new List<IncorrectByte>();
            for (int i = 0; i < targetPieces.Length; i++)
            {
                if (!packetPieces[i].ToLower().Equals(targetPieces[i]))
                {
                    diff.Add(new IncorrectByte { pos = i, original = targetPieces[i], result = packetPieces[i] });
                }
            }
            return diff;
        }

        public static List<IncorrectByte> ComparePacket(byte[] packet, byte[] target)
        {
            return ComparePacket(packet, BytesToString(target));
        }
    }

    public class IncorrectByte
    {
        public int pos;
        public string original;
        public string result;
    }
}