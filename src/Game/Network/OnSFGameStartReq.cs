﻿using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFGameStartReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 6925;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            Packet map = new Packet();
            map.WriteByte(0x44);
            map.WriteByte(0x46);
            map.WriteByte(0x49);
            map.WriteByte(0x1b);
            map.WriteByte(0x01);
            map.WriteByte(0x1a); // map
            map.WriteByte(0x00);
            map.WriteByte(0x07);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x01);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);

            map.WriteByte(0x09);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteByte(0x00);
            map.WriteLength();
            session.SendPacket(map);


            session.SendRaw(new byte[] { 0x44, 0x46, 0x25, 0x00, 0x00, 0x00, 0x6a, 0x1b,
0x00, 0x00, 0x23, 0x39, 0x39, 0x39, 0x39, 0x46,
0x46, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x01,
0x01, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x01, 0x44, 0x46, 0x06,
0x02, 0x00, 0x00, 0x47, 0x1b, 0x00, 0x00, 0xa6,
0x01, 0xfd, 0x03, 0x00, 0x00, 0x00, 0x4e, 0x00,
0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x00, 0x0e,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7d,
0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x44, 0x4f, 0x4f, 0x46, 0x45, 0x4e, 0x2d,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x04, 0x00, 0x33, 0x1a, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1e,
0x23, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x72, 0x00, 0x00, 0x00, 0x73,
0x00, 0x00, 0x00, 0x7d, 0x00, 0x00, 0x00, 0x30,
0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x37, 0x1a, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x13, 0x14, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x72, 0x00, 0x00, 0x00, 0x73, 0x00, 0x00,
0x00, 0x6d, 0x00, 0x00, 0x00, 0x30, 0x14, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xf9,
0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0xce, 0x1a, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x30, 0x14, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x78, 0x23, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x4e, 0x1d, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x30, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x48, 0x66, 0x00, 0x00, 0x00,
0x00, 0xb0, 0x8d, 0x00, 0x00, 0x00, 0x00, 0xd6,
0x8d, 0x00, 0x00, 0x00, 0x00, 0xc3, 0x8d, 0x00,
0x00, 0x00, 0x00, 0xc8, 0x84, 0x00, 0x00, 0x00,
0x00, 0x01, 0x85, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x44, 0x46, 0x04, 0x00, 0x00,
0x00, 0xdf, 0x1a, 0x00, 0x00, 0x00, 0x00, 0x44,
0x46, 0x06, 0x00, 0x00, 0x00, 0x5e, 0x1b, 0x01,
0x00, 0xd3, 0x29, 0x03, 0x00 });




        }


    }
}