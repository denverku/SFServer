using Shared.Util.Log.Factories;
using Shared.Util.Log;
using System;
using Launcher;

namespace HGWC {
    internal class Program {
        static string RootName = "LauncherServer";

        static void Main(string[] args)
        {
            Console.Title = RootName;
            LogFactory.Initalize();
            LogFactory.OnWrite += Logger.LogFactory_ConsoleWrite;
            UserServer server = new UserServer(args);
           // LoginSessionServer server2 = new LoginSessionServer(args);
            try
            {
                server.Start();
                //server2.Start();

            }
            catch (Exception e)
            {
                LogFactory.GetLog($"{RootName}:Loader").LogError(e.Message);
            }
            
        }
    }
}