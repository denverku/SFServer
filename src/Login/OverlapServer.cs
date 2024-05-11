
using Login.Session;
using Shared.Enum;
using Shared.Network;
using Shared.Session;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

namespace Login
{
    internal class OverlapServer : Server
    {
        public OverlapServer(string[] args) : base(args)
        {
            name = "OverlapServer";
            //type = ServerType.Authentication;
            port = 28965;
            maxConnections = 5;
            //network = new LoginNetwork();
            base.RegisterDefaultSchedulers();
            // Scheduler.AddTask(new TestTask(Scheduler), 1, true);
        }

        public override void OnRun(TcpClient client)
        {
            if (sessions.Count < maxConnections)
            {
                OverlapSession session = new OverlapSession(this, client);
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
