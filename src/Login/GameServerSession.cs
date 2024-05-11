using Shared;
using Shared.Util.Log.Factories;
using Shared.Util;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Shared.Network;

namespace Login
{
    internal class GameServerSession : Client
    {
        public GameServerSession(string[] args) : base(args)
        {
            name = "GameServer Session Client";
            port = 28963;
        }

        public override void OnConnected(Socket socket)
        {

        }

        public override void OnReceive(byte[] buff, int bytesRead)
        {
            try
            {
                Packet packet  = new Packet(buff);
                
                int protocolID = BitConverter.ToUInt16(buff, 4);
                //ushort test = BitConverter.ToUInt16(buff, 6);
                LogFactory.GetLog(name).LogInfo($"dumping packet proto {protocolID}.");
               // LogFactory.GetLog(name).LogInfo($"dumping data {packet.ReadShort()}.");
                LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
                switch (protocolID)
                {
                    case 1: // serverconnectack
                        // no need to reply just log
                        Send(new byte[] { 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x54, 0x65, 0x73, 0x74, 0x20, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x00, 0x00 });
                        Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x51, 0x00 });
                        return;
                    case 71: // OnSFUserCountAck
                        
                        LogFactory.GetLog(name).LogInfo($"UserCount {packet.ReadShort()}/{packet.ReadShort()}.");
                        return;
                    case 72: // OnSFUserLoginReq
                        //Send(new byte[] { 0x05, 0x00, 0x00, 0x00, 0x49, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 }); // fail to login or not found user in overlap
                        Send(new byte[] { 0x05, 0x00, 0x00, 0x00, 0x20, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 });
                        return;
                    case 74:
                    case 77: // OnSFUserLogoutNotice
                        LogFactory.GetLog(name).LogInfo($"Notice {packet.ReadShort()}.");
                        return;
                    case 79: // OnSFConnectedUserListAck

                        return;
                    case 80: // OnSFExitGameServerUserNotice

                        return;
                    case 82: // OnSFLGGalaxyAddressAck

                        return;
                    case 83: // OnSFGameServerInfoReq
                             
                        return;
                }
            }
            catch (Exception e)
            {

            }
        }
    }
}
