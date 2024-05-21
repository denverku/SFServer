using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Game.Network;
using Newtonsoft.Json;
using Shared;
using Shared.Model;
using Shared.Network;
using Shared.Util;
using Shared.Util.Log.Factories;

namespace Game.Session
{
    public class GameSession : Shared.Session.Session
    {
        //User::PacketParse
        private User _user;
        //private FeverData _fever = new FeverData();
        

        List<BaseNetwork> handler = new List<BaseNetwork>();
        public GameSession(Server server, TcpClient client) : base(server, client)
        {
            
            byte[] ba = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x63, 0x00 };
            SendRaw(ba);



            handler.Add(new OnSFConnectionReq());
            handler.Add(new OnSFSendUserDataReq());
            handler.Add(new OnSFGetDBDataReq());
            handler.Add(new OnSFUDPDataStoreReq());

            handler.Add(new OnSFUserListInChannelReq());
            handler.Add(new OnSFChannelListReq());
            handler.Add(new OnSFEnterChannelReq());
            handler.Add(new OnSFLeaveChannelReq());

            handler.Add(new OnSFCreateRoomReq());
            handler.Add(new OnSFUserListInRoomReq());
            handler.Add(new OnSFLocationReq());
            handler.Add(new OnSFUserLocationReq());
            handler.Add(new OnSFChangeGameMapReq());
            handler.Add(new OnSFChangeCountryReq());
            handler.Add(new OnSFChangeThirdViewReq());
            handler.Add(new OnSFChangeEnemyViewReq());
            handler.Add(new OnSFChangeGameTypeReq());
            handler.Add(new OnSFChangeIntrudeReq());

            handler.Add(new OnSFGameGuardAuthReq());
            handler.Add(new OnSFEnterForceSettingReq());

            handler.Add(new OnSFRoomInfoInChannelReq());

            handler.Add(new OnSFUpdateNewUserFlagReq());
            handler.Add(new OnSFSaveSystemSpecReq());
            handler.Add(new OnSFSaveNickNameReq());
            handler.Add(new OnSFCheckOverlapNickNameReq());

            handler.Add(new OnSFBuyCharacterReq());
            handler.Add(new OnSFBuyArmsReq());

            handler.Add(new OnSFCharacterInfoReq());
            handler.Add(new OnSFChatInChannelAllReq());

            handler.Add(new OnSFEndClientLoadingReq());
            handler.Add(new OnSFExitGameServerReq());
        }

