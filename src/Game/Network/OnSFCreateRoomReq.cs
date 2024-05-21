using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFCreateRoomReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 212;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            /*Packet test = new Packet(402);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.WriteInt(1);
            test.Dump();
            session.SendPacket(test);*/
            //session.SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x2f, 0x01, 0x02, 0x00, 0x00});
            session.SendRaw(new byte[] { 0x01, 0x00, 0x00, 0x00, 0xd5, 0x00, 0x00 }); // reply when room created
        }


    }
}
