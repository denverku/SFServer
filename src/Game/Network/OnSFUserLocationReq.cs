using Shared;
using Shared.Network;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFUserLocationReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 328;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            // pag lumipat ka sa room blue or red team
            Packet test = new Packet(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x49, 0x01, 0x00, 0x76, 0x07, 0x0f });
            test.Dump();
            session.SendPacket(test);
            //SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x49, 0x01, 0x00, 0xa3, 0x06, 0x01 });

            LogFactory.GetLog(session.Server.Name).LogInfo($"OnSFUserLocationReq {packet.ReadShort()}.");

            
        }

        
    }
}
