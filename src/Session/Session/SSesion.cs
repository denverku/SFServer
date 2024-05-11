﻿using Shared;
using Shared.Network;
using Shared.Util;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Session.Session
{
    internal class SSesion : Shared.Session.Session
    {
        // User::PacketParsing
        public SSesion(Server server, TcpClient client) : base(server, client)
        {
            //_kickTask = new KickInactiveSession(this, server.Scheduler);
            //server.Scheduler.AddTask(_kickTask, 1, true);
        }
        protected override void OnRun(Packet packet)
        {
            try
            {
                
                
               LogFactory.GetLog(server.Name).LogInfo($"dumping packet proto {packet.protocolID - 50}.");
                
                //LogFactory.GetLog(server.Name).LogInfo($"dumping packet test {packet.ReadShort()}.");
                //LogFactory.GetLog(server.Name).LogInfo($"dumping packet test {packet.ReadString(9)}.");
                //LogFactory.GetLog(server.Name).LogInfo($"\n{NetworkUtil.DumpPacket(buffer, length)}");

                switch (packet.protocolID - 50)
                {
                    case 0: // OnSFLoginReq
                        LogFactory.GetLog(server.Name).LogInfo($"Client Version {packet.ReadShort()}.");
                        byte[] ba = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x33, 0x00, 0x00, 0x00, 0x00 };
                        SendRaw(ba);
                        break;
                    case 2: // OnSFServerListReq
                        //LogFactory.GetLog(server.Name).LogInfo($"test {packet.ReadShort()}.");
                        //LogFactory.GetLog(server.Name).LogInfo($"LoginServerID {packet.ReadShort()}.");
                        SendRaw(new byte[] { 0x19, 0x00, 0x00, 0x00, 0x35, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x05, 0x00, 0x54, 0x65, 0x73, 0x74, 0x20, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x00  });
                        break;
                    case 4: // OnSFServerIPReq
                        LogFactory.GetLog(server.Name).LogInfo($"ServerId {packet.ReadShort()}.");
                        //LogFactory.GetLog(server.Name).LogInfo($"LoginServerID {packet.ReadShort()}.");
                        SendRaw(new byte[] { 0x0a, 0x00, 0x00, 0x00, 0x37, 0x00, 0x31, 0x50, 0x72, 0xe4, 0x81, 0x99, 0x26, 0x04, 0x03, 0x8d });
                        break;
                    case 6: // OnSFReloginReq

                        break;
                    case 8: // close reuest

                        break;
                    case 10: // OnSFSCGalaxyServerReq
                        
                        SendRaw(new byte[] { 0x6c, 0x00, 0x00, 0x00, 0x3d, 0x00, 0x01, 0x00,
0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00  });
                        break;
                    case 12: // OnSFTESTServerIPReq

                        break;
                    case 14: // OnSFSetVTableReq

                        break;
                    case 16: // OnSFCheckVTableReq also

                        break;
                }

               /* if (opcode == 50) // OnSFLoginReq checking if approve? like version check send login ack
                {

                    // send approve dont reply if dont want to approve
                    byte[] ba = new byte[] { 0x03, 0x00, 0x00, 0x00, 0x33, 0x00, 0x00, 0x00, 0x00 };
                    SendRaw(ba);
                }
                if (opcode == 52) // OnSFServerListReq
                {
                    //Packet rawp = new Packet();
                    byte[] ba = new byte[] { 0x19, 0x00, 0x00, 0x00, 0x35, 0x00, 0x01, 0x00,
0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x05, 0x00, 0x54, 0x65, 0x73, 0x74, 0x20,
0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x00  };
                    SendRaw(ba);
                }
                if (opcode == 60) // when i click server loginack
                {
                    //Packet rawp = new Packet();
                    byte[] ba = new byte[] { 0x6c, 0x00, 0x00, 0x00, 0x3d, 0x00, 0x01, 0x00,
0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00  };
                    SendRaw(ba);
                }
                if (opcode == 54) // when i click server
                {
                    // send game server ip i think
                    byte[] ba = new byte[] { 0x0a, 0x00, 0x00, 0x00, 0x37, 0x00, 0x31, 0x50, 0x72, 0xe4, 0x81, 0x99, 0x26, 0x04, 0x03, 0x8d  };
                    SendRaw(ba);
                }*/
                
                
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
