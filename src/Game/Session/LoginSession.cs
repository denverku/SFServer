﻿
using Shared.Model;
using Shared.Network;
using Shared.Util.Log.Factories;
using Shared.Util;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Game.Session
{
    internal class LoginSession : Shared.Session.Session
    {
        
        public LoginSession(Server server, TcpClient client) : base(server, client)
        {
            SendRaw(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00  });
        }

        protected override void OnRun(Packet packet)
        {
            try
            {
                //Packet packet = new Packet(buffer);
               
                LogFactory.GetLog(server.Name).LogInfo($"dumping packet protocolID {packet.protocolID}.");
                packet.Dump();
               // LogFactory.GetLog(server.Name).LogInfo($"\n{NetworkUtil.DumpPacket(buffer, length)}");
                switch (packet.protocolID)
                {
                    case 0: // OnSFConnectServerReq
                        SendRaw(new byte[] {0x04, 0x00, 0x00, 0x00, 0x47, 0x00, 0x00, 0x00, 0x05, 0x00});
                        
                        SendRaw(new byte[] { 0x06, 0x00, 0x00, 0x00, 0x48, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00  });
                        break;
                    case 32: // OnSFUserLoginAck
                        //SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x47, 0x00, 0x01, 0x00, 0x05, 0x00 });
                        //SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x4a, 0x00, 0x01, 0x00, 0x00, 0x00 });
                        break;
                    case 73: // OnSFUserLoginAck
                        //SendRaw(new byte[] {0x04, 0x00, 0x00, 0x00, 0x4a, 0x00, 0x01, 0x00, 0x00, 0x00});
                        break;
                    case 76: // OnSFForcedDisconnectUserReq

                        break; 
                    case 78: // SendUserInfo

                        break;
                    case 81: // OnSFGalaxyAddressReq
                        SendRaw(new byte[] {0x64, 0x00, 0x00, 0x00, 0x52, 0x00, 0x64, 0x00,
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
0x00, 0x00});
                        SendRaw(new byte[] { 0x06, 0x00, 0x00, 0x00, 0x48, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00 });
                        break;
                }
            }
            catch (Exception e)
            {
                LogFactory.GetLog(server.Name).LogFatal(e);
            }

            base.OnRun(packet);
        }

        protected override void HandlePacket(Packet packet)
        {
            

            base.HandlePacket(packet);
        }

        public override void OnFinishPacketSent(Packet packet)
        {
            
            base.OnFinishPacketSent(packet);
        }

       
    }
}