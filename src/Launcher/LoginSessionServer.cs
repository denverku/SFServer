using Launcher.Session;
using Shared.Session;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace Launcher
{
    internal class LoginSessionServer : Server
    {
        public LoginSessionServer(string[] args) : base(args)
        {
            name = "LoginSession Server";
            //type = ServerType.Authentication;
            port = 37240;
            maxConnections = 5;
            //network = new LoginNetwork();
            base.RegisterDefaultSchedulers();
            // Scheduler.AddTask(new TestTask(Scheduler), 1, true);
        }

        public override void OnRun(TcpClient client)
        {
            if (sessions.Count < maxConnections)
            {
                LoginSession session = new LoginSession(this, client);
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
