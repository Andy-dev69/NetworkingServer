/* SERVER - May be enchanted to work with multiple clients */
/* 
import java.net.*;
import java.io.*;

public class NetworkingServer {
    public static void Main(String[] args) {
        ServerSocket server = null;
        Socket client;

        // Default port number we are going to use
        int portnumber = 1234;
        if (args.lenght >= 1) {
            portnumber = Integear.ParseInt(args[0]);
        } 

        // Create sever side socket
        try {
            server = new ServerSocket(portnumber);
        } catch(IOException ie) {
            System.out.println("Cannot open socket." + ie);
            System.exit(1);
        }
        System.out.println("ServerSocket is created " + server);

        // Wait for the data from the client and reply
        while(true) {
            try {
                // Listens for a connection to be made to 
                // this socket and accepts it. The method blocks until
                // a connection is made
                System.out.println("Waiting for connect request...");
                client = server.accept();
                System.out.println("Connect request is accepted...");
                String clientHost = client.getInetAdress().getHostAdress();
                int clientPort = client.getPort();
                System.out.println("Client host = " + clientHost + " Client port = " + clientPort);
                // Read data from client
                InputStream clientIn = client.getInputStream();
                BufferedReader br = new BufferedReader(new InputStreamReader(clientIn));
                String msgFromClient = br.readLine();
                System.out.println("Message recieved from client = " + msgFromClient);
                // Send response to the client
                if (msgFromClient != null && !msgFromClient.equalsIgnoreCase("bye")) {
                    OutputStream clientOut = client.getOutputStream();
                    PrintWriter pw = new PrintWriter(clientOut, true);
                    String ansMsg = "Hello, " + msgFromClient;
                    pw.println(ansMsg); 
                }
                // Close sockets 
                if (msgFromClient != null && msgFromClient.equalsIgnoreCase("bye")) {
                    server.close();
                    client.close();
                    break;
                }
            } catch(IOException ie) {
                System.out.println("Cannot open socket." + ie);
                System.exit(1);
            }
        }
    }
}
*/