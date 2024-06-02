using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Shared.Command;
using Shared.Constants;
using Shared.Enum;
using Shared.Task;
using Shared.Util.Log.Factories;

namespace Shared
{
    public class UDPServer
    {
        protected string name = "Base Server";
        protected int maxConnections = 500;
        protected string address = "127.0.0.1";
        protected ushort port = 13008;
        protected ArrayList sessions = new ArrayList();

        private bool _alive = false;
        private int _tickRate = 12;
        private int _currentTick = 0;
        UdpClient udpClient;
        public UDPServer(string[] args)
        {

        }

        public virtual void Start()
        {
            LogFactory.GetLog(name).LogInfo("Loading server...");
            try
            {
                udpClient = new UdpClient(port);
                udpClient.BeginReceive(UDPReceiveCallback, null);
                LogFactory.GetLog(name).LogInfo($"Listening at {address}:{port}.");
            }
            catch (Exception e)
            {
                LogFactory.GetLog(name).LogFatal(e);
            }

           

        }

        private void UDPReceiveCallback(IAsyncResult _result)
        {
            // Process received data here
            LogFactory.GetLog(name).LogInfo($"Receive.");
        }

        public void Stop()
        {
            LogFactory.GetLog(name).LogWarning($"STOP RECEIVED, CLOSED ALL SESSIONS [{sessions.Count}].");
            udpClient.Close();
            LogFactory.GetLog(name).LogWarning("ALL SESSIONS HAS BEEN CLOSED AND SERVER STOPPED.");
            _alive = false;
        }

        public virtual string GetServerInfo()
        {
            return $"Sessions: {sessions.Count} of {maxConnections}.";
        }

        public virtual void RegisterDefaultSchedulers()
        {
            // Add your default schedulers here
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Address
        {
            get => address;
            set => address = value;
        }

        public ushort Port
        {
            get => port;
            set => port = value;
        }

        
        public ArrayList Sessions => sessions;



        public bool IsAlive => _alive;

        public int MaxConnections => maxConnections;
    }
}
