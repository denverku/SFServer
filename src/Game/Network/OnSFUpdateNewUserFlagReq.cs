﻿using Shared.Network;
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
            /*session.SendRaw(new byte[] {0x97, 0x00, 0x00, 0x00, 0x69, 0x00, 0x0a, 0x43,
0x48, 0x31, 0x20, 0x3a, 0x20, 0x41, 0x4c, 0x4c,
0x00, 0x04, 0x00, 0x2c, 0x01, 0x43, 0x48, 0x32,
0x20, 0x3a, 0x20, 0x41, 0x4c, 0x4c, 0x00, 0x00,
0x00, 0x2c, 0x01, 0x54, 0x72, 0x61, 0x6e, 0x73,
0x63, 0x65, 0x6e, 0x64, 0x65, 0x72, 0x2d, 0x20,
0x3a, 0x20, 0x41, 0x4c, 0x4c, 0x00, 0x00, 0x00,
0x2c, 0x01, 0x43, 0x48, 0x34, 0x20, 0x3a, 0x20,
0x41, 0x4c, 0x4c, 0x00, 0x00, 0x00, 0x2c, 0x01,
0x43, 0x48, 0x35, 0x20, 0x3a, 0x20, 0x41, 0x4c,
0x4c, 0x00, 0x00, 0x00, 0x2c, 0x01, 0x43, 0x48,
0x36, 0x20, 0x3a, 0x20, 0x41, 0x4c, 0x4c, 0x00,
0x00, 0x00, 0x2c, 0x01, 0x43, 0x48, 0x37, 0x20,
0x3a, 0x20, 0x41, 0x4c, 0x4c, 0x00, 0x00, 0x00,
0x2c, 0x01, 0x43, 0x48, 0x38, 0x20, 0x3a, 0x20,
0x41, 0x4c, 0x4c, 0x00, 0x00, 0x00, 0x2c, 0x01,
0x43, 0x48, 0x39, 0x20, 0x3a, 0x20, 0x41, 0x4c,
0x4c, 0x00, 0x00, 0x00, 0x2c, 0x01, 0x43, 0x48,
0x31, 0x30, 0x20, 0x3a, 0x20, 0x41, 0x4c, 0x4c,
0x00, 0x01, 0x00, 0x2c, 0x01  });*/

        }


    }
}

