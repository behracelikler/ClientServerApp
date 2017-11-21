using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.ComponentModel;
using GlobalLibrary;

namespace ServerApplication
{
    class ConsoleMessage
    {
        static String ListenIP;
        static int ListenPort;
        static Boolean KeepServerLog = true; //KeepServerLog is true : SQL write log; false, don't log
        static void Main(string[] args)
        {
            Console.Title = "Console Message Received";
            GetData();

            ReceiveMessage();

            Console.ReadLine();

        }

        private static void ReceiveMessage()
        {
            if (String.IsNullOrEmpty(ListenIP) ||
              ListenPort == 0)
            {
                Console.WriteLine("Please enter IP and port...");
                return;
            }

            try
            {
                IPAddress localAdd = IPAddress.Parse(ListenIP);
                TcpListener listener = new TcpListener(localAdd, ListenPort);
                Console.WriteLine("Listening...");
                listener.Start();

                TcpClient client = listener.AcceptTcpClient();
                ListenToTheMessage(client);

                client.Close();
                listener.Stop();
            }
            catch (Exception ex)
            {
                SqlOperations.SQLLog(KeepServerLog, "Server - ERROR", "", "", "", ListenIP, ListenPort, String.Concat("ERROR ", ex.Message));

                throw;
            }
            finally
            {
                SqlOperations.CloseConnection(KeepServerLog);
            }
        }

        private static void ListenToTheMessage(TcpClient client)
        {
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine(String.Concat("Received : ", dataReceived));
            SqlOperations.SQLLog(KeepServerLog, "Server", "", dataReceived, "", ListenIP, ListenPort, "");

            Console.Write("Back send message the client : ");
            String backSendMessage = Console.ReadLine();
            buffer = Encoding.UTF8.GetBytes(backSendMessage);
            if (nwStream.CanWrite)
            {
                nwStream.Write(buffer, 0, buffer.Length);
                Console.WriteLine(String.Concat("Sending back : ", backSendMessage));

                SqlOperations.SQLLog(KeepServerLog, "Server", "", "", backSendMessage, ListenIP, ListenPort, "");
            }
            else
                Console.WriteLine("Error : Don't write stream ");
        }

        private static void GetData()
        {
            //example:   IP: "192.168.16.15"
            //         Port: 8081
            Console.Write("Listen at the specified IP : ");
            ListenIP = Console.ReadLine();
            Console.Write("Listen at the specified Port : ");
            ListenPort = Convert.ToInt32(Console.ReadLine());
        }
    }

}
