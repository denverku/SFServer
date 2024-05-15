using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFChangeEnemyViewReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 1306;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            // session.SendRaw(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x6f, 0x00, 0x76, 0x6d, 0x6d, 0x13, 0x74, 0xc0, 0x30, 0x20, 0xcf, 0x39, 0x08, 0xa3, 0x43, 0x7a, 0xdf, 0x1a });
        }


    }
}
