﻿using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFSaveSystemSpecReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 120;
        }

        // this is go to channel
        public void Handle(Packet packet, Shared.Session.Session session)
        {
           session.SendRaw(new byte[] { 0x21, 0x00, 0x00, 0x00, 0x70, 0x02, 0x64, 0x00,
0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0xfe, 0xff,
0xff, 0xff, 0x0d, 0x00, 0x00, 0x00, 0x36, 0x31,
0x2e, 0x39, 0x30, 0x2e, 0x32, 0x30, 0x33, 0x2e,
0x32, 0x32, 0x00, 0x1f, 0x6d, 0x00, 0x00 }); // idk
            
            session.SendRaw(new byte[] { 0x08, 0x00, 0x00, 0x00, 0x92, 0x09, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3c, 0x00,
0x00, 0x00, 0x61, 0x02, 0x38, 0x35, 0x34, 0x36,
0x33, 0x31, 0x30, 0x30, 0x38, 0x32, 0x36, 0x35,
0x37, 0x30, 0x33, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x4e, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x70, 0x11, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x04, 0x00, 0x00, 0x00, 0x70, 0x17, 0x00, 0x00,
0x00, 0x00, 0x05, 0x00, 0x00, 0x00, 0x68, 0x02,
0x30, 0x00, 0x00, 0xff, 0xff, 0x92, 0x00, 0x00,
0x00, 0x63, 0x02, 0x02, 0x00, 0xc1, 0x59, 0x11,
0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0xc2, 0x59, 0x11,
0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00,
0x00, 0x87, 0x1c, 0x00, 0x00, 0x00, 0x02, 0x00,
0x00, 0x00, 0x62, 0x02, 0x00, 0x00, 0x01, 0x00,
0x00, 0x00, 0x69, 0x02, 0x00, 0x15, 0x00, 0x00,
0x00, 0xc0, 0x5d, 0x00, 0x00, 0x00, 0x00, 0x01,
0x00, 0x00, 0x00, 0x72, 0x01, 0x00, 0x00, 0x01,
0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x08, 0x00, 0x00, 0x00, 0xc3, 0x5d, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x00,
0x00, 0x00, 0x64, 0x02, 0x00, 0x00, 0x00, 0x3c,
0x00, 0x00, 0x00, 0xba, 0x0b, 0x05, 0x00, 0x25,
0x04, 0x00, 0x00, 0x98, 0x3a, 0x00, 0x00, 0x01,
0x50, 0x04, 0x00, 0x00, 0x98, 0x3a, 0x00, 0x00,
0x01, 0xa7, 0x06, 0x00, 0x00, 0x98, 0x3a, 0x00,
0x00, 0x01, 0xa8, 0x06, 0x00, 0x00, 0x98, 0x3a,
0x00, 0x00, 0x01, 0xa9, 0x06, 0x00, 0x00, 0x98,
0x3a, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x04, 0x00, 0x00, 0x00, 0xcf, 0x04, 0x00,
0x00, 0x00, 0x00 });

        }


    }
}