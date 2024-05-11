using Shared;
using Shared.Network;
using Shared.Util;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Session
{
    internal class LoginClient : Client
    {
        public LoginClient(string[] args) : base(args)
        {
            name = "Login Client";
            port = 28962;
        }

        public override void OnConnected(Socket socket)
        {
            Send(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }); // SendConnectionReq
            Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 }); // SendProcessingUserCountReq
        }

        public override void OnReceive(byte[] buff, int bytesRead)
        {
            try
            {
                Packet packet = new Packet(buff);
                //int protocolID = BitConverter.ToUInt16(buff, 4);
                ushort test = BitConverter.ToUInt16(buff, 6);
                //LogFactory.GetLog(name).LogInfo($"dumping packet proto {packet.protocolID}.");
               // LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
                switch (packet.protocolID)
                {
                    case 1: // serverconnectack
                        // no need to reply just log
                        
                        return;
                    case 17: // usercount
                        //i check code say dont need to reply on this but warshack have
                        Send(new byte[] { 0x29, 0x00, 0x00, 0x00, 0x0a, 0x00, 0x01, 0x00,
0x00, 0x00, 0x50, 0xc3, 0x00, 0x00, 0x39, 0x62,
0x64, 0x33, 0x39, 0x62, 0x38, 0x35, 0x66, 0x64,
0x64, 0x63, 0x31, 0x33, 0x65, 0x62, 0x66, 0x34,
0x39, 0x63, 0x31, 0x33, 0x62, 0x37, 0x31, 0x38,
0x61, 0x32, 0x32, 0x64, 0x61, 0x34, 0x00 });
                        //Packet testp = new Packet(0x0a);
                        //testp.Write(0x00);
                        
                        //Send(testp);
                        return;
                    case 11: // auth validation server list with info
                        if(test == 1) // refrsh 
                        {
                            Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 }); // SendProcessingUserCountReq
                        }
                        else
                        {
                            Send(new byte[] { 0x05, 0x00, 0x00, 0x00, 0x0c, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 });
                        }
                        //
                        return;
                    case 13: // recieve server name or server list
                        LogFactory.GetLog(name).LogInfo($"Read {packet.ReadShort()}"); // first data
                        //LogFactory.GetLog(name).LogInfo($"Read {packet.ReadLong()}"); // first data
                        LogFactory.GetLog(name).LogInfo($"Read {packet.ReadShort()}");
                        LogFactory.GetLog(name).LogInfo($"Read {packet.ReadString()}"); // server ip
                        Send(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x16, 0x00, 0x01, 0x00, 0x00, 0x00 });
                        return;
                    case 15: // recieve server ip
                        LogFactory.GetLog(name).LogInfo($"Read {packet.ReadShort()}"); // first data
                        LogFactory.GetLog(name).LogInfo($"Read {packet.ReadString()}"); // server ip
                        Send(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x11, 0x00, 0x00, 0x00 });

                        return;
                    
                    case 23: // OnSFSLGalaxyServerAck
                        //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                        Send(new byte[] { 0x06, 0x00, 0x00, 0x00, 0x0e, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 });
                        return;
                    default:
                        
                        LogFactory.GetLog(name).LogInfo($"dumping data {test}.");
                        LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
                        break;

                        /*case 1:
                            //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                            Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 });
                            Send(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x11, 0x00, 0x00, 0x00 });
                            return;
                        case 11:
                            //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                            Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 });
                            return;
                        case 13: // recieve server name
                            //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                            Send(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x16, 0x00, 0x01, 0x00, 0x00, 0x00 });
                            return;
                        case 15: // receive game server ip
                            //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                            //Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 });
                            return;
                        case 17:
                            Send(new byte[] { 0x05, 0x00, 0x00, 0x00, 0x0c, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 });

                            return;
                        case 23:
                            //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                            Send(new byte[] { 0x06, 0x00, 0x00, 0x00, 0x0e, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 });
                            return;*/
                }
            }
            catch(Exception e)
            {
                LogFactory.GetLog(name).LogFatal(e);
            }

           /* try
            {
                int protocolID = BitConverter.ToUInt16(buff, 4);
                //ushort test = BitConverter.ToUInt16(buff, 6);
                LogFactory.GetLog(name).LogInfo($"dumping packet proto {protocolID}.");
                // LogFactory.GetLog(name).LogInfo($"dumping data {test}.");
                LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(buff, bytesRead)}");
                switch (protocolID)
                {
                    case 1:
                        //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                        Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 });
                        Send(new byte[] { 0x02, 0x00, 0x00, 0x00, 0x11, 0x00, 0x00, 0x00 });
                        return;
                    case 11:
                        //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                        Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 });
                        return;
                    case 13: // recieve server name
                        //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                        Send(new byte[] { 0x04, 0x00, 0x00, 0x00, 0x16, 0x00, 0x01, 0x00, 0x00, 0x00 });
                        return;
                    case 15: // receive game server ip
                        //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                        //Send(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x10, 0x00 });
                        return;
                    case 17:
                        Send(new byte[] { 0x05, 0x00, 0x00, 0x00, 0x0c, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00 });

                        return;
                    case 23:
                        //LogFactory.GetLog(name).LogInfo($"send {"test"}.");
                        Send(new byte[] { 0x06, 0x00, 0x00, 0x00, 0x0e, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00 });
                        return;
                }
            }
            catch (Exception e)
            {

            }*/
        }
    }
}
