using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFUpdateNewUserFlagReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 122;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            

        }


    }
}

