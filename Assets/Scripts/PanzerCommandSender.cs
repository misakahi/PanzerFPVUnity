using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Panzer;

class PanzerCommandSender
{
    private static PanzerCommandSender instance = null;

    Channel channel;
    Panzer.Panzer.PanzerClient client;

    static public PanzerCommandSender getInstance()
    {
        if (instance == null)
            instance = new PanzerCommandSender();
        return instance;
    }

    static public PanzerCommandSender withConnection(string host, int port)
    {
        var instance = PanzerCommandSender.getInstance();
        if (instance.channel != null)
        {
            instance.channel.ShutdownAsync();
            instance.channel = getChannel(host, port);
            instance.client = new Panzer.Panzer.PanzerClient(instance.channel);
        }
        return instance;
    }

    private PanzerCommandSender(string host = "localhost", int port = 50051)
    {
        this.channel = getChannel(host, port);
        this.client = new Panzer.Panzer.PanzerClient(channel);
    }

    static private Channel getChannel(String host, int port)
    {
        return new Channel(host + ":" + port, ChannelCredentials.Insecure);
    }

    static public void RemoteControl(ControllerInput input)
    {
        PanzerCommandSender.RemoteControl(input.LeftLevel, input.RightLevel, input.TurretRot, input.TurretUpDown);
    }

    static public void RemoteControl(float leftLevel, float rightLevel, float rotation, float updown)
    {
        var instance = PanzerCommandSender.getInstance();
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
        var instance = getInstance();
        var Pong = instance.client.SendPing(new Panzer.Ping { Ping_ = ping });
        return Pong.Pong_;
    }

    public static async Task<String> PingPongAsync()
    {
        var result = await Task.Run(() => PingPong());
        return result;
    }
}
