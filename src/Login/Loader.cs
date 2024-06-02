using System;
using Shared.Util.Log;
using Shared.Util.Log.Factories;

namespace Login
{
    internal class Loader
    {
        static string RootName = "LoginServer";
        static void Main(string[] args)
        {
            Console.Title = RootName;
            LogFactory.OnWrite += Logger.LogFactory_ConsoleWrite;
            LoginServer server = new LoginServer(args);
            OverlapServer server2 = new OverlapServer(args);
            LauncherServerSession launcherServerSession = new LauncherServerSession(args);
            GameServerSession gameServerSession = new GameServerSession(args);
            try
            {
                //server.Start();
                server2.Start();
                launcherServerSession.Start();
                //gameServerSession.Start();
            }
            catch (Exception e)
            {
                LogFactory.GetLog($"{server.Name}:Loader").LogError(e.Message);
            }
        }
    }
}