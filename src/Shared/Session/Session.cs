using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Shared.Enum;
using Shared.Network;
using Shared.Util.Log.Factories;

namespace Shared.Session
{
    public class Session
    {
        protected string id;
        protected Server server;
        protected TcpClient client;
        protected Thread thread;
        protected bool isRunning;
        protected NetworkStream NetworkStream;

        protected Queue<Packet> _packetQueue = new Queue<Packet>(10);
        protected int MAX_BUFFER_SIZE = 1024 * 4;
        protected int TIMEOUT_VALUE = 120;

        protected string name = "Base Session";

        public Session(Server server, TcpClient client)
        {
            id = Guid.NewGuid().ToString(); // Temp ID
            this.server = server;
            this.client = client;
            this.client.NoDelay = true;
            this.client.ReceiveTimeout = TIMEOUT_VALUE;
            this.client.SendTimeout = TIMEOUT_VALUE;
            thread = new Thread(Run);
            server.Sessions.Add(this);
        }

        public virtual void Start()
        {
            thread.Start();
            isRunning = client.Client.Connected;
        }

        public virtual void Close()
        {
            server.Sessions.Remove(this);
            try
            {
                LogFactory.GetLog(server.Name).LogInfo($"[CLOSED SESSION] [ID: {id}] [{client.Client.RemoteEndPoint}].");
                client.Client.Shutdown(SocketShutdown.Both);
            } catch (ObjectDisposedException e) 
            {
                LogFactory.GetLog(server.Name).LogInfo($"[CLOSED WITH EXCEPTION] [ID: {id}] [{e.Message}] [{e.StackTrace}].");
            }
            thread.Interrupt();
        }

        protected virtual void TryReadPacket()
        {
            byte[] buffer = new byte[MAX_BUFFER_SIZE];
            NetworkStream.BeginRead(buffer, 0, buffer.Length, OnReceiveCallback, buffer);
        }

        private void OnReceiveCallback(IAsyncResult ar)
        {
            try
            {
                if (client.Client.Connected)
                {
                    int length = NetworkStream.EndRead(ar);
                    if (length > 0)
                    {
                        byte[] buffer = new byte[length];
                        Array.Copy((Array) ar.AsyncState ?? throw new InvalidOperationException(), 0, buffer, 0, length);
                        Packet packet = new Packet(buffer);
                        OnRun(packet);
                    }
                }
            }
            catch (Exception e)
            {
                LogFactory.GetLog(server.Name).LogError($"[PACKET RECEIVE] [ERROR] [MSG:{e.Message}]");
            }
        }

        public void SendPacket(Packet packet)
        {
            try
            {
                ushort protocolID = BitConverter.ToUInt16(packet.readableBuffer, 4);
                //ushort data = BitConverter.ToUInt16(packet.readableBuffer, 6);
                LogFactory.GetLog(server.Name).LogInfo($"Sending protocolID {protocolID}.");
                //LogFactory.GetLog(server.Name).LogInfo($"Sending data {data}");
            }catch(Exception e)
            {

            }
           /* int startIndex = 6;

            // Reading ushort values from byte array starting at startIndex
            while (startIndex + 1 < packet.Buffer.Length)
            {
                ushort value = BitConverter.ToUInt16(packet.Buffer, startIndex);
                Console.WriteLine("Value of ushort at index " + startIndex + ": " + value);
                startIndex += 2; // Incrementing by 2 bytes to read the next ushort
            }*/
            if (packet != null) _packetQueue.Enqueue(packet);
        }

        public void SendRaw(byte[] buff)
        {

            //Packet packet = new Packet(buff);

            //SendPacket(packet);
            try
            {
                ushort protocolID = BitConverter.ToUInt16(buff, 4);
                //ushort data = BitConverter.ToUInt16(packet.readableBuffer, 6);
                LogFactory.GetLog(server.Name).LogInfo($"Sending protocolID {protocolID}.");
                //LogFactory.GetLog(server.Name).LogInfo($"Sending data {data}");
            }
            catch (Exception e)
            {

            }
            Packet packet = new Packet(buff);
            if (packet != null) _packetQueue.Enqueue(packet);
        }

        private bool TryDequeuePacket(out Packet packet)
        {
            packet = null;
            if (_packetQueue.Count != 0)
                packet = _packetQueue.Dequeue();
            return packet != null;
        }
        
        private void TrySendPacket()
        {
            while (TryDequeuePacket(out var packet))
            {
                try
                {
                    //packet.Encode();
                    /*if (packet.IsValid || server.Type.Equals(ServerType.Other))
                    {*/
                    //NetworkStream.BeginWrite(packet.Buffer, 0, packet.Buffer.Length, CompletePacketSend, packet);
                    //NetworkStream.BeginWrite(packet.ToArray(), 0, packet.Length(), CompletePacketSend, packet); 
                    NetworkStream.BeginWrite(packet.ToArray(), 0, packet.Length(), CompletePacketSend, packet);
                    //}
                }
                catch (Exception e)
                {
                    LogFactory.GetLog(server.Name).LogError($"[PACKET SEND] [ERROR] [MSG:{e.Message}]");
                }
            }
        }
        
        private void CompletePacketSend(IAsyncResult ar)
        {
            if (ar.AsyncState is Packet packet)
            {
                NetworkStream.EndWrite(ar);
                LogFactory.GetLog(server.Name).LogInfo($"Packet Sent");
                //LogFactory.GetLog(server.Name).LogInfo($"Packet Sent [{packet.Pid().ToString()}] [{packet.Buffer.Length}] to [{id}].");
                OnFinishPacketSent(packet);
            }
        }

        public virtual void OnFinishPacketSent(Packet packet)
        {
            //packet.Buffer = null;
            //packet.Reset();
        }

        protected virtual void HandlePacket(Packet packet)
        {
            
        }
        
        private void Run()
        {
            try {
                LogFactory.GetLog(server.Name).LogInfo($"[NEW SESSION] [ID: {id}] [{client.Client.RemoteEndPoint}].");
                NetworkStream = client.GetStream();
                while (true)
                {
                    if (!client.Client.Connected) break;
                    if (NetworkStream.DataAvailable)
                    {
                        TryReadPacket();
                    }

                    if (_packetQueue.Count > 0 && NetworkStream.CanRead)
                    {
                        TrySendPacket();
                    }
                }
                Close();
            } catch (IOException e) {
                if ((e.HResult & 0x0000FFFF) == 5664) {
                    try {
                        Close();
                    } catch (IOException ex) {
                        LogFactory.GetLog(server.Name).LogFatal(ex);
                    }
                }
            }
        }

        protected virtual void OnRun(Packet packet)
        {
        }
        
        public SocketAddress GetAddress()
        {
            return client.Client.RemoteEndPoint.Serialize();
        }
        
        public Server Server
        {
            get => server;
            set => server = value;
        }

        public TcpClient Client
        {
            get => client;
            set => client = value;
        }

        public string Id
        {
            get => id;
            set
            {
                LogFactory.GetLog(server.Name).LogInfo($"[SESSION : {id}] ID has been changed to [{value}].");
                id = value;
            }
        }

        public Thread Thread => thread;

        public int MaxBufferSize => MAX_BUFFER_SIZE;

        public bool IsRunning => isRunning;
    }
}