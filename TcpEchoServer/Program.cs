using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpEchoServer
{
	public class TcpEchoServer
	{
		public static void Main()
		{
			Console.WriteLine("Starting echo server...");

			int port = 1234;
			TcpListener listener = new TcpListener(IPAddress.Loopback, port);
			listener.Start();

			TcpClient client = listener.AcceptTcpClient();
			NetworkStream stream = client.GetStream();
			StreamWriter writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
			StreamReader reader = new StreamReader(stream, Encoding.ASCII);

			while (true)
			{
				string inputLine = "";
				while (inputLine != null)
				{
					inputLine = reader.ReadLine();
					writer.WriteLine("Echoing string: " + inputLine);
					Console.WriteLine("Echoing string: " + inputLine);
				}
				Console.WriteLine("Server saw disconnect from client.");
			}
		}
	}
}
