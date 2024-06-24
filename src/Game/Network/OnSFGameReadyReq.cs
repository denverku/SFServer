using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFGameReadyReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 6921;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            Packet map = new Packet();
            map.WriteByte(0x44);
            map.WriteByte(0x46);
            map.WriteByte(0x41);
            map.WriteByte(0x1b);
            map.WriteByte(packet.ReadByte());
            map.WriteByte(0x00);
            map.WriteLength();
            session.SendPacket(map);
            //session.SendRaw(new byte[] { 0x44, 0x46, 0x02, 0x00, 0x00, 0x00, 0x41, 0x1b, 0x20, 0x00 });




        }


    }
}
