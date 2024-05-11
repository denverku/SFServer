using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFCreateRoomReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 212;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x01, 0x00, 0x00, 0x00, 0xd5, 0x00, 0x00 });
        }


    }
}
