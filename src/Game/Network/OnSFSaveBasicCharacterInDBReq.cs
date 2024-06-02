using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFSaveBasicCharacterInDBReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 220;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            
        }


    }
}


