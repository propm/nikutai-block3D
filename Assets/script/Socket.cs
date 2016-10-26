using System;
using System.Runtime.InteropServices;
public static class Socket
{
    [DllImport("SocketClient.dll")]
    private static extern bool setup();

    [DllImport("SocketClient.dll")]
    private static extern int update();

    [DllImport("SocketClient.dll")]
    private static extern void close();

    private static int value;

    public static int Value
    {
        get
        {
            return value;
        }
    }

    public static bool Init() {
        return setup();
    }

    public static void Update() {
        value = update();
    }

    public static void End() {
        close();
    }
}
