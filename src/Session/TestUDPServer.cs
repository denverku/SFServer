using Session.Session;
using Shared;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Session
{
    internal class TestUDPServer : Server
    {
        public TestUDPServer(string[] args) : base(args)
        {
            name = "UDP Server";
            
            port = 27935;
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
