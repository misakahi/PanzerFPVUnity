using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanzerCommandSenderGameObject : MonoBehaviour
{
    public string host = "localhost";
    public int port = 50051;
    private PanzerCommandSender panzerCommandSender;

    // Start is called before the first frame update
    void Start()
    {
        this.panzerCommandSender = PanzerCommandSender.withConnection(host, port);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
