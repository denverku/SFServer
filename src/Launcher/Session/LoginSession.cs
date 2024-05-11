using Shared.Network;
using Shared.Util.Log.Factories;
using Shared.Util;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Launcher.Session
{
    internal class LoginSession : Shared.Session.Session
    {
        // User::PacketParsing
        public LoginSession(Server server, TcpClient client) : base(server, client)
        {
            SendRaw(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00 });
        }
        protected override void OnRun(Packet packet)
        {
            try
            {


                 LogFactory.GetLog(server.Name).LogInfo($"dumping packet proto {packet.protocolID}.");

                //LogFactory.GetLog(server.Name).LogInfo($"dumping packet test {packet.ReadShort()}.");
                //LogFactory.GetLog(server.Name).LogInfo($"dumping packet test {packet.ReadString(9)}.");
               // LogFactory.GetLog(server.Name).LogInfo($"\n{NetworkUtil.DumpPacket(buffer, length)}");

                switch (packet.protocolID)
                {
                    case 9000: // OnSFLoginReq
                        LogFactory.GetLog(server.Name).LogInfo($"Serial {packet.ReadShort()}.");
                        LogFactory.GetLog(server.Name).LogInfo($"AuthKey {packet.ReadString()}.");
                        LogFactory.GetLog(server.Name).LogInfo($"GameType {packet.ReadString()}.");
                        SendRaw(new byte[] {0x08, 0x00, 0x00, 0x00, 0x29, 0x23, 0x50, 0xc3, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00});
                        break;

                }


                base.OnRun(packet);
            }
            catch (Exception e)
            {
                LogFactory.GetLog(server.Name).LogFatal(e);
            }
        }



        protected override void HandlePacket(Packet packet)
        {


            base.HandlePacket(packet);
        }





        public override void OnFinishPacketSent(Packet packet)
        {


            // _kickTask.Inactive = 0;
            base.OnFinishPacketSent(packet);
        }
    }
}
