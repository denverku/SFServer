using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFChatInChannelAllReq : BaseNetwork
    {
        // chat on loby not room
        public int ProtocolId()
        {
            return 210;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {


        }


    }
}

