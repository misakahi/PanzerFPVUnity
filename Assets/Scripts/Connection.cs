using System.Collections;
using System.Collections.Generic;
using Grpc.Core;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public string ServerHost = "localhost";
    public int ServerPort = 9999;
    public string CameraHost = "localhost";
    public int CameraPort = 8080;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Channel serverConnection()
    {
        return new Channel(ServerHost + ":" + ServerPort, ChannelCredentials.Insecure);
    }
}
