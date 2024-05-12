using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFEnterForceSettingReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 1204;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] { 0x10, 0x00, 0x00, 0x00, 0xb5, 0x04, 0x62, 0x97, 0x5b, 0x46, 0x87, 0xf3, 0x7a, 0x9f, 0xa0, 0xcd, 0xbb, 0xd8, 0x2f, 0x48, 0x2b, 0x54 });


        }


    }
}