using System.Net;
using System.Net.Sockets;
using Game.Model;
using Game.Session;
using Game.Task;
using Newtonsoft.Json;
using Shared;
using Shared.Enum;
using Shared.Exceptions;
using Shared.Util;

namespace Game
{
    public class GameServer : Server
    {
        
        public GameServer(string[] args) : base(args)
        {
            //int id = int.Parse(args[0]);
            name = "GameServeeer";
            maxConnections = 5;
            //port = 27231;
            port = 27931; //th
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
                GameSession session = new GameSession(this, client);
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