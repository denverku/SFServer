using Shared.Session;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using Launcher.Session;

namespace Launcher
{
    internal class UserServer : Server
    {
        public UserServer(string[] args) : base(args)
        {
            name = "Launcher Server";
            //type = ServerType.Authentication;
            port = 37230;
            maxConnections = 5;
            //network = new LoginNetwork();
            base.RegisterDefaultSchedulers();
            // Scheduler.AddTask(new TestTask(Scheduler), 1, true);
        }

        public override void OnRun(TcpClient client)
        {
            if (sessions.Count < maxConnections)
            {
                UserSession session = new UserSession(this, client);
                session.Start();
            }
            else
            {
                client.Client.Shutdown(SocketShutdown.Both);
            }
            base.OnRun(client);
        }
    }
}
