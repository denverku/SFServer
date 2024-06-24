using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFCheckOverlapNickNameReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 6858;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
           
            session.SendRaw(new byte[] { 0x44, 0x46, 0x01, 0x00, 0x00, 0x00, 0xcb, 0x1a, 0x01 }); // allow

        }


    }
}
