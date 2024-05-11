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
    internal class UserSession : Shared.Session.Session
    {
        // User::PacketParsing
        public UserSession(Server server, TcpClient client) : base(server, client)
        {
            //_kickTask = new KickInactiveSession(this, server.Scheduler);
            //server.Scheduler.AddTask(_kickTask, 1, true);
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
                    case 0: // OnSFLoginReq
                        if(packet.ReadShort() == 9002) // GetUserAccount
                        {
                            // LogFactory.GetLog(server.Name).LogInfo($"Client Version {packet.ReadShort()}.");
                            SendRaw(new byte[] {0x44, 0x46, 0x2d, 0x00, 0x00, 0x00, 0x2b, 0x23,
0x31, 0x7c, 0x45, 0x33, 0x31, 0x34, 0x36, 0x44,
0x37, 0x32, 0x2d, 0x36, 0x31, 0x32, 0x34, 0x2d,
0x34, 0x43, 0x39, 0x43, 0x2d, 0x38, 0x36, 0x31,
0x37, 0x2d, 0x38, 0x44, 0x43, 0x35, 0x45, 0x45,
0x36, 0x39, 0x37, 0x43, 0x39, 0x35, 0x7c, 0x35,
0x30, 0x30, 0x30, 0x30, 0x00});
                        }
                       // LogFactory.GetLog(server.Name).LogInfo($"Client Version {packet.ReadShort()}.");
                        //byte[] ba = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x33, 0x00, 0x00, 0x00, 0x00 };
                        //SendRaw(ba);
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
