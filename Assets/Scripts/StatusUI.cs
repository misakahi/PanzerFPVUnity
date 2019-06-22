using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    private bool pingPong = false;
    private float leftLevel = 0f;
    private float rightLevel = 0f;

    public Text Text;  // set by Instector

    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.Subscribe(OnPingPong);
        EventBus.Instance.Subscribe(OnController);
    }

    void OnPingPong(bool pingPong) {
        this.pingPong = pingPong;
    }

    void OnController(float leftLevel, float rightLevel) {
        this.leftLevel = leftLevel;
        this.rightLevel = rightLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Text == null)
            return;

        string text = 
$@"
Ping Pong:   {this.pingPong}
Left Level:  {this.leftLevel}
Right Level: {this.rightLevel}
";

        this.Text.text = text;
    }
}
