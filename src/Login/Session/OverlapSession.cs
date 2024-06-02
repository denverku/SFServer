using Shared.Model;
using Shared.Network;
using Shared.Util.Log.Factories;
using Shared.Util;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Login.Session
{
    internal class OverlapSession : Shared.Session.Session
    {
        //private KickInactiveSession _kickTask;
        private User _user;
        public OverlapSession(Server server, TcpClient client) : base(server, client)
        {
            //_kickTask = new KickInactiveSession(this, server.Scheduler);
            //server.Scheduler.AddTask(_kickTask, 1, true);
        }
        protected override void OnRun(Packet packet)
        {
            try
            {
               
                LogFactory.GetLog(server.Name).LogInfo($"dumping packet opcode {packet.protocolID}.");
                //LogFactory.GetLog(server.Name).LogInfo($"\n{NetworkUtil.DumpPacket(buffer, length)}");
                /*int opcode = packet.protocolID;
                if(opcode == 0)
                {
                    SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 });
                    SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x1e, 0x00, 0x01, 0x00, 0x00, 0x00 });
                }
                if (opcode == 31)
                {
                    SendRaw(new byte[] { 0x08, 0x00, 0x00, 0x00, 0x20, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00 });
                    
                }
                if (opcode == 33)
                {
                    LogFactory.GetLog(server.Name).LogInfo($"User serial {packet.ReadInt()}.");
                    LogFactory.GetLog(server.Name).LogInfo($"Server Id {packet.ReadInt()}.");
                    SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x22, 0x00, 0x01, 0x00, 0x00, 0x00 });
                
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

        public User User => _user;
    }
}
