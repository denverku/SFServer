
using Game.Session;
using Shared;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Game
{
    internal class LoginServer : Server
    {
        public int ChannelsCount = 5;
        public LoginServer(string[] args) : base(args)
        {
            //int id = int.Parse(args[0]);
            name = "LoginServeeer";
            maxConnections = 5;
            port = 28963;
            //type = ServerType.Game;

            //network = new GameNetwork();
            RegisterDefaultSchedulers();
        }

        public override void RegisterDefaultSchedulers()
        {
            // Scheduler.AddTask(new AnnouncementTask(scheduler), 1, true);
            base.RegisterDefaultSchedulers();
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
