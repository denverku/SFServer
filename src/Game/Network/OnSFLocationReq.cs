using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFLocationReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 302;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x2f, 0x01, 0x01, 0x29, 0x00 }); // map req

        }


    }
}
