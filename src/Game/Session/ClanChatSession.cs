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
    internal class ClanChatSession : Shared.Session.Session
    {

        public ClanChatSession(Server server, TcpClient client) : base(server, client)
        {
        }

        protected override void OnRun(Packet packet)
        {
            try
            {
                
                LogFactory.GetLog(server.Name).LogInfo($"dumping packet protocolID {packet.protocolID}.");
               
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
