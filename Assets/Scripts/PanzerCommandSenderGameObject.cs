using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanzerCommandSenderGameObject : MonoBehaviour
{
    public const string CONFIG_SECTION = "PanzerServer";

    public string Host;
    public int Port;
    public int ThrottleInterval;
    private PanzerCommandSender panzerCommandSender;

    // Start is called before the first frame update
    void Start()
    {
        Host = Config.ReadValue(CONFIG_SECTION, "Host", Host);
        Port = int.Parse(Config.ReadValue(CONFIG_SECTION, "Port", Port.ToString()));
        ThrottleInterval = int.Parse(Config.ReadValue(CONFIG_SECTION, "ThrottleInterval", ThrottleInterval.ToString()));

        this.panzerCommandSender = PanzerCommandSender.withConnection(Host, Port, ThrottleInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
