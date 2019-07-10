using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Panzer;

class PanzerCommandSender
{
    private static PanzerCommandSender _instance = null;

    Channel channel;
    Panzer.Panzer.PanzerClient client;

    static public PanzerCommandSender GetInstance()
    {
        if (_instance == null)
            _instance = new PanzerCommandSender();
        return _instance;
    }

    static public PanzerCommandSender withConnection(string host, int port)
    {
        var instance = GetInstance();
        instance.Connect(host, port);
        return instance;
    }

    private PanzerCommandSender(string host = "localhost", int port = 50051)
    {
        this.Connect(host, port);
    }

    // Initialize channel and gRPC client
    private void Connect(string host, int port)
    {
        if (this.channel != null)
            this.channel.ShutdownAsync();

        Debug.Log($@"Connecting gRPC client to {host}:{port}");
        this.channel = new Channel(host + ":" + port, ChannelCredentials.Insecure);
        this.client = new Panzer.Panzer.PanzerClient(this.channel);
    }

    static public void RemoteControl(ControllerInput input)
    {
        RemoteControl(input.LeftLevel, input.RightLevel, input.TurretRot, input.TurretUpDown);
    }

    static public void RemoteControl(float leftLevel, float rightLevel, float rotation, float updown)
    {
        var instance = GetInstance();
        var controlRequest = new Panzer.ControlRequest
        {
            DriveRequest = new DriveRequest
            {
                LeftLevel = leftLevel,
                RightLevel = rightLevel
            },
            MoveTurretRequest = new MoveTurretRequest
            {
                Rotation = rotation,
                Updown = updown
            }
        };
        instance.client.Control(controlRequest);
    }

    static public async Task RemoteControlAsync(float leftLevel, float rightLevel, float rotation, float updown)
    {
        await Task.Run(() => RemoteControl(leftLevel, rightLevel, rotation, updown));
    }

    static public MoveTurretRequest Stick2MoveTurretRequset(Vector2 stick)
    {
        return new MoveTurretRequest
        {
            Rotation = stick.x,
            Updown = Math.Abs(stick.y) < 0.2 ? 0 : stick.y,
        };
    }

    public static String PingPong(String ping="")
    {
        var instance = GetInstance();
        var Pong = instance.client.SendPing(new Panzer.Ping { Ping_ = ping });
        return Pong.Pong_;
    }

    public static async Task<String> PingPongAsync()
    {
        var result = await Task.Run(() => PingPong());
        return result;
    }
}
