using Shared;
using Shared.Network;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFConnectionReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 6856;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            
            session.SendRaw(new byte[] { 0x44, 0x46, 0x03, 0x00, 0x00, 0x00, 0xc9, 0x1a, 0x00, 0xa6, 0x01 });
            
           
        }


    }
}
