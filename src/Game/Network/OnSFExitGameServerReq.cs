using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFExitGameServerReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 700;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {


        }


    }
}
