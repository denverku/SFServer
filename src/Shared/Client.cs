using Shared.Network;
using Shared.Session;
using Shared.Util;
using Shared.Util.Log.Factories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Shared
{
    public class Client
    {
        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 256;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

        //private static ManualResetEvent connectDone = new ManualResetEvent(false);
       // private static ManualResetEvent sendDone = new ManualResetEvent(false);
        //private static ManualResetEvent receiveDone = new ManualResetEvent(false);

        protected string name = "Base Client";
        protected string address = "127.0.0.1";
        protected ushort port = 13008;
        int retryIntervalMilliseconds = 3000;
        Socket client;

        protected Thread thread;

        public Client(string[] args)
        {

        }

        /*public virtual void Start()
        {
            thread = new Thread(() =>
            {
                
                try
                {
                    LogFactory.GetLog(name).LogInfo("Loading client...");
                    // Establish the remote endpoint for the socket.
                    // The name of the 
                    // remote device is "host.contoso.com".
                    IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                    // Create a TCP/IP socket.
                    client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.
                    client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                    LogFactory.GetLog(name).LogInfo($"Connecting at {ipAddress}:{port}.");
                    // connectDone.WaitOne();
                    Receive(client);
                    //receiveDone.WaitOne();
                    // Release the socket.
                    //client.Shutdown(SocketShutdown.Both);
                    // client.Close();

                }
                catch (Exception e)
                {
                    LogFactory.GetLog(name).LogFatal(e);
                }
            });
            thread.Start();
        }*/

        public virtual void Start()
        {
            thread = new Thread(() =>
            {
                // Initial connection attempt
                ConnectWithRetry();
            });
            thread.Start();
        }

        private void ConnectWithRetry()
        {
            try
            {
                LogFactory.GetLog(name).LogInfo("Loading client...");
                // Establish the remote endpoint for the socket.
                // The name of the 
                // remote device is "host.contoso.com".
                IPAddress ipAddress = IPAddress.Parse(address);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP socket.
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                LogFactory.GetLog(name).LogInfo($"Connecting at {ipAddress}:{port}.");
                //connectDone.WaitOne(); // Wait for connection to complete

                // Once connected, start receiving data
               
            }
            catch (Exception e)
            {
                //LogFactory.GetLog(name).LogFatal(e);
                // Retry connection after a delay
                Thread.Sleep(retryIntervalMilliseconds);
                ConnectWithRetry(); // Recursive call for retry
            }
        }



        public void Stop()
        {
            
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);
                LogFactory.GetLog(name).LogInfo($"Socket connected to {client.RemoteEndPoint.ToString()}.");
                Receive(client);
                OnConnected(client);
                //Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString());
                //Receive(client);
                // Signal that the connection has been made.
                //connectDone.Set();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                Thread.Sleep(retryIntervalMilliseconds);
                ConnectWithRetry(); // Recursive call for retry
            }
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                //Console.Write("Received bytes: ");
                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    OnReceive(state.buffer, bytesRead);
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1)
                    {
                        // response = state.sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    //receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public virtual void OnConnected(Socket socket)
        {

        }

        public virtual void OnReceive(byte[] buff, int byteRead)
        {

        }

        public void Send(Packet packet)
        {
            
            // Begin sending the data to the remote device.
            client.BeginSend(packet.ToArray(), 0, packet.Length(), 0, null, packet);
            //client.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
            //Send(packet.ToArray());
        }

        public void Send(byte[] data)
        {
            //LogFactory.GetLog(name).LogInfo($"\n{NetworkUtil.DumpPacket(data, data.Length)}");
            try
            {
                ushort protocolID = BitConverter.ToUInt16(data, 4);
                //ushort dataa = BitConverter.ToUInt16(data, 6);
                LogFactory.GetLog(name).LogInfo($"Sending protocolID {protocolID}.");
                //LogFactory.GetLog(name).LogInfo($"Sending data {dataa}");
            }catch(Exception e)
            {
              // Console.WriteLine(e.ToString());
            }
            // Begin sending the data to the remote device.
           
            //client.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), client);
            client.Send(data);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.
                // sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
