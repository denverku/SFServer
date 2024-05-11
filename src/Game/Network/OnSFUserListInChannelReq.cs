﻿using Shared.Network;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFUserListInChannelReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 204;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            session.SendRaw(new byte[] {0x10, 0x00, 0x00, 0x00, 0x6f, 0x00, 0xbb, 0xfc, 0xb7, 0x09, 0xdf, 0x61, 0xd1, 0x74, 0x94, 0x05, 0xda, 0x2b, 0xbc, 0x0f, 0x0d, 0x42});
            // user list with data
            /*session.SendRaw(new byte[] {0xb4, 0x00, 0x00, 0x00, 0xcd, 0x00, 0x05, 0x00,
0x05, 0x00, 0x9a, 0x06, 0x42, 0x6c, 0x61, 0x63,
0x6b, 0x48, 0x61, 0x77, 0x6b, 0x38, 0x32, 0x31,
0x00, 0x00, 0x00, 0x76, 0x00, 0x2a, 0x03, 0x00,
0x00, 0x1e, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x97, 0x06,
0x42, 0x6c, 0x61, 0x63, 0x6b, 0x45, 0x61, 0x67,
0x6c, 0x65, 0x50, 0x68, 0x00, 0x00, 0x00, 0x76,
0x00, 0x2a, 0x03, 0x00, 0x00, 0x1e, 0x04, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00,
0x00, 0x00, 0x99, 0x06, 0x44, 0x65, 0x4c, 0x74,
0x41, 0x5f, 0x30, 0x30, 0x30, 0x31, 0x00, 0x00,
0x00, 0x76, 0x00, 0xf4, 0x02, 0x00, 0x00, 0x02,
0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01,
0x00, 0x00, 0x00, 0x00, 0x98, 0x06, 0x52, 0x75,
0x73, 0x68, 0x65, 0x72, 0x5f, 0x78, 0x78, 0x78,
0x78, 0x31, 0x00, 0x00, 0x00, 0x76, 0x00, 0xf4,
0x02, 0x00, 0x00, 0x02, 0x04, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00,
0xa3, 0x06, 0x54, 0x72, 0x75, 0x6e, 0x6b, 0x73,
0x4b, 0x75, 0x32, 0x32, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00,
0x00, 0x00});*/
            // user list only one
            session.SendRaw(new byte[] { 0x26, 0x00, 0x00, 0x00, 0xcd, 0x00, 0x01, 0x00,
0x01, 0x00, 0x76, 0x07, 0x54, 0x72, 0x75, 0x6e,
0x6b, 0x73, 0x4b, 0x75, 0x32, 0x32, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01,
0x00, 0x00, 0x00, 0x00 });
            // room list
            session.SendRaw(new byte[] {0x42, 0x00, 0x00, 0x00, 0xcb, 0x00, 0x01, 0x00,
0x76, 0x00, 0x01, 0x00, 0x00, 0xca, 0xa7, 0xa4,
0xc3, 0xd2, 0xc1, 0xcd, 0xcd, 0xb9, 0xe4, 0xc5,
0xb9, 0xec, 0xe0, 0xc3, 0xd4, 0xe8, 0xc1, 0xe1,
0xc5, 0xe9, 0xc7, 0x00, 0x42, 0x6c, 0x61, 0x63,
0x6b, 0x48, 0x61, 0x77, 0x6b, 0x38, 0x32, 0x31,
0x00, 0x00, 0x04, 0x06, 0x01, 0x02, 0x01, 0x01,
0x2a, 0x03, 0x00, 0x00, 0x1e, 0x04, 0x00, 0x00,
0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            session.SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x2f, 0x01, 0x01, 0x00, 0x00 }); // yeah server display

            session.SendRaw(new byte[] { 0xa0, 0x00, 0x00, 0x00, 0xcf, 0x00, 0x04, 0x00,
0x42, 0x6c, 0x61, 0x63, 0x6b, 0x48, 0x61, 0x77,
0x6b, 0x38, 0x32, 0x31, 0x00, 0x00, 0xa7, 0xfb,
0x76, 0x84, 0x3f, 0x01, 0x2a, 0x03, 0x00, 0x00,
0x1e, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x52, 0x75,
0x73, 0x68, 0x65, 0x72, 0x5f, 0x78, 0x78, 0x78,
0x78, 0x31, 0x00, 0x00, 0xa2, 0xea, 0xd9, 0x6b,
0x3f, 0x00, 0xf4, 0x02, 0x00, 0x00, 0x02, 0x04,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00,
0x00, 0x00, 0x00, 0x00, 0x44, 0x65, 0x4c, 0x74,
0x41, 0x5f, 0x30, 0x30, 0x30, 0x31, 0x00, 0x00,
0xa1, 0x5a, 0x01, 0x67, 0x3f, 0x00, 0xf4, 0x02,
0x00, 0x00, 0x02, 0x04, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
0x42, 0x6c, 0x61, 0x63, 0x6b, 0x45, 0x61, 0x67,
0x6c, 0x65, 0x50, 0x68, 0x00, 0x00, 0xa2, 0x5d,
0x51, 0x73, 0x3f, 0x01, 0x2a, 0x03, 0x00, 0x00,
0x1e, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x01, 0x00, 0x00, 0x00, 0x00, 0x76, 0x00, 0x01,
0x05, 0x05, 0x00, 0x01, 0x01, 0x01});

            // i think info on lower yeah it is
            session.SendRaw(new byte[] { 0x55, 0x00, 0x00, 0x00, 0x5b, 0x02, 0xaa, 0xd8,
0xb4, 0xb6, 0xd2, 0xc7, 0xc3, 0xc1, 0xd5, 0xcd,
0xc2, 0xd9, 0xe8, 0xa8, 0xc3, 0xd4, 0xa7, 0x21,
0x21, 0x20, 0xc5, 0xd8, 0xe9, 0xb9, 0xaa, 0xd8,
0xb4, 0x20, 0x42, 0x6c, 0x61, 0x63, 0x6b, 0x20,
0x44, 0x72, 0x61, 0x67, 0x6f, 0x6e, 0x20, 0xb6,
0xd2, 0xc7, 0xc3, 0x20, 0xbc, 0xe8, 0xd2, 0xb9,
0xc3, 0xd0, 0xba, 0xba, 0x20, 0x53, 0x70, 0x65,
0x63, 0x69, 0x61, 0x6c, 0x20, 0x46, 0x6f, 0x72,
0x74, 0x75, 0x6e, 0x65, 0x20, 0xe4, 0xb4, 0xe9,
0xe1, 0xc5, 0xe9, 0xc7, 0xc7, 0xd1, 0xb9, 0xb9,
0xd5, 0xe9, 0x00});

            // test idk what is this
            /*session.SendRaw(new byte[] { 0x62, 0x00, 0x00, 0x00, 0x5b, 0x02, 0xcd, 0xc2,
0xe8, 0xd2, 0xc5, 0xd7, 0xc1, 0x21, 0x21, 0x20,
0xe0, 0xc5, 0xe8, 0xb9, 0xca, 0xd0, 0xca, 0xc1,
0xe0, 0xc7, 0xc5, 0xd2, 0x20, 0xe1, 0xc5, 0xa1,
0xe1, 0xb5, 0xe9, 0xc1, 0xc7, 0xd1, 0xb9, 0xb9,
0xd5, 0xe9, 0x20, 0xc5, 0xd8, 0xe9, 0xb9, 0xaa,
0xd8, 0xb4, 0x20, 0x42, 0x6c, 0x61, 0x63, 0x6b,
0x20, 0x44, 0x72, 0x61, 0x67, 0x6f, 0x6e, 0x20,
0xb6, 0xd2, 0xc7, 0xc3, 0xe4, 0xb4, 0xe9, 0xb7,
0xd5, 0xe8, 0xc3, 0xd0, 0xba, 0xba, 0x20, 0x53,
0x70, 0x65, 0x63, 0x69, 0x61, 0x6c, 0x20, 0x46,
0x6f, 0x72, 0x74, 0x75, 0x6e, 0x65, 0x20, 0xe0,
0xb7, 0xe8, 0xd2, 0xb9, 0xd1, 0xe9, 0xb9, 0x00 });*/

            

           
            
        }


    }
}
