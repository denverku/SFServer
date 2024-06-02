using System;
using System.Threading;
using Shared.Util.Log;
using Shared.Util.Log.Factories;

namespace Game
{
    internal class Loader
    {
        static string RootName = "GameServer";
        static void Main(string[] args)
        {
            Console.Title = RootName;
            LogFactory.Initalize();
            LogFactory.OnWrite += Logger.LogFactory_ConsoleWrite;

            try
            {
                GameServer server = new GameServer(args);
                //LogFactory.GetLog("GameServer:Loader").LogInfo("Starting the game server with collected settings..");
                server.Start();
                //LoginServer server2 = new LoginServer(args);
               // LogFactory.GetLog("GameServer:Loader").LogInfo("Starting the login server session..");
                //server2.Start();
                //MsgServer test = new MsgServer(args);
                //LogFactory.GetLog("GameServer:Loader").LogInfo("Starting the login server session..");
                //test.Start();
                //ClanChatServer server3 = new ClanChatServer(args);
                //LogFactory.GetLog("GameServer:Loader").LogInfo("Starting the clanchat server session..");
                //server3.Start();
            }
            catch (Exception e)
            {
                LogFactory.GetLog("GameServer:Loader").LogError(e.Message);
            }
        }
    }
}