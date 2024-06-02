using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFCheckBalanceReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 1214;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            // BALANCE
            Packet roomlist = new Packet(new byte[] {0x04, 0x00, 0x00, 0x00, 0xbf, 0x04, 0x00, 0x00, 0x00, 0x00 });
            roomlist.Dump();
            session.SendPacket(roomlist);
        }
    }
}