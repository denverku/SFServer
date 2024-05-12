using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFSaveNickNameReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 118;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x77, 0x00, 0x01 }); // saved

        }


    }
}
