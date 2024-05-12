using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFCharacterInfoReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 1300;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
           

        }


    }
}
