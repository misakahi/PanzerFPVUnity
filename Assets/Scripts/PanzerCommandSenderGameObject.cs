using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanzerCommandSenderGameObject : MonoBehaviour
{
    public string Host = "localhost";
    public int Port = 50051;
    public int ThrottleInterval = 100;
    private PanzerCommandSender panzerCommandSender;

    // Start is called before the first frame update
    void Start()
    {
        this.panzerCommandSender = PanzerCommandSender.withConnection(Host, Port, ThrottleInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
