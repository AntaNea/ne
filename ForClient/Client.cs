using System;
using Google.Protobuf;
using ProtoBuf;
using System.Net.Sockets;
using System.Text;

namespace new_tcp
{
     class Client
    {
        private const int port = 8080;
        private const string ip_server = "127.0.0.1"; // might be output variable

        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(ip_server, port);
                SendingMessage sm;
                NetworkStream str = client.GetStream();
               
                sm = Serializer.Deserialize<SendingMessage>(str);
                Console.WriteLine(" WHO: {sm.UserName}\n WHEN: {sm.SendingTime}\n MESSAGE: {sm.Mess}");
                Console.ReadLine();
                str.Close(); client.Close();
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
