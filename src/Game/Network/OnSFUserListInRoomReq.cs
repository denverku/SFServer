using Microsoft.VisualBasic;
using Shared.Network;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Network
{
    internal class OnSFUserListInRoomReq : BaseNetwork
    {
        public int ProtocolId()
        {
            return 6909;
        }

        public void Handle(Packet packet, Shared.Session.Session session)
        {
            /*Packet data = new Packet();
            data.WriteByte(0x44);
            data.WriteByte(0x46);
            data.WriteByte(0xfe);
            data.WriteByte(0x1a);

            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0xa6);
            data.WriteByte(0x01);
            data.WriteByte(0x44);
            data.WriteByte(0x4f);
            data.WriteByte(0x4f);
            data.WriteByte(0x46);
            data.WriteByte(0x45);
            data.WriteByte(0x4e);
            data.WriteByte(0x2d);
            data.WriteByte(0x00);
            data.WriteByte(0x23);
            data.WriteByte(0x39);
            data.WriteByte(0x39);
            data.WriteByte(0x39);
            data.WriteByte(0x39);
            data.WriteByte(0x46);
            data.WriteByte(0x46);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x22);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x4e);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0xfd);
            data.WriteByte(0x03);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x48);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x64);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x0e);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x7d);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x07);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x38);
            data.WriteByte(0x00);
            data.WriteByte(0x01);

            
            //data.WriteString("Mabuhay HAHAHA");
            data.WriteByte(0x49);
            data.WriteByte(0x27);
            data.WriteByte(0x6d);
            data.WriteByte(0x20);
            data.WriteByte(0x72);
            data.WriteByte(0x65);
            data.WriteByte(0x61);
            data.WriteByte(0x64);
            data.WriteByte(0x79);
            data.WriteByte(0x20);
            data.WriteByte(0x62);
            data.WriteByte(0x75);
            data.WriteByte(0x74);
            data.WriteByte(0x20);
            data.WriteByte(0x61);
            data.WriteByte(0x72);
            data.WriteByte(0x65);
            data.WriteByte(0x20);
            data.WriteByte(0x79);
            data.WriteByte(0x6f);
            data.WriteByte(0x75);
            data.WriteByte(0x3f);

            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x01);
            data.WriteByte(0x01);
            data.WriteByte(0x01);
            data.WriteLength();
            session.SendPacket(data);*/

            Packet data = new Packet();
            data.WriteByte(0x44);
            data.WriteByte(0x46);
            
            data.WriteByte(0xfe);
            data.WriteByte(0x1a);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0xa6);
            data.WriteByte(0x01);
            data.WriteByte(0x44);
            data.WriteByte(0x4f);
            data.WriteByte(0x4f);
            data.WriteByte(0x46);
            data.WriteByte(0x45);
            data.WriteByte(0x4e);
            data.WriteByte(0x2d);
            data.WriteByte(0x00);
            data.WriteByte(0x23);
            data.WriteByte(0x39);
            data.WriteByte(0x39);
            data.WriteByte(0x39);
            data.WriteByte(0x39);
            data.WriteByte(0x46);
            data.WriteByte(0x46);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x22);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x4e);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0xfd);
            data.WriteByte(0x03);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x48);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x64);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x0e);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x7d);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x07);
            data.WriteByte(0x00);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x38);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x49);
            data.WriteByte(0x27);
            data.WriteByte(0x6d);
            data.WriteByte(0x20);
            data.WriteByte(0x72);
            data.WriteByte(0x65);
            data.WriteByte(0x61);
            data.WriteByte(0x64);
            data.WriteByte(0x79);
            data.WriteByte(0x20);
            data.WriteByte(0x62);
            data.WriteByte(0x75);
            data.WriteByte(0x74);
            data.WriteByte(0x20);
            data.WriteByte(0x61);
            data.WriteByte(0x72);
            data.WriteByte(0x65);
            data.WriteByte(0x20);
            data.WriteByte(0x79);
            data.WriteByte(0x6f);
            data.WriteByte(0x75);
            data.WriteByte(0x3f);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x00);
            data.WriteByte(0x01);
            data.WriteByte(0x01);
            data.WriteByte(0x01);
            data.WriteByte(0x01);
            data.WriteLength();
            session.SendPacket(data);

            /*session.SendRaw(new byte[] {0x44, 0x46, 0x70, 0x00, 0x00, 0x00, 0xfe, 0x1a,
0x01, 0x00, 0xa6, 0x01, 0x44, 0x4f, 0x4f, 0x46,
0x45, 0x4e, 0x2d, 0x00, 0x23, 0x39, 0x39, 0x39,
0x39, 0x46, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x00,
0x00, 0x4e, 0x00, 0x00, 0x00, 0xfd, 0x03, 0x00,
0x00, 0x00, 0x00, 0x48, 0x00, 0x00, 0x00, 0x64,
0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x0e, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7d, 0x01,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x01, 0x00,
0x38, 0x00, 0x01, 0x49, 0x27, 0x6d, 0x20, 0x72,
0x65, 0x61, 0x64, 0x79, 0x20, 0x62, 0x75, 0x74,
0x20, 0x61, 0x72, 0x65, 0x20, 0x79, 0x6f, 0x75,
0x3f, 0x00, 0x01, 0x00, 0x01, 0x01, 0x01, 0x01});*/
            /*session.SendRaw(new byte[] {0x44, 0x46, 0x6c, 0x00, 0x00, 0x00, 0xfe, 0x1a,
0x01, 0x00, 0xc8, 0x01, 0x44, 0x4f, 0x4f, 0x46,
0x45, 0x4e, 0x2d, 0x00, 0x23, 0x39, 0x39, 0x39,
0x39, 0x46, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x22, 0x00, 0x00, 0x00, 0x00,
0x00, 0x4e, 0x00, 0x00, 0x00, 0xfd, 0x03, 0x00,
0x00, 0x00, 0x00, 0x48, 0x00, 0x00, 0x00, 0x64,
0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x01, 0x00,
0x38, 0x00, 0x01, 0x49, 0x74, 0x27, 0x73, 0x20,
0x74, 0x69, 0x6d, 0x65, 0x20, 0x74, 0x6f, 0x20,
0x44, 0x55, 0x45, 0x4c, 0x21, 0x00, 0x01, 0x00,
0x01, 0x01, 0x01, 0x01});*/

            session.SendRaw(new byte[] { 0x44, 0x46, 0x03, 0x00, 0x00, 0x00, 0xfc, 0x1a, 0x01, 0x01, 0x00 });
            session.SendRaw(new byte[] { 0x44, 0x46, 0x05, 0x00, 0x00, 0x00, 0x51, 0x1b, 0x2d, 0x02, 0xfd, 0x03, 0x00 }); // not the server on bottom
            session.SendRaw(new byte[] { 0x44, 0x46, 0x00, 0x00, 0x00, 0x00, 0x73, 0x1b });

        }


    }
}
