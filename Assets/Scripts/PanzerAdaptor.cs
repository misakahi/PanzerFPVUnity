using UnityEngine;
using System.Threading.Tasks;
using System;
using Grpc.Core;
using Panzer;

class PanzerAdaptor
{
    string Host;
    int Port;

    public PanzerAdaptor(string host = "localhost", int port = 9999) {
        this.Host = host;
        this.Port = port;
    }

    public void remoteControll(Vector2 stickL, Vector2 stickR) {
        Channel channel = new Channel(Host + ":" + Port, ChannelCredentials.Insecure);
        var client = new Panzer.Panzer.PanzerClient(channel);

        client.Drive(Stick2DriveRequest(stickL));
        client.MoveTurret(Stick2MoveTurretRequset(stickR));
        
        channel.ShutdownAsync().Wait();
    }

    static public DriveRequest Stick2DriveRequest(Vector2 stick) {
        float leftLevel = 0;
        float rightLevel = 0;

        var s = stick.magnitude;
        var n = stick.normalized;

        // spin turn
        if (-0.25 <= n.y && n.y < 0.15) {
            leftLevel = n.x > 0 ? 1 : -1;
            rightLevel = leftLevel * (-1);
        } else {
            if (n.x >= 0 && n.y > 0) {
                leftLevel = 1;
                rightLevel = n.y;
            }
            else if (n.x >= 0 && n.y < 0) 
            {
                leftLevel = -1;
                rightLevel = n.y;
            } else if (n.x < 0 && n.y > 0)
            {
                leftLevel = n.y;
                rightLevel = 1;   
            } else if (n.x < 0 && n.y < 0)
            {
                leftLevel = n.y;
                rightLevel = -1;   
            }
        }

        return new DriveRequest {
            LeftLevel = leftLevel * s,
            RightLevel = rightLevel * s,
        };
    }

    static public MoveTurretRequest Stick2MoveTurretRequset(Vector2 stick) {
        return new MoveTurretRequest {
            Rotation = stick.x,
            Updown = Math.Abs(stick.y) < 0.2 ? 0 : stick.y,
        };
    }
}
