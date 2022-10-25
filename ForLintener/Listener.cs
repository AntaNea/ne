using System;
using Google.Protobuf;
using ProtoBuf;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace new_tcp
{
     class Listener
    {
        private const int port = 8080;
        private const string ip_server = "127.0.0.1";

        static void Main(string[] args)
        {
            SendingMessage mess;
            TcpListener server; // for working withiut blocks 
            try
            {
                IPAddress local_ip = IPAddress.Parse(ip_server);
                server = new TcpListener(local_ip, port);
                server.Start();
               while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client accept sucsessfuly");
                    NetworkStream str = client.GetStream();
                    Console.WriteLine("What are you need?");
                    mess = new SendingMessage {Mess = Console.ReadLine(), UserName = ip_server, SendingTime = DateTime.Now.ToString() };
                    str.Write(mess.ToByteArray(), 0, mess.CalculateSize());
                    str.Close(); Client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Socket exceprion: " + e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Other exceprion: " + e);
            }
        }
    }
}
