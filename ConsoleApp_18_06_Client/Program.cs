using System;
using System.Net.Sockets;
using System.Text;

class ClientSync
{
    static void Main(string[] args)
    {
        System.Console.OutputEncoding = Encoding.Unicode;

        // Підключаємося до сервера
        TcpClient client = new TcpClient("localhost", 12345);
        NetworkStream stream = client.GetStream();

        // Відправляємо повідомлення серверу
        string message = "Привіт, сервере!";
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);

        // Читаємо відповідь від сервера
        byte[] buffer = new byte[256];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
        string serverIP = client.Client.LocalEndPoint.ToString();
        Console.WriteLine($"О {DateTime.Now:HH:mm} від {serverIP} отримано рядок: {response}");

        // Закриваємо підключення
        stream.Close();
        client.Close();
    }
}
