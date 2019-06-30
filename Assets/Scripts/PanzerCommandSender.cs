using UnityEngine;
using System.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Panzer;

class PanzerCommandSender
{
    private string Host;
    private int Port;
    private static PanzerCommandSender instance = null;

    private bool isLocked = false;

    static public PanzerCommandSender getInstance()
    {
        if (instance == null)
            instance = new PanzerCommandSender();
        return instance;
    }

    static public PanzerCommandSender withConnection(string host, int port)
    {
        var instance = PanzerCommandSender.getInstance();
        instance.Host = host;
        instance.Port = port;
        return instance;
    }

    private PanzerCommandSender(string host = "localhost", int port = 50051)
    {
        this.Host = host;
        this.Port = port;
    }

    private Channel getChannel()
    {
        return new Channel(Host + ":" + Port, ChannelCredentials.Insecure);
    }

    static public void RemoteControl(ControllerInput input)
    {
        PanzerCommandSender.RemoteControl(input.LeftLevel, input.RightLevel, input.TurretRot, input.TurretUpDown);
    }

    static public void RemoteControl(float leftLevel, float rightLevel, float rotation, float updown)
    {
        var instance = PanzerCommandSender.getInstance();
        var channel = instance.getChannel();
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
        var client = new Panzer.Panzer.PanzerClient(channel);
        client.Control(controlRequest);
        channel.ShutdownAsync().Wait();
    }

    static public async Task RemoteControlAsync(float leftLevel, float rightLevel, float rotation, float updown)
    {
        await Task.Run(() => RemoteControl(leftLevel, rightLevel, rotation, updown));
    }

    static public DriveRequest Stick2DriveRequest(Vector2 stick)
    {
        float leftLevel = 0;
        float rightLevel = 0;

        var s = stick.magnitude;
        var n = stick.normalized;

        // spin turn
        if (-0.25 <= n.y && n.y < 0.15)
        {
            leftLevel = n.x > 0 ? 1 : -1;
            rightLevel = leftLevel * (-1);
        }
        else
        {
            if (n.x >= 0 && n.y > 0)
            {
                leftLevel = 1;
                rightLevel = n.y;
            }
            else if (n.x >= 0 && n.y < 0)
            {
                leftLevel = -1;
                rightLevel = n.y;
            }
            else if (n.x < 0 && n.y > 0)
            {
                leftLevel = n.y;
                rightLevel = 1;
            }
            else if (n.x < 0 && n.y < 0)
            {
                leftLevel = n.y;
                rightLevel = -1;
            }
        }

        return new DriveRequest
        {
            LeftLevel = leftLevel * s,
            RightLevel = rightLevel * s,
        };
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
        var channel = instance.getChannel();
        var client = new Panzer.Panzer.PanzerClient(channel);

        var Pong = client.SendPing(new Panzer.Ping { Ping_ = ping });

        channel.ShutdownAsync().Wait();
        return Pong.Pong_;
    }

    public static async Task<String> PingPongAsync()
    {
        var result = await Task.Run(() => PingPong());
        return result;
    }
}
