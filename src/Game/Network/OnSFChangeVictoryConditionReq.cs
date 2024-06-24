using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFChangeVictoryConditionReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 7110;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            Packet victory = new Packet();
            victory.WriteByte(0x44);
            victory.WriteByte(0x46);
            victory.WriteByte(0xc7);
            victory.WriteByte(0x1b);
            victory.WriteByte(packet.ReadByte());
            
            victory.WriteLength();
            session.SendPacket(victory);
            //session.SendRaw(new byte[] { 0x44, 0x46, 0x01, 0x00, 0x00, 0x00, 0xc7, 0x1b, 0x14 });
        }


    }
}