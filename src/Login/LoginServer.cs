﻿using System.Net.Sockets;
using Login.Session;
using Shared;
using Shared.Enum;

namespace Login {
    public class LoginServer : Server {
        public LoginServer(string[] args) : base(args)
        {
            name = "LoginServer";
            port = 28962; // listener for session server
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