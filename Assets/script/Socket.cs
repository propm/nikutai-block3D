using System;
using System.Net.Sockets;
using System.Threading;

static class Socket
{
    public static int Data { get { return data; } }

    public static bool IsEnd { get; set; }

    private static TcpClient client;

    private static NetworkStream stream;

    private static Thread thread;

    private static volatile int data;

    static Socket()
    {
        Init();
    }

    private static void Init()
    {
        client = new TcpClient("127.0.0.1", 12345);
        stream = client.GetStream();

        thread = new Thread(new ThreadStart(update));
        thread.Start();
    }

    private static void update()
    {
        while (!IsEnd)
        {
            var buffer = new byte[1];
            stream.Read(buffer, 0, 1);
            data = -(sbyte)buffer[0];
        }

        stream.Dispose();
        client.Close();
    }
}