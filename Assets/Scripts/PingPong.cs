using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public bool IsConnected;
    public int PingPongInterval = 990;  // milliseconds - has be less than 1000???
    
    private RunThrottle PingPongThrottle;

    // Start is called before the first frame update
    void Start()
    {
        this.PingPongThrottle = new RunThrottle(PingPongInterval);
        this.IsConnected = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.PingPongThrottle.Run(() => {
            try {
                PanzerCommandSender.PingPong();
                this.IsConnected = true;
            } catch (System.Exception e) {
                Debug.LogException(e);
                this.IsConnected = false;
            }
            Debug.Log("ping pong throttle: " + this.IsConnected);
        });
    }
}
