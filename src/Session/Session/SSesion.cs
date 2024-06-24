using Shared;
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
            //SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x31, 0x00 });
        }

        protected override void OnRun(Packet packet)
        {
            try
            {
                
                
                LogFactory.GetLog(server.Name).LogInfo($"dumping packet proto {packet.protocolID}.");
                packet.Dump();
                //LogFactory.GetLog(server.Name).LogInfo($"dumping packet test {packet.ReadShort()}.");
                //LogFactory.GetLog(server.Name).LogInfo($"dumping packet test {packet.ReadString(9)}.");
                //LogFactory.GetLog(server.Name).LogInfo($"\n{NetworkUtil.DumpPacket(buffer, length)}");

                switch (packet.protocolID)
                {
                    case 4559: // OnSFLoginReq
                        
                        SendRaw(new byte[] {0x44, 0x46, 0x18, 0x00, 0x00, 0x00, 0xd0, 0x11,
0x00, 0xd9, 0x02, 0xd3, 0x29, 0x03, 0x00, 0x31,
0x39, 0x39, 0x39, 0x31, 0x31, 0x32, 0x37, 0x00,
0x13, 0x00, 0x00, 0x00, 0xfd, 0x2d, 0x5f, 0x87});
                        break;
                    case 7055: // OnSFServerListReq
                        Packet test = new Packet();
                        test.WriteByte(0x44);
                        test.WriteByte(0x46);
                        test.WriteByte(0xd2); // head
                        test.WriteByte(0x11);

                        test.WriteByte(0xd3);
                        test.WriteByte(0x29);
                        test.WriteByte(0x03);
                        test.WriteByte(0x00);
                        test.WriteByte(0x01);
                        test.WriteByte(0x00);
                        test.WriteByte(0x00);
                        test.WriteByte(0x02);

                        test.WriteByte(0x00);
                        test.WriteInt(1);
                        test.WriteByte(0x00);
                        test.WriteInt(100);
                        test.WriteByte(0x00); // player count
                        test.WriteString("Test Server");
                        test.WriteByte(0x00);
                        test.WriteLength();
                        test.Dump();
                        SendPacket(test);
                        /*SendRaw(new byte[] {0x44, 0x46, 0x1b, 0x00, 0x00, 0x00, 0xd2, 0x11,
0xd3, 0x29, 0x03, 0x00, 0x01, 0x00, 0x00, 0x02,
0x00, 0x0d, 0x00, 0xc4, 0x09, 0x57, 0x61, 0x72,
0x20, 0x5a, 0x6f, 0x6e, 0x65, 0x20, 0x28, 0x45,
0x55, 0x29, 0x00});*/
                        break;
                    case 4563: // OnSFServerIPReq
                        //Packet ss = new Packet(new byte[] { 0x44, 0x46, 0x0f, 0x00, 0x00, 0x00, 0xd4, 0x11, 0x31, 0x32, 0x37, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x31, 0x00 });
                        Packet ss = new Packet();
                        ss.WriteByte(0x44);
                        ss.WriteByte(0x46);
                        ss.WriteByte(0xd4); // head
                        ss.WriteByte(0x11); // head
                        ss.WriteString("127.0.0.1");
                        
                        ss.WriteByte(0x00);
                        ss.WriteLength();
                        ss.Dump();
                        SendPacket(ss);
                        
                        //SendRaw(new byte[] { 0x0d, 0x00, 0x00, 0x00, 0x37, 0x00, 0x36, 0x53, 0x6b, 0xf3, 0x81, 0x99, 0x24, 0x1a, 0x01, 0xa3, 0x04, 0x8e, 0x1f });
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
