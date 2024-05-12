using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFEndClientLoadingReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 324;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x05, 0x00, 0x00, 0x00, 0x26, 0x02, 0x54, 0x05, 0x05, 0x04, 0x00});
        }


    }
}