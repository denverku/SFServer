using Shared;
using Shared.Util.Log.Factories;
using Shared.Util;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace Login
{
    internal class LauncherServerSession : Client
    {
        public LauncherServerSession(string[] args) : base(args)
        {
            name = "Launcher Session Client";
            port = 37240;
        }

        public override void OnConnected(Socket socket)
        {
        }

        public override void OnReceive(byte[] buff, int bytesRead)
        {
            try
            {
                int protocolID = BitConverter.ToUInt16(buff, 4);
                ushort test = BitConverter.ToUInt16(buff, 6);
                //LogFactory.GetLog(name).LogInfo($"dumping packet proto {protocolID}.");
               // LogFactory.GetLog(name).LogInfo($"dumping data {test}.");
               // LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
                switch (protocolID)
                {
                    case 1: // 
                        Send(new byte[] { 0x26, 0x00, 0x00, 0x00, 0x28, 0x23, 0x50, 0xc3,
0x00, 0x00, 0x39, 0x62, 0x64, 0x33, 0x39, 0x62,
0x38, 0x35, 0x66, 0x64, 0x64, 0x63, 0x31, 0x33,
0x65, 0x62, 0x66, 0x34, 0x39, 0x63, 0x31, 0x33,
0x62, 0x37, 0x31, 0x38, 0x61, 0x32, 0x32, 0x64,
0x61, 0x34, 0x00, 0x01 });
                        return;
  
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
