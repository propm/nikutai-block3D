using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class Socket
{
    private const string DllPath = "SocketClient.dll";

    [DllImport(DllPath)]
    private static extern bool setup();

    [DllImport(DllPath)]
    private static extern int update();

    [DllImport(DllPath)]
    private static extern void close();

    private static int value;

    public static float Value
    {
        get
        {
            return value / 10000.0f;
        }
    }

    public static bool Init() {
        return setup();
    }

    public static void Update() {
        value = update();
        //Debug.Log("a");
    }

    public static void End() {
        close();
    }
}