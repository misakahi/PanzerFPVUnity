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

    private Channel channel;
    private Panzer.Panzer.PanzerClient client;
    private RunThrottle sendCommandThrottle;
    private ControllerInput prevSendInput = ControllerInput.Zero();


    static public PanzerCommandSender GetInstance()
    {
        if (_instance == null)
            _instance = new PanzerCommandSender();
        return _instance;
    }

    static public PanzerCommandSender withConnection(string host, int port, int interval = 100)
    {
        var instance = GetInstance();
        instance.Connect(host, port);
        instance.sendCommandThrottle = new RunThrottle(interval);
        return instance;
    }

    private PanzerCommandSender(string host = "localhost", int port = 50051, int interval = 100)
    {
        this.Connect(host, port);
        this.sendCommandThrottle = new RunThrottle(interval);
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
        var instance = GetInstance();
        var controlRequest = new Panzer.ControlRequest
        {
            DriveRequest = new DriveRequest
            {
                LeftLevel = input.LeftLevel,
                RightLevel = input.RightLevel
            },
            MoveTurretRequest = new MoveTurretRequest
            {
                Rotation = input.TurretRot,
                Updown = input.TurretUpDown
            }
        };
        instance.client.Control(controlRequest);

        instance.prevSendInput = input;
    }

    static public async Task RemoteControlAsync(ControllerInput input)
    {
        await Task.Run(() => RemoteControl(input));
    }

    static public void RemoteControlThrottle(ControllerInput input)
    {
        var instance = GetInstance();

        // sending consecutive zeros is meaningless.
        if (instance.prevSendInput.IsZero() && input.IsZero()) return;

        instance.sendCommandThrottle.Run(() =>
            {
                try
                {
                    PanzerCommandSender.RemoteControl(input);
                }
                catch (RpcException e)
                {
                    // Debug.LogException(e);
                }
            });
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
