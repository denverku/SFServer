using System;
using Shared.Util.Log;
using Shared.Util.Log.Factories;

namespace Session
{
    internal class Loader {
        static string RootName = "SessionServer";

        static void Main(string[] args) {
            Console.Title = RootName;
            LogFactory.Initalize();
            LogFactory.OnWrite += Logger.LogFactory_ConsoleWrite;
            //TestUDPServer tserver = new TestUDPServer(args);
            SessionServer server = new SessionServer(args);
            //LoginClient loginClient = new LoginClient(args);
            try
            {
                server.Start();
               // tserver.Start();
                //loginClient.Start();
            }
            catch (Exception e)
            {
                LogFactory.GetLog($"{RootName}:Loader").LogError(e.Message);
            }
        }
    }
}