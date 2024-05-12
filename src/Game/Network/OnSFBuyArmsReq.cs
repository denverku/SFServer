using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFBuyArmsReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 1210;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x79, 0x05, 0x60, 0x6d, 0x00, 0x00 });
            session.SendRaw(new byte[] { 0x0c, 0x00, 0x00, 0x00, 0xbb, 0x04, 0x01, 0xcf,
0x07, 0x99, 0x21, 0x30, 0x75, 0x00, 0x00, 0x00,
0x00, 0x00});

        }


    }
}