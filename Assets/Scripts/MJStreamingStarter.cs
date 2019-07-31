using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJStreamingStarter : MonoBehaviour
{
    public MJStreamingPlayer player;
    public string ServerUrl = "http://raspberrypi.local:8080/?action=stream";
    public bool PlayAutomatically = false;

    // Start is called before the first frame update
    void Start()
    {
        player.serverUrl = Config.ReadValue("MJpegStreamer", "Url", ServerUrl);
        if (PlayAutomatically)
            player.StartStreaming();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
