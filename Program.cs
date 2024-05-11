using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class NetworkingServer
{
    public static void Main(string[] args)
    {
        TcpListener server = null;
        TcpClient client = null;

        // Default port number we are going to use
        int portNumber = 8080;

        // Create server side socket
        try {
            server = new TcpListener(IPAddress.Any, portNumber);
            server.Start();
            Console.WriteLine("ServerSocket is created");
        } catch (Exception e) {
            Console.WriteLine("Cannot open socket." + e);
            Environment.Exit(1);
        }

        // Wait for the data from the client and reply
        while (true) {
            try {
                // Listens for a connection to be made to 
                // this socket and accepts it. The method blocks until
                // a connection is made
                Console.WriteLine("Waiting for connect request...");
                client = server.AcceptTcpClient();
                Console.WriteLine("Connect request is accepted...");
                string clientHost = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                int clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
                Console.WriteLine("Client host = " + clientHost + " Client port = " + clientPort);
                // Read data from client
                NetworkStream networkStream = client.GetStream();
                StreamReader reader = new StreamReader(networkStream);
                string msgFromClient = reader.ReadLine();
                Console.WriteLine("Message received from client = " + msgFromClient);
                // Send response to the client
                if (msgFromClient != null && !msgFromClient.Equals("bye", StringComparison.OrdinalIgnoreCase)) {
                    StreamWriter writer = new StreamWriter(networkStream);
                    string ansMsg = "Hello, " + msgFromClient;
                    writer.WriteLine(ansMsg);
                    writer.Flush();
                }
                // Close sockets 
                if (msgFromClient != null && msgFromClient.Equals("bye", StringComparison.OrdinalIgnoreCase)) {
                    server.Stop();
                    client.Close();
                    break;
                }
            } catch (Exception e) {
                Console.WriteLine("The server encountred a problem. " + e);
                Environment.Exit(1);
            }
        }
    }
}