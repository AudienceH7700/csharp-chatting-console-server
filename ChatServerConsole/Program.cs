﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServerConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server Console \n\n\n");
            TcpListener server = new TcpListener(IPAddress.Any, 9999);

            server.Start();

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("클라이언트가 접속하였습니다.");

            while (true)
            {
                byte[] byteData = new byte[1024];

                client.GetStream().Read(byteData, 0, byteData.Length);

                string strData = Encoding.UTF8.GetString(byteData);

                //int endPoint = strData.IndexOf("\0");
                //string parsedMessage = strData.Substring(0, endPoint + 1);

                Console.WriteLine(strData);
            }

        }
    }
}