        protected override void OnRun(Packet packet)
        {
            try
            {
                LogFactory.GetLog(server.Name).LogInfo($"dumping packet protocolID {packet.protocolID}.");
                if (packet.protocolID == 5000)
                {

                }
                else
                {
                    packet.Dump();
                }
                foreach (BaseNetwork bn in handler)
                {
                    if(bn.ProtocolId() == packet.protocolID)
                    {
                        bn.Handle(packet, this);
                    }
                    else
                    {

                    }
                }
                //Packet packet = new Packet(buffer);
                
               // LogFactory.GetLog(server.Name).LogInfo($"\n{NetworkUtil.DumpPacket(buffer, length)}");
                switch (packet.protocolID)
                {
                    
                   
                    case 106: // OnSFConnectionReq
                        break;
                    case 108: // OnSFSearchInServerReq
                        break;
                    
                    case 112: // OnSFConnectionReq
                        break;
                    /*case 114: // OnSFUDPDataStoreReq
                        SendRaw(new byte[] { 0x97, 0x00, 0x00, 0x00, 0x69, 0x00, 0x0a, 0x43,
0x48, 0x31, 0x20, 0x3a, 0x20, 0x41, 0x4c, 0x4c,
0x00, 0x00, 0x00, 0x2c, 0x01, 0x43, 0x48, 0x32,
0x20, 0x3a, 0x20, 0x41, 0x4c, 0x4c, 0x00, 0x02,
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
0x00, 0x01, 0x00, 0x2c, 0x01 });

                        SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x2f, 0x01, 0x00, 0x00,0x00, 0x04, 0x00, 0x00, 0x00, 0xdd, 0x50, 0x00, 0x00, 0x00, 0x00 });
                        
                        SendRaw(new byte[] {0x6e, 0x00, 0x00, 0x00, 0x5b, 0x02, 0xcd, 0xc2,
0xe8, 0xd2, 0xcb, 0xc5, 0xa7, 0xe0, 0xaa, 0xd7,
0xe8, 0xcd, 0x20, 0xe0, 0xc7, 0xe7, 0xbb, 0xe4,
0xab, 0xb5, 0xec, 0xab, 0xd7, 0xe9, 0xcd, 0xa2,
0xd2, 0xc2, 0xe4, 0xcd, 0xe0, 0xb7, 0xc1, 0x2c,
0x20, 0xbb, 0xd7, 0xb9, 0xb7, 0xcd, 0xa7, 0x2c,
0x20, 0xc2, 0xc8, 0xe4, 0xcd, 0xb4, 0xd5, 0x20,
0xe1, 0xc5, 0xd0, 0xe0, 0xc7, 0xe7, 0xbb, 0xe4,
0xab, 0xb5, 0xec, 0xbb, 0xc5, 0xcd, 0xc1, 0xe1,
0xbb, 0xc5, 0xa7, 0xb5, 0xe8, 0xd2, 0xa7, 0xe6,
0x20, 0xe0, 0xbe, 0xc3, 0xd2, 0xd0, 0xa4, 0xd8,
0xb3, 0xa8, 0xd0, 0xb5, 0xa1, 0xe0, 0xbb, 0xe7,
0xb9, 0xe0, 0xcb, 0xc2, 0xd7, 0xe8, 0xcd, 0xa2,
0xcd, 0xa7, 0xc1, 0xd4, 0xa8, 0xa9, 0xd2, 0xaa,
0xd5, 0xbe, 0x21, 0x00});
                        break;*/
                    
                    
                    
                   
                   
                    
                    case 205:

                        break;
                    
                    case 208: // OnSFConnectionReq
                        break;
                   
                    
                    case 214: // OnSFEnterRoomReq
                        SendRaw(new byte[] {0x10, 0x00, 0x00, 0x00, 0xd7, 0x00, 0x44, 0x03,
0x18, 0xfa, 0x52, 0x6c, 0x2e, 0xf5, 0x96, 0x4a,
0x94, 0x0e, 0x89, 0x35, 0x2e, 0x77}); 
                        break;
                    case 216: // OnSFQuickJoinReq
                        break;
                    case 218: // OnSFSaveCharacterDataInDBReq
                        // send the 1214 for test only
                        break;
                    case 219: // OnSFConnectionReq
                        break;
                    case 220: // OnSFSaveBasicCharacterInDBReq
                        break;
                    case 222: // OnSFLoadGeneralPurposeData
                        // test data
                        SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0xbf, 0x04, 0x00, 0x00, 0x00, 0x00 });
                        break;
                    case 224: // OnSFSaveGeneralPurposeData
                        break;
                    case 300: // OnSFLeaveRoomReq

                        SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x2d, 0x01 });
                        break;
                    
                    
                    case 306: // OnSFChatInRoomAllReq

                        break;
                    case 308: // OnSFChatInRoomReq

                        break;
                    
                    case 318: // OnSFGameReadyReq
                        break;
                    case 320: //OnSFGameStartReq
                        break;
                    case 322: // GameEnd
                        break;
                    case 324: // OnSFEndClientLoadingReq

                        break;
                    case 326: // OnSFExitGameReq
                        break;
                    
                    case 330: // OnSFForcedLeaveRoomReq
                        break;
                    case 332: // OnSFInvitationReq
                        break;
                    case 334: // OnSFSaveGamePointInDBReq
                        break;
                    case 336: // OnSFSaveEquipDurationInDBReq

                        break;
                    case 338: // OnSFSaveClanPointReq
                        break;

                    

                    
                    case 1206:
                        //User::OnSFLeaveForceSettingReq(this, &packet);
                        SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0xb7, 0x04  });
                        break;
                    
                    
                    
                    case 1212:
                        //User::OnSFRepairItemReq(this, &packet);
                        break;
                    case 1214: // OnSFCheckBalanceReq
                        SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0xbf, 0x04, 0x00, 0x00, 0x00, 0x00 });
                        break;
                    case 1216:
                        //User::OnSFBuyCashItemReq(this, &packet);
                        break;
                    case 1218:
                        //User::OnSFBuyDirectUseCashItemReq(this, &packet);
                        break;
                    case 1220:
                        //User::OnSFBuySPItemReq(this, &packet);
                        break;
                    case 1222:
                        //User::OnSFItemAttributeReq(this, &packet);
                        break;
                    case 1224:
                        //User::OnSFUserETCInfoReq(this, &packet);
                        break;
                    case 1230:
                        //User::OnSFSaveWebItemWareDataReq(this, &packet);
                        break;
                    
                   

                    case 8003: // load gift tab in inventory
                        
                        break;
                    /*case 8008: // OnSFGameGuardAuthReq
                        SendRaw(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x62, 0x02, 0x00, 0x00 });
                        SendRaw(new byte[] { 0x8a, 0x00, 0x00, 0x00, 0x63, 0x02, 0x02, 0x00,
0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                        //SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x68, 0x02, 0x30, 0x00, 0x00 });
                        // // here the disconnect come or please try again
                        //SendRaw(new byte[] { 0x03, 0x00, 0x00, 0x00, 0x64, 0x02, 0x00, 0x00, 0x00});
                        //SendRaw(new byte[] { 0x27, 0x00, 0x00, 0x00, 0xba, 0x0b, 0x04, 0x00, 0x23, 0x04, 0x00, 0x00, 0x20, 0x4e, 0x00, 0x00, 0x01, 0x24, 0x04, 0x00, 0x00, 0x20, 0x4e, 0x00, 0x00, 0x01, 0x25, 0x04, 0x00, 0x00, 0x20, 0x4e,0x00, 0x00, 0x01, 0x31, 0x04, 0x00, 0x00, 0x20,0x4e, 0x00, 0x00, 0x01, 0x00 });
                        //SendRaw(new byte[] { 0x04, 0x00, 0x00, 0x00, 0xcf, 0x04, 0x00, 0x00,0x00, 0x00 });

                        //SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x69, 0x00 });
                        //SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x69, 0x00 });
                        SendRaw(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x00, 0x00, 0x00 });
                        
                        break;*/
                }


               

            }
            catch (Exception e)
            {
                LogFactory.GetLog(server.Name).LogFatal(e);
            }

            base.OnRun(packet);
        }

        protected override void HandlePacket(Packet packet)
        {


            base.HandlePacket(packet);
        }

        public override void OnFinishPacketSent(Packet packet)
        {
            
            base.OnFinishPacketSent(packet);
        }

        public User User => _user;

    }
}