﻿using Shared.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFGetDBDataReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 115;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            /*session.SendRaw(new byte[] { 0x21, 0x00, 0x00, 0x00, 0x70, 0x02, 0x64, 0x00,
0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0xfe, 0xff,
0xff, 0xff, 0x0d, 0x00, 0x00, 0x00, 0x31, 0x31,
0x36, 0x2e, 0x39, 0x33, 0x2e, 0x38, 0x38, 0x2e,
0x32, 0x32, 0x00, 0x1f, 0x6d, 0x00, 0x00  });*/

            /*session.SendRaw(new byte[] { 0x34, 0x00, 0x00, 0x00, 0x61, 0x02, 0x57, 0x61,
0x73, 0x73, 0x61, 0x62, 0x79, 0x79, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xb6, 0xfc,
0x07, 0x00, 0x59, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x70, 0x11, 0x01, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0xfa, 0x24, 0x00, 0x00, 0xb8, 0x0b,
0x3e, 0x09, 0x02, 0x00, 0x00, 0x00, 0x03, 0x00,
0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x05, 0x00,
0x00, 0x00, 0x06, 0x00, 0x00, 0x00, 0x07, 0x00,
0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x09, 0x00,
0x00, 0x00, 0x0a, 0x00, 0x00, 0x00, 0x0b, 0x00,
0x00, 0x00, 0x0c, 0x00, 0x00, 0x00, 0x0d, 0x00,
0x00, 0x00, 0x0e, 0x00, 0x00, 0x00, 0x0f, 0x00,
0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x11, 0x00,
0x00, 0x00, 0x13, 0x00, 0x00, 0x00, 0x14, 0x00,
0x00, 0x00, 0x15, 0x00, 0x00, 0x00, 0x1b, 0x00,
0x00, 0x00, 0x1c, 0x00, 0x00, 0x00, 0x37, 0x00,
0x00, 0x00, 0x38, 0x00, 0x00, 0x00, 0x3d, 0x00,
0x00, 0x00, 0x3e, 0x00, 0x00, 0x00, 0x57, 0x00,
0x00, 0x00, 0x58, 0x00, 0x00, 0x00, 0x5b, 0x00,
0x00, 0x00, 0x5c, 0x00, 0x00, 0x00, 0x61, 0x00,
0x00, 0x00, 0x62, 0x00, 0x00, 0x00, 0x63, 0x00,
0x00, 0x00, 0x64, 0x00, 0x00, 0x00, 0x65, 0x00,
0x00, 0x00, 0x66, 0x00, 0x00, 0x00, 0x67, 0x00,
0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x6b, 0x00,
0x00, 0x00, 0x6c, 0x00, 0x00, 0x00, 0x6d, 0x00,
0x00, 0x00, 0x6e, 0x00, 0x00, 0x00, 0x6f, 0x00,
0x00, 0x00, 0x70, 0x00, 0x00, 0x00, 0x71, 0x00,
0x00, 0x00, 0x72, 0x00, 0x00, 0x00, 0x73, 0x00,
0x00, 0x00, 0x74, 0x00, 0x00, 0x00, 0x75, 0x00,
0x00, 0x00, 0x77, 0x00, 0x00, 0x00, 0x9c, 0x00,
0x00, 0x00, 0xc1, 0x00, 0x00, 0x00, 0xc2, 0x00,
0x00, 0x00, 0xc3, 0x00, 0x00, 0x00, 0xd6, 0x00,
0x00, 0x00, 0xd7, 0x00, 0x00, 0x00, 0xd8, 0x00,
0x00, 0x00, 0x10, 0x01, 0x00, 0x00, 0x11, 0x01,
0x00, 0x00, 0x12, 0x01, 0x00, 0x00, 0x21, 0x01,
0x00, 0x00, 0x3e, 0x01, 0x00, 0x00, 0x3f, 0x01,
0x00, 0x00, 0x42, 0x01, 0x00, 0x00, 0x43, 0x01,
0x00, 0x00, 0x44, 0x01, 0x00, 0x00, 0x45, 0x01,
0x00, 0x00, 0x46, 0x01, 0x00, 0x00, 0x47, 0x01,
0x00, 0x00, 0x48, 0x01, 0x00, 0x00, 0x49, 0x01,
0x00, 0x00, 0x4f, 0x01, 0x00, 0x00, 0x50, 0x01,
0x00, 0x00, 0x51, 0x01, 0x00, 0x00, 0x61, 0x01,
0x00, 0x00, 0x77, 0x01, 0x00, 0x00, 0x78, 0x01,
0x00, 0x00, 0x7b, 0x01, 0x00, 0x00, 0x7c, 0x01,
0x00, 0x00, 0x7d, 0x01, 0x00, 0x00, 0x7e, 0x01,
0x00, 0x00, 0x7f, 0x01, 0x00, 0x00, 0x80, 0x01,
0x00, 0x00, 0x81, 0x01, 0x00, 0x00, 0x82, 0x01,
0x00, 0x00, 0x83, 0x01, 0x00, 0x00, 0x86, 0x01,
0x00, 0x00, 0x87, 0x01, 0x00, 0x00, 0x8a, 0x01,
0x00, 0x00, 0x8b, 0x01, 0x00, 0x00, 0x8c, 0x01,
0x00, 0x00, 0x8d, 0x01, 0x00, 0x00, 0x8e, 0x01,
0x00, 0x00, 0x8f, 0x01, 0x00, 0x00, 0x90, 0x01,
0x00, 0x00, 0x91, 0x01, 0x00, 0x00, 0x94, 0x01,
0x00, 0x00, 0xa3, 0x01, 0x00, 0x00, 0xa5, 0x01,
0x00, 0x00, 0xa6, 0x01, 0x00, 0x00, 0xba, 0x01,
0x00, 0x00, 0xbb, 0x01, 0x00, 0x00, 0xc0, 0x01,
0x00, 0x00, 0xc1, 0x01, 0x00, 0x00, 0xc5, 0x01,
0x00, 0x00, 0xc6, 0x01, 0x00, 0x00, 0xca, 0x01,
0x00, 0x00, 0xcb, 0x01, 0x00, 0x00, 0xd3, 0x01,
0x00, 0x00, 0xd4, 0x01, 0x00, 0x00, 0xe5, 0x01,
0x00, 0x00, 0xe6, 0x01, 0x00, 0x00, 0xee, 0x01,
0x00, 0x00, 0xef, 0x01, 0x00, 0x00, 0xf7, 0x01,
0x00, 0x00, 0xf8, 0x01, 0x00, 0x00, 0x00, 0x02,
0x00, 0x00, 0x01, 0x02, 0x00, 0x00, 0x5f, 0x02,
0x00, 0x00, 0x60, 0x02, 0x00, 0x00, 0x65, 0x02,
0x00, 0x00, 0x66, 0x02, 0x00, 0x00, 0x68, 0x02,
0x00, 0x00, 0x69, 0x02, 0x00, 0x00, 0x6b, 0x02,
0x00, 0x00, 0x6c, 0x02, 0x00, 0x00, 0x6e, 0x02,
0x00, 0x00, 0x6f, 0x02, 0x00, 0x00, 0x74, 0x02,
0x00, 0x00, 0x75, 0x02, 0x00, 0x00, 0x04, 0x03,
0x00, 0x00, 0x05, 0x03, 0x00, 0x00, 0x06, 0x03,
0x00, 0x00, 0x50, 0x03, 0x00, 0x00, 0x55, 0x03,
0x00, 0x00, 0x56, 0x03, 0x00, 0x00, 0x57, 0x03,
0x00, 0x00, 0x5c, 0x03, 0x00, 0x00, 0x5d, 0x03,
0x00, 0x00, 0x5f, 0x03, 0x00, 0x00, 0x60, 0x03,
0x00, 0x00, 0x62, 0x03, 0x00, 0x00, 0x63, 0x03,
0x00, 0x00, 0x65, 0x03, 0x00, 0x00, 0x66, 0x03,
0x00, 0x00, 0x6b, 0x03, 0x00, 0x00, 0x6c, 0x03,
0x00, 0x00, 0xbc, 0x03, 0x00, 0x00, 0xbd, 0x03,
0x00, 0x00, 0xf4, 0x03, 0x00, 0x00, 0xf5, 0x03,
0x00, 0x00, 0x71, 0x04, 0x00, 0x00, 0xe4, 0x04,
0x00, 0x00, 0xe5, 0x04, 0x00, 0x00, 0xe6, 0x04,
0x00, 0x00, 0xe7, 0x04, 0x00, 0x00, 0xe8, 0x04,
0x00, 0x00, 0xed, 0x04, 0x00, 0x00, 0xee, 0x04,
0x00, 0x00, 0xf0, 0x04, 0x00, 0x00, 0xf1, 0x04,
0x00, 0x00, 0xf3, 0x04, 0x00, 0x00, 0xf4, 0x04,
0x00, 0x00, 0xfc, 0x04, 0x00, 0x00, 0xfd, 0x04,
0x00, 0x00, 0x90, 0x05, 0x00, 0x00, 0x9c, 0x05,
0x00, 0x00, 0x9d, 0x05, 0x00, 0x00, 0xa7, 0x05,
0x00, 0x00, 0xa8, 0x05, 0x00, 0x00, 0xc8, 0x05,
0x00, 0x00, 0xc9, 0x05, 0x00, 0x00, 0xf9, 0x05,
0x00, 0x00, 0x50, 0x06, 0x00, 0x00, 0xb0, 0x06,
0x00, 0x00, 0xb4, 0x06, 0x00, 0x00, 0xb5, 0x06,
0x00, 0x00, 0xb6, 0x06, 0x00, 0x00, 0xb7, 0x06,
0x00, 0x00, 0xb8, 0x06, 0x00, 0x00, 0xb9, 0x06,
0x00, 0x00, 0xba, 0x06, 0x00, 0x00, 0xbb, 0x06,
0x00, 0x00, 0xbe, 0x06, 0x00, 0x00, 0xbf, 0x06,
0x00, 0x00, 0xf8, 0x06, 0x00, 0x00, 0x25, 0x07,
0x00, 0x00, 0x0c, 0x08, 0x00, 0x00, 0x24, 0x08,
0x00, 0x00, 0x25, 0x08, 0x00, 0x00, 0x8e, 0x09,
0x00, 0x00, 0x95, 0x09, 0x00, 0x00, 0xfa, 0x09,
0x00, 0x00, 0x30, 0x0a, 0x00, 0x00, 0x59, 0x0a,
0x00, 0x00, 0x68, 0x0a, 0x00, 0x00, 0x6a, 0x0a,
0x00, 0x00, 0x6b, 0x0a, 0x00, 0x00, 0x76, 0x0a,
0x00, 0x00, 0x77, 0x0a, 0x00, 0x00, 0x7e, 0x0a,
0x00, 0x00, 0x7f, 0x0a, 0x00, 0x00, 0x94, 0x0a,
0x00, 0x00, 0x95, 0x0a, 0x00, 0x00, 0x96, 0x0a,
0x00, 0x00, 0x97, 0x0a, 0x00, 0x00, 0x99, 0x0a,
0x00, 0x00, 0x9a, 0x0a, 0x00, 0x00, 0xa5, 0x0a,
0x00, 0x00, 0xa6, 0x0a, 0x00, 0x00, 0xb0, 0x0a,
0x00, 0x00, 0xb1, 0x0a, 0x00, 0x00, 0x11, 0x0c,
0x00, 0x00, 0x60, 0x0c, 0x00, 0x00, 0xbf, 0x0d,
0x00, 0x00, 0x02, 0x0e, 0x00, 0x00, 0x03, 0x0e,
0x00, 0x00, 0x08, 0x0e, 0x00, 0x00, 0x09, 0x0e,
0x00, 0x00, 0x17, 0x0e, 0x00, 0x00, 0x18, 0x0e,
0x00, 0x00, 0xca, 0x0e, 0x00, 0x00, 0xcb, 0x0e,
0x00, 0x00, 0xf0, 0x0e, 0x00, 0x00, 0xf1, 0x0e,
0x00, 0x00, 0x41, 0x0f, 0x00, 0x00, 0x42, 0x0f,
0x00, 0x00, 0x0d, 0x10, 0x00, 0x00, 0x3f, 0x10,
0x00, 0x00, 0x58, 0x11, 0x00, 0x00, 0x5a, 0x11,
0x00, 0x00, 0x7f, 0x11, 0x00, 0x00, 0xab, 0x11,
0x00, 0x00, 0xd7, 0x11, 0x00, 0x00, 0x83, 0x13,
0x00, 0x00, 0x8f, 0x13, 0x00, 0x00, 0xa4, 0x13,
0x00, 0x00, 0xb8, 0x13, 0x00, 0x00, 0x16, 0x14,
0x00, 0x00, 0x4a, 0x14, 0x00, 0x00, 0x4b, 0x14,
0x00, 0x00, 0x0d, 0x15, 0x00, 0x00, 0x13, 0x15,
0x00, 0x00, 0x14, 0x15, 0x00, 0x00, 0x1f, 0x15,
0x00, 0x00, 0x20, 0x15, 0x00, 0x00, 0x23, 0x15,
0x00, 0x00, 0x24, 0x15, 0x00, 0x00, 0x27, 0x15,
0x00, 0x00, 0x28, 0x15, 0x00, 0x00, 0x2f, 0x15,
0x00, 0x00, 0x30, 0x15, 0x00, 0x00, 0x33, 0x15,
0x00, 0x00, 0x34, 0x15, 0x00, 0x00, 0x3f, 0x15,
0x00, 0x00, 0x40, 0x15, 0x00, 0x00, 0x4b, 0x15,
0x00, 0x00, 0x4c, 0x15, 0x00, 0x00, 0x4f, 0x15,
0x00, 0x00, 0x50, 0x15, 0x00, 0x00, 0x5f, 0x15,
0x00, 0x00, 0x60, 0x15, 0x00, 0x00, 0x67, 0x15,
0x00, 0x00, 0x68, 0x15, 0x00, 0x00, 0x6b, 0x15,
0x00, 0x00, 0x6c, 0x15, 0x00, 0x00, 0x90, 0x15,
0x00, 0x00, 0x91, 0x15, 0x00, 0x00, 0x93, 0x15,
0x00, 0x00, 0x97, 0x15, 0x00, 0x00, 0xa0, 0x15,
0x00, 0x00, 0x70, 0x16, 0x00, 0x00, 0x71, 0x16,
0x00, 0x00, 0x74, 0x16, 0x00, 0x00, 0x77, 0x16,
0x00, 0x00, 0x78, 0x16, 0x00, 0x00, 0xb1, 0x16,
0x00, 0x00, 0xbe, 0x16, 0x00, 0x00, 0xbf, 0x16,
0x00, 0x00, 0xc4, 0x16, 0x00, 0x00, 0xc5, 0x16,
0x00, 0x00, 0xc7, 0x16, 0x00, 0x00, 0xc8, 0x16,
0x00, 0x00, 0xca, 0x16, 0x00, 0x00, 0xcb, 0x16,
0x00, 0x00, 0xcd, 0x16, 0x00, 0x00, 0xce, 0x16,
0x00, 0x00, 0xd3, 0x16, 0x00, 0x00, 0xd4, 0x16,
0x00, 0x00, 0xe2, 0x16, 0x00, 0x00, 0xe3, 0x16,
0x00, 0x00, 0xe8, 0x16, 0x00, 0x00, 0xe9, 0x16,
0x00, 0x00, 0xee, 0x16, 0x00, 0x00, 0xef, 0x16,
0x00, 0x00, 0xf1, 0x16, 0x00, 0x00, 0xf2, 0x16,
0x00, 0x00, 0xf7, 0x16, 0x00, 0x00, 0xf8, 0x16,
0x00, 0x00, 0xfa, 0x16, 0x00, 0x00, 0xfb, 0x16,
0x00, 0x00, 0xfd, 0x16, 0x00, 0x00, 0xfe, 0x16,
0x00, 0x00, 0x00, 0x17, 0x00, 0x00, 0x01, 0x17,
0x00, 0x00, 0x06, 0x17, 0x00, 0x00, 0x07, 0x17,
0x00, 0x00, 0x15, 0x17, 0x00, 0x00, 0x16, 0x17,
0x00, 0x00, 0x1b, 0x17, 0x00, 0x00, 0x1c, 0x17,
0x00, 0x00, 0x21, 0x17, 0x00, 0x00, 0x22, 0x17,
0x00, 0x00, 0x24, 0x17, 0x00, 0x00, 0x25, 0x17,
0x00, 0x00, 0x2a, 0x17, 0x00, 0x00, 0x2b, 0x17,
0x00, 0x00, 0x2d, 0x17, 0x00, 0x00, 0x2e, 0x17,
0x00, 0x00, 0x30, 0x17, 0x00, 0x00, 0x31, 0x17,
0x00, 0x00, 0x33, 0x17, 0x00, 0x00, 0x34, 0x17,
0x00, 0x00, 0x39, 0x17, 0x00, 0x00, 0x3a, 0x17,
0x00, 0x00, 0x48, 0x17, 0x00, 0x00, 0x49, 0x17,
0x00, 0x00, 0x4e, 0x17, 0x00, 0x00, 0x4f, 0x17,
0x00, 0x00, 0x54, 0x17, 0x00, 0x00, 0x55, 0x17,
0x00, 0x00, 0x57, 0x17, 0x00, 0x00, 0x58, 0x17,
0x00, 0x00, 0x5d, 0x17, 0x00, 0x00, 0x5e, 0x17 }); // data

            session.SendRaw(new byte[] { 0x00, 0x00, 0x60, 0x17, 0x00, 0x00, 0x61, 0x17,
0x00, 0x00, 0x63, 0x17, 0x00, 0x00, 0x64, 0x17,
0x00, 0x00, 0x66, 0x17, 0x00, 0x00, 0x67, 0x17,
0x00, 0x00, 0x6c, 0x17, 0x00, 0x00, 0x6d, 0x17,
0x00, 0x00, 0x7b, 0x17, 0x00, 0x00, 0x7c, 0x17,
0x00, 0x00, 0x81, 0x17, 0x00, 0x00, 0x82, 0x17,
0x00, 0x00, 0x87, 0x17, 0x00, 0x00, 0x88, 0x17,
0x00, 0x00, 0x8a, 0x17, 0x00, 0x00, 0x8b, 0x17,
0x00, 0x00, 0x90, 0x17, 0x00, 0x00, 0x91, 0x17,
0x00, 0x00, 0x93, 0x17, 0x00, 0x00, 0x94, 0x17,
0x00, 0x00, 0x96, 0x17, 0x00, 0x00, 0x97, 0x17,
0x00, 0x00, 0x99, 0x17, 0x00, 0x00, 0x9a, 0x17,
0x00, 0x00, 0x9f, 0x17, 0x00, 0x00, 0xa0, 0x17,
0x00, 0x00, 0xae, 0x17, 0x00, 0x00, 0xaf, 0x17,
0x00, 0x00, 0xb4, 0x17, 0x00, 0x00, 0xb5, 0x17,
0x00, 0x00, 0xba, 0x17, 0x00, 0x00, 0xbb, 0x17,
0x00, 0x00, 0xbd, 0x17, 0x00, 0x00, 0xbe, 0x17,
0x00, 0x00, 0xc6, 0x17, 0x00, 0x00, 0xc7, 0x17,
0x00, 0x00, 0xc9, 0x17, 0x00, 0x00, 0xca, 0x17,
0x00, 0x00, 0xd2, 0x17, 0x00, 0x00, 0xd3, 0x17,
0x00, 0x00, 0xed, 0x17, 0x00, 0x00, 0xee, 0x17,
0x00, 0x00, 0xf5, 0x17, 0x00, 0x00, 0xf6, 0x17,
0x00, 0x00, 0xfe, 0x17, 0x00, 0x00, 0xff, 0x17,
0x00, 0x00, 0x01, 0x18, 0x00, 0x00, 0x02, 0x18,
0x00, 0x00, 0x0a, 0x18, 0x00, 0x00, 0x0b, 0x18,
0x00, 0x00, 0x25, 0x18, 0x00, 0x00, 0x44, 0x18,
0x00, 0x00, 0x45, 0x18, 0x00, 0x00, 0x93, 0x18,
0x00, 0x00, 0xa1, 0x18, 0x00, 0x00, 0xa3, 0x18,
0x00, 0x00, 0xa4, 0x18, 0x00, 0x00, 0xa5, 0x18,
0x00, 0x00, 0xa7, 0x18, 0x00, 0x00, 0xa8, 0x18,
0x00, 0x00, 0xab, 0x18, 0x00, 0x00, 0xac, 0x18,
0x00, 0x00, 0xd1, 0x18, 0x00, 0x00, 0xd6, 0x18,
0x00, 0x00, 0xd7, 0x18, 0x00, 0x00, 0xd9, 0x18,
0x00, 0x00, 0xda, 0x18, 0x00, 0x00, 0xdb, 0x18,
0x00, 0x00, 0xdd, 0x18, 0x00, 0x00, 0xde, 0x18,
0x00, 0x00, 0xe1, 0x18, 0x00, 0x00, 0xe2, 0x18,
0x00, 0x00, 0x16, 0x19, 0x00, 0x00, 0x1d, 0x19,
0x00, 0x00, 0x1e, 0x19, 0x00, 0x00, 0x21, 0x19,
0x00, 0x00, 0xc8, 0x19, 0x00, 0x00, 0xfc, 0x19,
0x00, 0x00, 0x04, 0x1a, 0x00, 0x00, 0x07, 0x1a,
0x00, 0x00, 0xcf, 0x1a, 0x00, 0x00, 0xad, 0x1b,
0x00, 0x00, 0xe6, 0x1b, 0x00, 0x00, 0x30, 0x1c,
0x00, 0x00, 0x31, 0x1c, 0x00, 0x00, 0xea, 0x1d,
0x00, 0x00, 0x09, 0x1e, 0x00, 0x00, 0xf8, 0x1e,
0x00, 0x00, 0xf9, 0x1e, 0x00, 0x00, 0xfe, 0x1e,
0x00, 0x00, 0xff, 0x1e, 0x00, 0x00, 0x01, 0x1f,
0x00, 0x00, 0x02, 0x1f, 0x00, 0x00, 0x04, 0x1f,
0x00, 0x00, 0x05, 0x1f, 0x00, 0x00, 0x0d, 0x1f,
0x00, 0x00, 0x0e, 0x1f, 0x00, 0x00, 0x19, 0x1f,
0x00, 0x00, 0x1a, 0x1f, 0x00, 0x00, 0x1c, 0x1f,
0x00, 0x00, 0x1d, 0x1f, 0x00, 0x00, 0x22, 0x1f,
0x00, 0x00, 0x23, 0x1f, 0x00, 0x00, 0x28, 0x1f,
0x00, 0x00, 0x29, 0x1f, 0x00, 0x00, 0x5e, 0x1f,
0x00, 0x00, 0x5f, 0x1f, 0x00, 0x00, 0x64, 0x1f,
0x00, 0x00, 0x65, 0x1f, 0x00, 0x00, 0x67, 0x1f,
0x00, 0x00, 0x68, 0x1f, 0x00, 0x00, 0x6a, 0x1f,
0x00, 0x00, 0x6b, 0x1f, 0x00, 0x00, 0x6d, 0x1f,
0x00, 0x00, 0x6e, 0x1f, 0x00, 0x00, 0x73, 0x1f,
0x00, 0x00, 0x74, 0x1f, 0x00, 0x00, 0x82, 0x1f,
0x00, 0x00, 0x83, 0x1f, 0x00, 0x00, 0x88, 0x1f,
0x00, 0x00, 0x89, 0x1f, 0x00, 0x00, 0x8e, 0x1f,
0x00, 0x00, 0x8f, 0x1f, 0x00, 0x00, 0x84, 0x20,
0x00, 0x00, 0x87, 0x20, 0x00, 0x00, 0x91, 0x20,
0x00, 0x00, 0x92, 0x20, 0x00, 0x00, 0x97, 0x20,
0x00, 0x00, 0x98, 0x20, 0x00, 0x00, 0x9a, 0x20,
0x00, 0x00, 0x9b, 0x20, 0x00, 0x00, 0x9d, 0x20,
0x00, 0x00, 0x9e, 0x20, 0x00, 0x00, 0xa0, 0x20,
0x00, 0x00, 0xa1, 0x20, 0x00, 0x00, 0xa6, 0x20,
0x00, 0x00, 0xa7, 0x20, 0x00, 0x00, 0xb5, 0x20,
0x00, 0x00, 0xb6, 0x20, 0x00, 0x00, 0xbb, 0x20,
0x00, 0x00, 0xbc, 0x20, 0x00, 0x00, 0xc1, 0x20,
0x00, 0x00, 0xc2, 0x20, 0x00, 0x00, 0xc4, 0x20,
0x00, 0x00, 0xc5, 0x20, 0x00, 0x00, 0xca, 0x20,
0x00, 0x00, 0xcb, 0x20, 0x00, 0x00, 0xcd, 0x20,
0x00, 0x00, 0xce, 0x20, 0x00, 0x00, 0xd0, 0x20,
0x00, 0x00, 0xd1, 0x20, 0x00, 0x00, 0xd3, 0x20,
0x00, 0x00, 0xd4, 0x20, 0x00, 0x00, 0xd9, 0x20,
0x00, 0x00, 0xda, 0x20, 0x00, 0x00, 0xdc, 0x20,
0x00, 0x00, 0xdd, 0x20, 0x00, 0x00, 0xe8, 0x20,
0x00, 0x00, 0xe9, 0x20, 0x00, 0x00, 0xee, 0x20,
0x00, 0x00, 0xef, 0x20, 0x00, 0x00, 0xf4, 0x20,
0x00, 0x00, 0xf5, 0x20, 0x00, 0x00, 0xf7, 0x20,
0x00, 0x00, 0xf8, 0x20, 0x00, 0x00, 0xfd, 0x20,
0x00, 0x00, 0xfe, 0x20, 0x00, 0x00, 0x00, 0x21,
0x00, 0x00, 0x01, 0x21, 0x00, 0x00, 0x03, 0x21,
0x00, 0x00, 0x04, 0x21, 0x00, 0x00, 0x06, 0x21,
0x00, 0x00, 0x07, 0x21, 0x00, 0x00, 0x0c, 0x21,
0x00, 0x00, 0x0d, 0x21, 0x00, 0x00, 0x1b, 0x21,
0x00, 0x00, 0x1c, 0x21, 0x00, 0x00, 0x21, 0x21,
0x00, 0x00, 0x22, 0x21, 0x00, 0x00, 0x27, 0x21,
0x00, 0x00, 0x28, 0x21, 0x00, 0x00, 0x2a, 0x21,
0x00, 0x00, 0x2b, 0x21, 0x00, 0x00, 0x30, 0x21,
0x00, 0x00, 0x31, 0x21, 0x00, 0x00, 0x33, 0x21,
0x00, 0x00, 0x34, 0x21, 0x00, 0x00, 0x36, 0x21,
0x00, 0x00, 0x37, 0x21, 0x00, 0x00, 0x39, 0x21,
0x00, 0x00, 0x3a, 0x21, 0x00, 0x00, 0x3f, 0x21,
0x00, 0x00, 0x40, 0x21, 0x00, 0x00, 0x4e, 0x21,
0x00, 0x00, 0x4f, 0x21, 0x00, 0x00, 0x54, 0x21,
0x00, 0x00, 0x55, 0x21, 0x00, 0x00, 0x5a, 0x21,
0x00, 0x00, 0x5b, 0x21, 0x00, 0x00, 0x5d, 0x21,
0x00, 0x00, 0x5e, 0x21, 0x00, 0x00, 0x63, 0x21,
0x00, 0x00, 0x64, 0x21, 0x00, 0x00, 0x66, 0x21,
0x00, 0x00, 0x67, 0x21, 0x00, 0x00, 0x69, 0x21,
0x00, 0x00, 0x6a, 0x21, 0x00, 0x00, 0x6c, 0x21,
0x00, 0x00, 0x6d, 0x21, 0x00, 0x00, 0x72, 0x21,
0x00, 0x00, 0x73, 0x21, 0x00, 0x00, 0x81, 0x21,
0x00, 0x00, 0x82, 0x21, 0x00, 0x00, 0x87, 0x21,
0x00, 0x00, 0x88, 0x21, 0x00, 0x00, 0x8d, 0x21,
0x00, 0x00, 0x8e, 0x21, 0x00, 0x00, 0x90, 0x21,
0x00, 0x00, 0x91, 0x21, 0x00, 0x00, 0x96, 0x21,
0x00, 0x00, 0x97, 0x21, 0x00, 0x00, 0x99, 0x21,
0x00, 0x00, 0x9a, 0x21, 0x00, 0x00, 0x9c, 0x21,
0x00, 0x00, 0x9d, 0x21, 0x00, 0x00, 0x9f, 0x21,
0x00, 0x00, 0xa0, 0x21, 0x00, 0x00, 0xa5, 0x21,
0x00, 0x00, 0xa6, 0x21, 0x00, 0x00, 0xb4, 0x21,
0x00, 0x00, 0xb5, 0x21, 0x00, 0x00, 0xba, 0x21,
0x00, 0x00, 0xbb, 0x21, 0x00, 0x00, 0xc0, 0x21,
0x00, 0x00, 0xc1, 0x21, 0x00, 0x00, 0xc5, 0x21,
0x00, 0x00, 0xf7, 0x21, 0x00, 0x00, 0x19, 0x22,
0x00, 0x00, 0xf5, 0x22, 0x00, 0x00, 0x61, 0x23,
0x00, 0x00, 0x7b, 0x23, 0x00, 0x00, 0x7c, 0x23,
0x00, 0x00, 0x7e, 0x23, 0x00, 0x00, 0x7f, 0x23,
0x00, 0x00, 0x87, 0x23, 0x00, 0x00, 0x88, 0x23,
0x00, 0x00, 0x8a, 0x23, 0x00, 0x00, 0x8b, 0x23,
0x00, 0x00, 0x90, 0x23, 0x00, 0x00, 0x91, 0x23,
0x00, 0x00, 0x96, 0x23, 0x00, 0x00, 0x97, 0x23,
0x00, 0x00, 0x99, 0x23, 0x00, 0x00, 0x9a, 0x23,
0x00, 0x00, 0xa2, 0x23, 0x00, 0x00, 0xa3, 0x23,
0x00, 0x00, 0xa5, 0x23, 0x00, 0x00, 0xa6, 0x23,
0x00, 0x00, 0xa8, 0x23, 0x00, 0x00, 0xa9, 0x23,
0x00, 0x00, 0xbd, 0x23, 0x00, 0x00, 0xbe, 0x23,
0x00, 0x00, 0xc0, 0x23, 0x00, 0x00, 0xc1, 0x23,
0x00, 0x00, 0xc6, 0x23, 0x00, 0x00, 0xc7, 0x23,
0x00, 0x00, 0xd0, 0x23, 0x00, 0x00, 0xdb, 0x23,
0x00, 0x00, 0xdc, 0x23, 0x00, 0x00, 0xde, 0x23,
0x00, 0x00, 0xdf, 0x23, 0x00, 0x00, 0xe4, 0x23,
0x00, 0x00, 0xe5, 0x23, 0x00, 0x00, 0xe7, 0x23,
0x00, 0x00, 0xe8, 0x23, 0x00, 0x00, 0xea, 0x23,
0x00, 0x00, 0xeb, 0x23, 0x00, 0x00, 0xed, 0x23,
0x00, 0x00, 0xee, 0x23, 0x00, 0x00, 0xef, 0x23,
0x00, 0x00, 0x1b, 0x24, 0x00, 0x00, 0x1c, 0x24,
0x00, 0x00, 0x50, 0x24, 0x00, 0x00, 0x52, 0x24,
0x00, 0x00, 0x60, 0x24, 0x00, 0x00, 0x6e, 0x24,
0x00, 0x00, 0x6f, 0x24, 0x00, 0x00, 0x76, 0x24,
0x00, 0x00, 0x77, 0x24, 0x00, 0x00, 0x7a, 0x24,
0x00, 0x00, 0x7b, 0x24, 0x00, 0x00, 0x7e, 0x24,
0x00, 0x00, 0x7f, 0x24, 0x00, 0x00, 0x82, 0x24,
0x00, 0x00, 0x83, 0x24, 0x00, 0x00, 0x8a, 0x24,
0x00, 0x00, 0x8b, 0x24, 0x00, 0x00, 0x9e, 0x24,
0x00, 0x00, 0x9f, 0x24, 0x00, 0x00, 0xa6, 0x24,
0x00, 0x00, 0xa7, 0x24, 0x00, 0x00, 0xae, 0x24,
0x00, 0x00, 0xaf, 0x24, 0x00, 0x00, 0xb2, 0x24,
0x00, 0x00, 0xb3, 0x24, 0x00, 0x00, 0xb6, 0x24,
0x00, 0x00, 0xb7, 0x24, 0x00, 0x00, 0xbe, 0x24,
0x00, 0x00, 0xbf, 0x24, 0x00, 0x00, 0xc2, 0x24,
0x00, 0x00, 0xc3, 0x24, 0x00, 0x00, 0xc6, 0x24,
0x00, 0x00, 0xc7, 0x24, 0x00, 0x00, 0xca, 0x24,
0x00, 0x00, 0xcb, 0x24, 0x00, 0x00, 0xd2, 0x24,
0x00, 0x00, 0xd3, 0x24, 0x00, 0x00, 0xe6, 0x24,
0x00, 0x00, 0xe7, 0x24, 0x00, 0x00, 0xee, 0x24,
0x00, 0x00, 0xef, 0x24, 0x00, 0x00, 0xf6, 0x24,
0x00, 0x00, 0xf7, 0x24, 0x00, 0x00, 0xfa, 0x24,
0x00, 0x00, 0xfb, 0x24, 0x00, 0x00, 0xfe, 0x24,
0x00, 0x00, 0xff, 0x24, 0x00, 0x00, 0x06, 0x25,
0x00, 0x00, 0x07, 0x25, 0x00, 0x00, 0x0a, 0x25,
0x00, 0x00, 0x0b, 0x25, 0x00, 0x00, 0x0e, 0x25,
0x00, 0x00, 0x0f, 0x25, 0x00, 0x00, 0x12, 0x25,
0x00, 0x00, 0x13, 0x25, 0x00, 0x00, 0x1a, 0x25,
0x00, 0x00, 0x1b, 0x25, 0x00, 0x00, 0x2e, 0x25,
0x00, 0x00, 0x2f, 0x25, 0x00, 0x00, 0x36, 0x25,
0x00, 0x00, 0x37, 0x25, 0x00, 0x00, 0x3e, 0x25,
0x00, 0x00, 0x3f, 0x25, 0x00, 0x00, 0x42, 0x25,
0x00, 0x00, 0x43, 0x25, 0x00, 0x00, 0x46, 0x25,
0x00, 0x00, 0x47, 0x25, 0x00, 0x00, 0x4e, 0x25,
0x00, 0x00, 0x4f, 0x25, 0x00, 0x00, 0x52, 0x25 });

            session.SendRaw(new byte[] { 0x00, 0x00, 0x53, 0x25, 0x00, 0x00, 0x56, 0x25,
0x00, 0x00, 0x57, 0x25, 0x00, 0x00, 0x5a, 0x25,
0x00, 0x00, 0x5b, 0x25, 0x00, 0x00, 0x62, 0x25,
0x00, 0x00, 0x63, 0x25, 0x00, 0x00, 0x76, 0x25,
0x00, 0x00, 0x77, 0x25, 0x00, 0x00, 0x7e, 0x25,
0x00, 0x00, 0x7f, 0x25, 0x00, 0x00, 0x86, 0x25,
0x00, 0x00, 0x87, 0x25, 0x00, 0x00, 0x8a, 0x25,
0x00, 0x00, 0x8b, 0x25, 0x00, 0x00, 0x8e, 0x25,
0x00, 0x00, 0x8f, 0x25, 0x00, 0x00, 0x96, 0x25,
0x00, 0x00, 0x97, 0x25, 0x00, 0x00, 0x9a, 0x25,
0x00, 0x00, 0x9b, 0x25, 0x00, 0x00, 0x9e, 0x25,
0x00, 0x00, 0x9f, 0x25, 0x00, 0x00, 0xa2, 0x25,
0x00, 0x00, 0xa3, 0x25, 0x00, 0x00, 0xaa, 0x25,
0x00, 0x00, 0xab, 0x25, 0x00, 0x00, 0xbe, 0x25,
0x00, 0x00, 0xbf, 0x25, 0x00, 0x00, 0xc6, 0x25,
0x00, 0x00, 0xc7, 0x25, 0x00, 0x00, 0xce, 0x25,
0x00, 0x00, 0xcf, 0x25, 0x00, 0x00, 0xd2, 0x25,
0x00, 0x00, 0xd3, 0x25, 0x00, 0x00, 0xd6, 0x25,
0x00, 0x00, 0xd7, 0x25, 0x00, 0x00, 0xde, 0x25,
0x00, 0x00, 0xdf, 0x25, 0x00, 0x00, 0xe2, 0x25,
0x00, 0x00, 0xe3, 0x25, 0x00, 0x00, 0xe6, 0x25,
0x00, 0x00, 0xe7, 0x25, 0x00, 0x00, 0xea, 0x25,
0x00, 0x00, 0xeb, 0x25, 0x00, 0x00, 0xf2, 0x25,
0x00, 0x00, 0xf3, 0x25, 0x00, 0x00, 0x06, 0x26,
0x00, 0x00, 0x07, 0x26, 0x00, 0x00, 0x0e, 0x26,
0x00, 0x00, 0x0f, 0x26, 0x00, 0x00, 0x16, 0x26,
0x00, 0x00, 0x17, 0x26, 0x00, 0x00, 0x1a, 0x26,
0x00, 0x00, 0x1b, 0x26, 0x00, 0x00, 0x9a, 0x26,
0x00, 0x00, 0x9b, 0x26, 0x00, 0x00, 0xf7, 0x26,
0x00, 0x00, 0xf8, 0x26, 0x00, 0x00, 0x5c, 0x27,
0x00, 0x00, 0x0e, 0x28, 0x00, 0x00, 0x0f, 0x28,
0x00, 0x00, 0x16, 0x28, 0x00, 0x00, 0x17, 0x28,
0x00, 0x00, 0x1a, 0x28, 0x00, 0x00, 0x1b, 0x28,
0x00, 0x00, 0x1e, 0x28, 0x00, 0x00, 0x1f, 0x28,
0x00, 0x00, 0x22, 0x28, 0x00, 0x00, 0x23, 0x28,
0x00, 0x00, 0x2a, 0x28, 0x00, 0x00, 0x2b, 0x28,
0x00, 0x00, 0x3e, 0x28, 0x00, 0x00, 0x3f, 0x28,
0x00, 0x00, 0x46, 0x28, 0x00, 0x00, 0x47, 0x28,
0x00, 0x00, 0x4e, 0x28, 0x00, 0x00, 0x4f, 0x28,
0x00, 0x00, 0x52, 0x28, 0x00, 0x00, 0x53, 0x28,
0x00, 0x00, 0xfe, 0x28, 0x00, 0x00, 0x81, 0x29,
0x00, 0x00, 0x83, 0x29, 0x00, 0x00, 0x9b, 0x29,
0x00, 0x00, 0x9c, 0x29, 0x00, 0x00, 0x9f, 0x29,
0x00, 0x00, 0xa0, 0x29, 0x00, 0x00, 0xa7, 0x29,
0x00, 0x00, 0xa8, 0x29, 0x00, 0x00, 0xaf, 0x29,
0x00, 0x00, 0xb0, 0x29, 0x00, 0x00, 0xb3, 0x29,
0x00, 0x00, 0xb4, 0x29, 0x00, 0x00, 0xbb, 0x29,
0x00, 0x00, 0xbc, 0x29, 0x00, 0x00, 0xc3, 0x29,
0x00, 0x00, 0xc4, 0x29, 0x00, 0x00, 0xcf, 0x29,
0x00, 0x00, 0xd0, 0x29, 0x00, 0x00, 0xdb, 0x29,
0x00, 0x00, 0xdc, 0x29, 0x00, 0x00, 0xdf, 0x29,
0x00, 0x00, 0xe0, 0x29, 0x00, 0x00, 0xe8, 0x29,
0x00, 0x00, 0xe9, 0x29, 0x00, 0x00, 0xf7, 0x29,
0x00, 0x00, 0xf8, 0x29, 0x00, 0x00, 0xff, 0x29,
0x00, 0x00, 0x00, 0x2a, 0x00, 0x00, 0x03, 0x2a,
0x00, 0x00, 0x04, 0x2a, 0x00, 0x00, 0x07, 0x2a,
0x00, 0x00, 0x08, 0x2a, 0x00, 0x00, 0x17, 0x2a,
0x00, 0x00, 0x18, 0x2a, 0x00, 0x00, 0x1b, 0x2a,
0x00, 0x00, 0x1c, 0x2a, 0x00, 0x00, 0x1f, 0x2a,
0x00, 0x00, 0x20, 0x2a, 0x00, 0x00, 0x23, 0x2a,
0x00, 0x00, 0x24, 0x2a, 0x00, 0x00, 0x27, 0x2a,
0x00, 0x00, 0x28, 0x2a, 0x00, 0x00, 0x2b, 0x2a,
0x00, 0x00, 0x2c, 0x2a, 0x00, 0x00, 0x2f, 0x2a,
0x00, 0x00, 0x30, 0x2a, 0x00, 0x00, 0x37, 0x2a,
0x00, 0x00, 0x38, 0x2a, 0x00, 0x00, 0x3b, 0x2a,
0x00, 0x00, 0x3c, 0x2a, 0x00, 0x00, 0x3f, 0x2a,
0x00, 0x00, 0x40, 0x2a, 0x00, 0x00, 0x43, 0x2a,
0x00, 0x00, 0x44, 0x2a, 0x00, 0x00, 0x47, 0x2a,
0x00, 0x00, 0x48, 0x2a, 0x00, 0x00, 0x4b, 0x2a,
0x00, 0x00, 0x4c, 0x2a, 0x00, 0x00, 0x70, 0x2a,
0x00, 0x00, 0x74, 0x2a, 0x00, 0x00, 0x0f, 0x2b,
0x00, 0x00, 0x10, 0x2b, 0x00, 0x00, 0x12, 0x2b,
0x00, 0x00, 0x13, 0x2b, 0x00, 0x00, 0x15, 0x2b,
0x00, 0x00, 0x16, 0x2b, 0x00, 0x00, 0x18, 0x2b,
0x00, 0x00, 0x19, 0x2b, 0x00, 0x00, 0x1b, 0x2b,
0x00, 0x00, 0x1c, 0x2b, 0x00, 0x00, 0x30, 0x2b,
0x00, 0x00, 0x31, 0x2b, 0x00, 0x00, 0x33, 0x2b,
0x00, 0x00, 0x34, 0x2b, 0x00, 0x00, 0x36, 0x2b,
0x00, 0x00, 0x37, 0x2b, 0x00, 0x00, 0x39, 0x2b,
0x00, 0x00, 0x3a, 0x2b, 0x00, 0x00, 0x3c, 0x2b,
0x00, 0x00, 0x3d, 0x2b, 0x00, 0x00, 0x66, 0x2c,
0x00, 0x00, 0x6b, 0x2c, 0x00, 0x00, 0x6d, 0x2c,
0x00, 0x00, 0x6e, 0x2c, 0x00, 0x00, 0x75, 0x2c,
0x00, 0x00, 0x76, 0x2c, 0x00, 0x00, 0x79, 0x2c,
0x00, 0x00, 0x7a, 0x2c, 0x00, 0x00, 0x7d, 0x2c,
0x00, 0x00, 0x7e, 0x2c, 0x00, 0x00, 0x81, 0x2c,
0x00, 0x00, 0x82, 0x2c, 0x00, 0x00, 0x89, 0x2c,
0x00, 0x00, 0x8a, 0x2c, 0x00, 0x00, 0x9d, 0x2c,
0x00, 0x00, 0x9e, 0x2c, 0x00, 0x00, 0xa5, 0x2c,
0x00, 0x00, 0xa6, 0x2c, 0x00, 0x00, 0xad, 0x2c,
0x00, 0x00, 0xae, 0x2c, 0x00, 0x00, 0xb1, 0x2c,
0x00, 0x00, 0xb2, 0x2c, 0x00, 0x00, 0xb5, 0x2c,
0x00, 0x00, 0xb6, 0x2c, 0x00, 0x00, 0xb9, 0x2c,
0x00, 0x00, 0xba, 0x2c, 0x00, 0x00, 0xc1, 0x2c,
0x00, 0x00, 0xc2, 0x2c, 0x00, 0x00, 0xc5, 0x2c,
0x00, 0x00, 0xc6, 0x2c, 0x00, 0x00, 0xc9, 0x2c,
0x00, 0x00, 0xca, 0x2c, 0x00, 0x00, 0xcd, 0x2c,
0x00, 0x00, 0xce, 0x2c, 0x00, 0x00, 0xd5, 0x2c,
0x00, 0x00, 0xd6, 0x2c, 0x00, 0x00, 0xe9, 0x2c,
0x00, 0x00, 0xea, 0x2c, 0x00, 0x00, 0xf1, 0x2c,
0x00, 0x00, 0xf2, 0x2c, 0x00, 0x00, 0xf9, 0x2c,
0x00, 0x00, 0xfa, 0x2c, 0x00, 0x00, 0xfd, 0x2c,
0x00, 0x00, 0xfe, 0x2c, 0x00, 0x00, 0x01, 0x2d,
0x00, 0x00, 0x02, 0x2d, 0x00, 0x00, 0x1a, 0x2d,
0x00, 0x00, 0x1b, 0x2d, 0x00, 0x00, 0x22, 0x2d,
0x00, 0x00, 0x23, 0x2d, 0x00, 0x00, 0x26, 0x2d,
0x00, 0x00, 0x27, 0x2d, 0x00, 0x00, 0x2a, 0x2d,
0x00, 0x00, 0x2b, 0x2d, 0x00, 0x00, 0x2e, 0x2d,
0x00, 0x00, 0x2f, 0x2d, 0x00, 0x00, 0x36, 0x2d,
0x00, 0x00, 0x37, 0x2d, 0x00, 0x00, 0x4a, 0x2d,
0x00, 0x00, 0x4b, 0x2d, 0x00, 0x00, 0x52, 0x2d,
0x00, 0x00, 0x53, 0x2d, 0x00, 0x00, 0x5a, 0x2d,
0x00, 0x00, 0x5b, 0x2d, 0x00, 0x00, 0x5e, 0x2d,
0x00, 0x00, 0x5f, 0x2d, 0x00, 0x00, 0x62, 0x2d,
0x00, 0x00, 0x63, 0x2d, 0x00, 0x00, 0x01, 0x2e,
0x00, 0x00, 0x0c, 0x2e, 0x00, 0x00, 0x0d, 0x2e,
0x00, 0x00, 0x0e, 0x2e, 0x00, 0x00, 0x28, 0x2e,
0x00, 0x00, 0x2e, 0x2e, 0x00, 0x00, 0x2f, 0x2e,
0x00, 0x00, 0x34, 0x2e, 0x00, 0x00, 0x35, 0x2e,
0x00, 0x00, 0x40, 0x2e, 0x00, 0x00, 0x41, 0x2e,
0x00, 0x00, 0x46, 0x2e, 0x00, 0x00, 0x47, 0x2e,
0x00, 0x00, 0xe8, 0x2e, 0x00, 0x00, 0xe9, 0x2e,
0x00, 0x00, 0xf0, 0x2e, 0x00, 0x00, 0xf1, 0x2e,
0x00, 0x00, 0xf4, 0x2e, 0x00, 0x00, 0xf5, 0x2e,
0x00, 0x00, 0xf8, 0x2e, 0x00, 0x00, 0xf9, 0x2e,
0x00, 0x00, 0xfc, 0x2e, 0x00, 0x00, 0xfd, 0x2e,
0x00, 0x00, 0x04, 0x2f, 0x00, 0x00, 0x05, 0x2f,
0x00, 0x00, 0x18, 0x2f, 0x00, 0x00, 0x19, 0x2f,
0x00, 0x00, 0x20, 0x2f, 0x00, 0x00, 0x21, 0x2f,
0x00, 0x00, 0x28, 0x2f, 0x00, 0x00, 0x29, 0x2f,
0x00, 0x00, 0x2c, 0x2f, 0x00, 0x00, 0x2d, 0x2f,
0x00, 0x00, 0x30, 0x2f, 0x00, 0x00, 0x31, 0x2f,
0x00, 0x00, 0x33, 0x2f, 0x00, 0x00, 0xf2, 0x2f,
0x00, 0x00, 0xf3, 0x2f, 0x00, 0x00, 0x49, 0x30,
0x00, 0x00, 0x52, 0x30, 0x00, 0x00, 0x53, 0x30,
0x00, 0x00, 0x5a, 0x30, 0x00, 0x00, 0x5b, 0x30,
0x00, 0x00, 0x62, 0x30, 0x00, 0x00, 0x63, 0x30,
0x00, 0x00, 0x66, 0x30, 0x00, 0x00, 0x67, 0x30,
0x00, 0x00, 0x6e, 0x30, 0x00, 0x00, 0x6f, 0x30,
0x00, 0x00, 0x82, 0x30, 0x00, 0x00, 0x83, 0x30,
0x00, 0x00, 0x92, 0x30, 0x00, 0x00, 0x93, 0x30,
0x00, 0x00, 0x96, 0x30, 0x00, 0x00, 0x97, 0x30,
0x00, 0x00, 0x9a, 0x30, 0x00, 0x00, 0x9b, 0x30,
0x00, 0x00, 0x9e, 0x30, 0x00, 0x00, 0x9f, 0x30,
0x00, 0x00, 0xa6, 0x30, 0x00, 0x00, 0xa7, 0x30,
0x00, 0x00, 0xae, 0x30, 0x00, 0x00, 0xaf, 0x30,
0x00, 0x00, 0xb2, 0x30, 0x00, 0x00, 0xb3, 0x30,
0x00, 0x00, 0xba, 0x30, 0x00, 0x00, 0xbb, 0x30,
0x00, 0x00, 0xce, 0x30, 0x00, 0x00, 0xcf, 0x30,
0x00, 0x00, 0xde, 0x30, 0x00, 0x00, 0xdf, 0x30,
0x00, 0x00, 0xe2, 0x30, 0x00, 0x00, 0xe3, 0x30,
0x00, 0x00, 0xe6, 0x30, 0x00, 0x00, 0xe7, 0x30,
0x00, 0x00, 0xea, 0x30, 0x00, 0x00, 0xeb, 0x30,
0x00, 0x00, 0xf2, 0x30, 0x00, 0x00, 0xf3, 0x30,
0x00, 0x00, 0xfa, 0x30, 0x00, 0x00, 0xfb, 0x30,
0x00, 0x00, 0xfe, 0x30, 0x00, 0x00, 0xff, 0x30,
0x00, 0x00, 0x06, 0x31, 0x00, 0x00, 0x07, 0x31,
0x00, 0x00, 0x1a, 0x31, 0x00, 0x00, 0x1b, 0x31,
0x00, 0x00, 0x2a, 0x31, 0x00, 0x00, 0x2b, 0x31,
0x00, 0x00, 0x2e, 0x31, 0x00, 0x00, 0x2f, 0x31,
0x00, 0x00, 0x32, 0x31, 0x00, 0x00, 0x33, 0x31,
0x00, 0x00, 0x36, 0x31, 0x00, 0x00, 0x37, 0x31,
0x00, 0x00, 0x3e, 0x31, 0x00, 0x00, 0x3f, 0x31,
0x00, 0x00, 0x46, 0x31, 0x00, 0x00, 0x47, 0x31,
0x00, 0x00, 0x4a, 0x31, 0x00, 0x00, 0x4b, 0x31,
0x00, 0x00, 0x52, 0x31, 0x00, 0x00, 0x53, 0x31,
0x00, 0x00, 0x66, 0x31, 0x00, 0x00, 0x67, 0x31,
0x00, 0x00, 0x76, 0x31, 0x00, 0x00, 0x77, 0x31,
0x00, 0x00, 0x7a, 0x31, 0x00, 0x00, 0x7b, 0x31,
0x00, 0x00, 0x7e, 0x31, 0x00, 0x00, 0x7f, 0x31,
0x00, 0x00, 0x82, 0x31, 0x00, 0x00, 0x83, 0x31,
0x00, 0x00, 0x8a, 0x31, 0x00, 0x00, 0x8b, 0x31,
0x00, 0x00, 0x92, 0x31, 0x00, 0x00, 0x93, 0x31,
0x00, 0x00, 0x96, 0x31, 0x00, 0x00, 0x97, 0x31,
0x00, 0x00, 0x9e, 0x31, 0x00, 0x00, 0x9f, 0x31});

            session.SendRaw(new byte[] { 0x00, 0x00, 0xb2, 0x31, 0x00, 0x00, 0xb3, 0x31,
0x00, 0x00, 0xc2, 0x31, 0x00, 0x00, 0xc3, 0x31,
0x00, 0x00, 0xc6, 0x31, 0x00, 0x00, 0xc7, 0x31,
0x00, 0x00, 0xca, 0x31, 0x00, 0x00, 0xcb, 0x31,
0x00, 0x00, 0xce, 0x31, 0x00, 0x00, 0xcf, 0x31,
0x00, 0x00, 0xd6, 0x31, 0x00, 0x00, 0xd7, 0x31,
0x00, 0x00, 0xde, 0x31, 0x00, 0x00, 0xdf, 0x31,
0x00, 0x00, 0xe2, 0x31, 0x00, 0x00, 0xe3, 0x31,
0x00, 0x00, 0xea, 0x31, 0x00, 0x00, 0xeb, 0x31,
0x00, 0x00, 0xfe, 0x31, 0x00, 0x00, 0xff, 0x31,
0x00, 0x00, 0x0e, 0x32, 0x00, 0x00, 0x0f, 0x32,
0x00, 0x00, 0x12, 0x32, 0x00, 0x00, 0x13, 0x32,
0x00, 0x00, 0x16, 0x32, 0x00, 0x00, 0x17, 0x32,
0x00, 0x00, 0x1a, 0x32, 0x00, 0x00, 0x1b, 0x32,
0x00, 0x00, 0x22, 0x32, 0x00, 0x00, 0x23, 0x32,
0x00, 0x00, 0x2a, 0x32, 0x00, 0x00, 0x2b, 0x32,
0x00, 0x00, 0x2e, 0x32, 0x00, 0x00, 0x2f, 0x32,
0x00, 0x00, 0x36, 0x32, 0x00, 0x00, 0x37, 0x32,
0x00, 0x00, 0x4a, 0x32, 0x00, 0x00, 0x4b, 0x32,
0x00, 0x00, 0x5a, 0x32, 0x00, 0x00, 0x5b, 0x32,
0x00, 0x00, 0x5e, 0x32, 0x00, 0x00, 0x5f, 0x32,
0x00, 0x00, 0x62, 0x32, 0x00, 0x00, 0x63, 0x32,
0x00, 0x00, 0x6c, 0x32, 0x00, 0x00, 0x70, 0x32,
0x00, 0x00, 0x8b, 0x32, 0x00, 0x00, 0x9f, 0x32,
0x00, 0x00, 0xa0, 0x32, 0x00, 0x00, 0xa9, 0x32,
0x00, 0x00, 0x1a, 0x33, 0x00, 0x00, 0x1f, 0x33,
0x00, 0x00, 0x49, 0x33, 0x00, 0x00, 0x5c, 0x33,
0x00, 0x00, 0x23, 0x35, 0x00, 0x00, 0x2a, 0x35,
0x00, 0x00, 0x52, 0x35, 0x00, 0x00, 0x57, 0x35,
0x00, 0x00, 0x84, 0x35, 0x00, 0x00, 0x40, 0x36,
0x00, 0x00, 0x9f, 0x36, 0x00, 0x00, 0x16, 0x38,
0x00, 0x00, 0x71, 0x39, 0x00, 0x00, 0x5e, 0x40,
0x00, 0x00, 0x67, 0x40, 0x00, 0x00, 0x84, 0x40,
0x00, 0x00, 0x9d, 0x40, 0x00, 0x00, 0x9e, 0x40,
0x00, 0x00, 0xae, 0x40, 0x00, 0x00, 0xaf, 0x40,
0x00, 0x00, 0x12, 0x41, 0x00, 0x00, 0x2f, 0x41,
0x00, 0x00, 0xb0, 0x46, 0x00, 0x00, 0xb1, 0x46,
0x00, 0x00, 0xa6, 0x47, 0x00, 0x00, 0x20, 0x48,
0x00, 0x00, 0x21, 0x48, 0x00, 0x00, 0x6b, 0x48,
0x00, 0x00, 0x6c, 0x48, 0x00, 0x00, 0x75, 0x48,
0x00, 0x00, 0x76, 0x48, 0x00, 0x00, 0x7a, 0x48,
0x00, 0x00, 0x7b, 0x48, 0x00, 0x00, 0x7f, 0x48,
0x00, 0x00, 0x80, 0x48, 0x00, 0x00, 0x84, 0x48,
0x00, 0x00, 0x85, 0x48, 0x00, 0x00, 0x8e, 0x48,
0x00, 0x00, 0x8f, 0x48, 0x00, 0x00, 0xa7, 0x48,
0x00, 0x00, 0xa8, 0x48, 0x00, 0x00, 0xb1, 0x48,
0x00, 0x00, 0xb2, 0x48, 0x00, 0x00, 0xbb, 0x48,
0x00, 0x00, 0xbc, 0x48, 0x00, 0x00, 0xc0, 0x48,
0x00, 0x00, 0xc1, 0x48, 0x00, 0x00, 0xc5, 0x48,
0x00, 0x00, 0xc6, 0x48, 0x00, 0x00, 0xc8, 0x48,
0x00, 0x00, 0xcd, 0x48, 0x00, 0x00, 0xd2, 0x48,
0x00, 0x00, 0xdf, 0x48, 0x00, 0x00, 0xe2, 0x48,
0x00, 0x00, 0xe3, 0x48, 0x00, 0x00, 0x4b, 0x4a,
0x00, 0x00, 0x52, 0x4a, 0x00, 0x00, 0x53, 0x4a,
0x00, 0x00, 0x5c, 0x4a, 0x00, 0x00, 0x5d, 0x4a,
0x00, 0x00, 0x61, 0x4a, 0x00, 0x00, 0x62, 0x4a,
0x00, 0x00, 0x66, 0x4a, 0x00, 0x00, 0x67, 0x4a,
0x00, 0x00, 0x6b, 0x4a, 0x00, 0x00, 0x6c, 0x4a,
0x00, 0x00, 0x75, 0x4a, 0x00, 0x00, 0x76, 0x4a,
0x00, 0x00, 0x8e, 0x4a, 0x00, 0x00, 0x8f, 0x4a,
0x00, 0x00, 0x98, 0x4a, 0x00, 0x00, 0x99, 0x4a,
0x00, 0x00, 0xa2, 0x4a, 0x00, 0x00, 0xa3, 0x4a,
0x00, 0x00, 0xa7, 0x4a, 0x00, 0x00, 0xa8, 0x4a,
0x00, 0x00, 0xac, 0x4a, 0x00, 0x00, 0xad, 0x4a,
0x00, 0x00, 0xc4, 0x4a, 0x00, 0x00, 0xc5, 0x4a,
0x00, 0x00, 0xce, 0x4a, 0x00, 0x00, 0xcf, 0x4a,
0x00, 0x00, 0xd3, 0x4a, 0x00, 0x00, 0xd4, 0x4a,
0x00, 0x00, 0xd8, 0x4a, 0x00, 0x00, 0xd9, 0x4a,
0x00, 0x00, 0xdd, 0x4a, 0x00, 0x00, 0xde, 0x4a,
0x00, 0x00, 0xe7, 0x4a, 0x00, 0x00, 0xe8, 0x4a,
0x00, 0x00, 0x00, 0x4b, 0x00, 0x00, 0x01, 0x4b,
0x00, 0x00, 0x0a, 0x4b, 0x00, 0x00, 0x0b, 0x4b,
0x00, 0x00, 0x14, 0x4b, 0x00, 0x00, 0x15, 0x4b,
0x00, 0x00, 0x19, 0x4b, 0x00, 0x00, 0x1a, 0x4b,
0x00, 0x00, 0x1e, 0x4b, 0x00, 0x00, 0x1f, 0x4b,
0x00, 0x00, 0x35, 0x4b, 0x00, 0x00, 0x3a, 0x4b,
0x00, 0x00, 0x49, 0x4b, 0x00, 0x00, 0x53, 0x4b,
0x00, 0x00, 0x5c, 0x4b, 0x00, 0x00, 0x5d, 0x4b,
0x00, 0x00, 0x66, 0x4b, 0x00, 0x00, 0x67, 0x4b,
0x00, 0x00, 0x6b, 0x4b, 0x00, 0x00, 0x6c, 0x4b,
0x00, 0x00, 0x70, 0x4b, 0x00, 0x00, 0x71, 0x4b,
0x00, 0x00, 0x75, 0x4b, 0x00, 0x00, 0x76, 0x4b,
0x00, 0x00, 0x7f, 0x4b, 0x00, 0x00, 0x80, 0x4b,
0x00, 0x00, 0x98, 0x4b, 0x00, 0x00, 0x99, 0x4b,
0x00, 0x00, 0xa2, 0x4b, 0x00, 0x00, 0xa3, 0x4b,
0x00, 0x00, 0xac, 0x4b, 0x00, 0x00, 0xad, 0x4b,
0x00, 0x00, 0xb1, 0x4b, 0x00, 0x00, 0xb2, 0x4b,
0x00, 0x00, 0xb6, 0x4b, 0x00, 0x00, 0xb7, 0x4b,
0x00, 0x00, 0xe3, 0x4b, 0x00, 0x00, 0xe4, 0x4b,
0x00, 0x00, 0xe5, 0x4b, 0x00, 0x00, 0x1f, 0x4c,
0x00, 0x00, 0x27, 0x4c, 0x00, 0x00, 0x28, 0x4c,
0x00, 0x00, 0x2f, 0x4c, 0x00, 0x00, 0x30, 0x4c,
0x00, 0x00, 0x33, 0x4c, 0x00, 0x00, 0x34, 0x4c,
0x00, 0x00, 0x37, 0x4c, 0x00, 0x00, 0x38, 0x4c,
0x00, 0x00, 0x3b, 0x4c, 0x00, 0x00, 0x3c, 0x4c,
0x00, 0x00, 0x43, 0x4c, 0x00, 0x00, 0x44, 0x4c,
0x00, 0x00, 0x57, 0x4c, 0x00, 0x00, 0x58, 0x4c,
0x00, 0x00, 0x5f, 0x4c, 0x00, 0x00, 0x60, 0x4c,
0x00, 0x00, 0x67, 0x4c, 0x00, 0x00, 0x68, 0x4c,
0x00, 0x00, 0x6b, 0x4c, 0x00, 0x00, 0x6c, 0x4c,
0x00, 0x00, 0x6f, 0x4c, 0x00, 0x00, 0x70, 0x4c,
0x00, 0x00, 0x74, 0x4c, 0x00, 0x00, 0x75, 0x4c,
0x00, 0x00, 0x7e, 0x4c, 0x00, 0x00, 0x7f, 0x4c,
0x00, 0x00, 0x83, 0x4c, 0x00, 0x00, 0x84, 0x4c,
0x00, 0x00, 0x88, 0x4c, 0x00, 0x00, 0x89, 0x4c,
0x00, 0x00, 0x8d, 0x4c, 0x00, 0x00, 0x8e, 0x4c,
0x00, 0x00, 0x97, 0x4c, 0x00, 0x00, 0x98, 0x4c,
0x00, 0x00, 0xb0, 0x4c, 0x00, 0x00, 0xb1, 0x4c,
0x00, 0x00, 0xba, 0x4c, 0x00, 0x00, 0xbb, 0x4c,
0x00, 0x00, 0xc4, 0x4c, 0x00, 0x00, 0xc5, 0x4c,
0x00, 0x00, 0xc9, 0x4c, 0x00, 0x00, 0xca, 0x4c,
0x00, 0x00, 0xce, 0x4c, 0x00, 0x00, 0xcf, 0x4c,
0x00, 0x00, 0xcd, 0x4d, 0x00, 0x00, 0x4d, 0x53,
0x00, 0x00, 0x4e, 0x53, 0x00, 0x00, 0x44, 0x55,
0x00, 0x00, 0xf4, 0x55, 0x00, 0x00, 0x17, 0x56,
0x00, 0x00, 0x1f, 0x59, 0x00, 0x00, 0x20, 0x59,
0x00, 0x00, 0x29, 0x59, 0x00, 0x00, 0x2a, 0x59,
0x00, 0x00, 0x2e, 0x59, 0x00, 0x00, 0x2f, 0x59,
0x00, 0x00, 0x33, 0x59, 0x00, 0x00, 0x34, 0x59,
0x00, 0x00, 0x38, 0x59, 0x00, 0x00, 0x39, 0x59,
0x00, 0x00, 0x42, 0x59, 0x00, 0x00, 0x43, 0x59,
0x00, 0x00, 0x5b, 0x59, 0x00, 0x00, 0x5c, 0x59,
0x00, 0x00, 0x65, 0x59, 0x00, 0x00, 0x66, 0x59,
0x00, 0x00, 0x6f, 0x59, 0x00, 0x00, 0x70, 0x59,
0x00, 0x00, 0x74, 0x59, 0x00, 0x00, 0x75, 0x59,
0x00, 0x00, 0x79, 0x59, 0x00, 0x00, 0x7a, 0x59,
0x00, 0x00, 0x7e, 0x59, 0x00, 0x00, 0x7f, 0x59,
0x00, 0x00, 0x88, 0x59, 0x00, 0x00, 0x89, 0x59,
0x00, 0x00, 0x8d, 0x59, 0x00, 0x00, 0x8e, 0x59,
0x00, 0x00, 0x92, 0x59, 0x00, 0x00, 0x93, 0x59,
0x00, 0x00, 0x97, 0x59, 0x00, 0x00, 0x98, 0x59,
0x00, 0x00, 0xa1, 0x59, 0x00, 0x00, 0xa2, 0x59,
0x00, 0x00, 0xba, 0x59, 0x00, 0x00, 0xbb, 0x59,
0x00, 0x00, 0xc4, 0x59, 0x00, 0x00, 0xc5, 0x59,
0x00, 0x00, 0xce, 0x59, 0x00, 0x00, 0xcf, 0x59,
0x00, 0x00, 0xd3, 0x59, 0x00, 0x00, 0xd4, 0x59,
0x00, 0x00, 0xd8, 0x59, 0x00, 0x00, 0xd9, 0x59,
0x00, 0x00, 0xdd, 0x59, 0x00, 0x00, 0xde, 0x59,
0x00, 0x00, 0xe7, 0x59, 0x00, 0x00, 0xe8, 0x59,
0x00, 0x00, 0xec, 0x59, 0x00, 0x00, 0xed, 0x59,
0x00, 0x00, 0xf1, 0x59, 0x00, 0x00, 0xf2, 0x59,
0x00, 0x00, 0xf6, 0x59, 0x00, 0x00, 0xf7, 0x59,
0x00, 0x00, 0x00, 0x5a, 0x00, 0x00, 0x01, 0x5a,
0x00, 0x00, 0x19, 0x5a, 0x00, 0x00, 0x1a, 0x5a,
0x00, 0x00, 0x23, 0x5a, 0x00, 0x00, 0x24, 0x5a,
0x00, 0x00, 0x2d, 0x5a, 0x00, 0x00, 0x2e, 0x5a,
0x00, 0x00, 0x32, 0x5a, 0x00, 0x00, 0x33, 0x5a,
0x00, 0x00, 0x37, 0x5a, 0x00, 0x00, 0x38, 0x5a,
0x00, 0x00, 0x3c, 0x5a, 0x00, 0x00, 0x3d, 0x5a,
0x00, 0x00, 0x46, 0x5a, 0x00, 0x00, 0x47, 0x5a,
0x00, 0x00, 0x4b, 0x5a, 0x00, 0x00, 0x4c, 0x5a,
0x00, 0x00, 0x50, 0x5a, 0x00, 0x00, 0x51, 0x5a,
0x00, 0x00, 0x55, 0x5a, 0x00, 0x00, 0x56, 0x5a,
0x00, 0x00, 0x5f, 0x5a, 0x00, 0x00, 0x60, 0x5a,
0x00, 0x00, 0x78, 0x5a, 0x00, 0x00, 0x79, 0x5a,
0x00, 0x00, 0x82, 0x5a, 0x00, 0x00, 0x83, 0x5a,
0x00, 0x00, 0x8c, 0x5a, 0x00, 0x00, 0x8d, 0x5a,
0x00, 0x00, 0x91, 0x5a, 0x00, 0x00, 0x92, 0x5a,
0x00, 0x00, 0x96, 0x5a, 0x00, 0x00, 0x97, 0x5a,
0x00, 0x00, 0x9b, 0x5a, 0x00, 0x00, 0x9c, 0x5a,
0x00, 0x00, 0xa5, 0x5a, 0x00, 0x00, 0xa6, 0x5a,
0x00, 0x00, 0xaa, 0x5a, 0x00, 0x00, 0xab, 0x5a,
0x00, 0x00, 0xaf, 0x5a, 0x00, 0x00, 0xb0, 0x5a,
0x00, 0x00, 0xb4, 0x5a, 0x00, 0x00, 0xb5, 0x5a,
0x00, 0x00, 0xbe, 0x5a, 0x00, 0x00, 0xbf, 0x5a,
0x00, 0x00, 0xd7, 0x5a, 0x00, 0x00, 0xd8, 0x5a,
0x00, 0x00, 0xe1, 0x5a, 0x00, 0x00, 0xe2, 0x5a,
0x00, 0x00, 0xeb, 0x5a, 0x00, 0x00, 0xec, 0x5a,
0x00, 0x00, 0xf0, 0x5a, 0x00, 0x00, 0xf1, 0x5a,
0x00, 0x00, 0xf5, 0x5a, 0x00, 0x00, 0xf6, 0x5a,
0x00, 0x00, 0x0c, 0x5b, 0x00, 0x00, 0x67, 0x5c,
0x00, 0x00, 0x68, 0x5c, 0x00, 0x00, 0x69, 0x5e,
0x00, 0x00, 0xb1, 0x5e, 0x00, 0x00, 0xb2, 0x5e,
0x00, 0x00, 0xbb, 0x5e, 0x00, 0x00, 0xbc, 0x5e,
0x00, 0x00, 0xc0, 0x5e, 0x00, 0x00, 0xc1, 0x5e });*/


        }


    }
}

