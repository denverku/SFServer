using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Network
{
    public interface BaseNetwork
    {
        public int ProtocolId();
        public void Handle(Packet packet, Session.Session session);
    }
}
