using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFSendUserDataReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 102;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x67, 0x00, 0x01 });

        }


    }
}

