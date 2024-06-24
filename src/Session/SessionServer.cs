using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Session.Session;
using Shared;
using Shared.Enum;

namespace Session
{
    internal class SessionServer : Server
    {
        public SessionServer(string[] args) : base(args)
        {
            name = "Session Server";
            //type = ServerType.Authentication;
            //port = 27230; //def
            port = 27930; //th
            maxConnections = 5;
            //network = new LoginNetwork();
            base.RegisterDefaultSchedulers();
            // Scheduler.AddTask(new TestTask(Scheduler), 1, true);
        }

        public override void OnRun(TcpClient client)
        {
            if (sessions.Count < maxConnections)
            {
                SSesion session = new SSesion(this, client);
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
