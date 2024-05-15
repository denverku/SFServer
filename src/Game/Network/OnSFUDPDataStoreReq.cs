﻿using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFUDPDataStoreReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 114;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            /*session.SendRaw(new byte[] { 0xbb, 0x00, 0x00, 0x00, 0x69, 0x00, 0x0d, 0x43,
0x68, 0x61, 0x6e, 0x6e, 0x65, 0x6c, 0x20, 0x31,
0x00, 0x13, 0x00, 0x2c, 0x01, 0x43, 0x68, 0x61,
0x6e, 0x6e, 0x65, 0x6c, 0x20, 0x32, 0x00, 0x00,
0x00, 0x2c, 0x01, 0x43, 0x68, 0x61, 0x6e, 0x6e,
0x65, 0x6c, 0x20, 0x33, 0x00, 0x00, 0x00, 0x2c,
0x01, 0x43, 0x68, 0x61, 0x6e, 0x6e, 0x65, 0x6c,
0x20, 0x34, 0x00, 0x00, 0x00, 0x2c, 0x01, 0x43,
0x68, 0x61, 0x6e, 0x6e, 0x65, 0x6c, 0x20, 0x35,
0x00, 0x00, 0x00, 0x2c, 0x01, 0x43, 0x68, 0x61,
0x6e, 0x6e, 0x65, 0x6c, 0x20, 0x36, 0x00, 0x00,
0x00, 0x2c, 0x01, 0x43, 0x68, 0x61, 0x6e, 0x6e,
0x65, 0x6c, 0x20, 0x37, 0x00, 0x00, 0x00, 0x2c,
0x01, 0x43, 0x68, 0x61, 0x6e, 0x6e, 0x65, 0x6c,
0x20, 0x38, 0x00, 0x00, 0x00, 0x2c, 0x01, 0x43,
0x68, 0x61, 0x6e, 0x6e, 0x65, 0x6c, 0x20, 0x39,
0x00, 0x00, 0x00, 0x2c, 0x01, 0x43, 0x68, 0x61,
0x6e, 0x6e, 0x65, 0x6c, 0x20, 0x31, 0x30, 0x00,
0x00, 0x00, 0x2c, 0x01, 0x43, 0x68, 0x61, 0x6e,
0x6e, 0x65, 0x6c, 0x20, 0x31, 0x31, 0x00, 0x00,
0x00, 0x2c, 0x01, 0x43, 0x68, 0x61, 0x6e, 0x6e,
0x65, 0x6c, 0x20, 0x31, 0x32, 0x00, 0x00, 0x00,
0x2c, 0x01, 0x43, 0x68, 0x61, 0x6e, 0x6e, 0x65,
0x6c, 0x20, 0x31, 0x33, 0x00, 0x00, 0x00, 0x2c,
0x01 });*/
            session.SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x2f, 0x01, 0x00, 0x00,
0x00 });
        }


    }
}

