using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpacialUI : MonoBehaviour
{
    private bool pingPong = false;
    private float leftLevel = 0f;
    private float rightLevel = 0f;
    private ControllerInput input;

    public Text Text;  // set by Instector

    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.Subscribe(OnPingPong);
        EventBus.Instance.Subscribe(OnController);
        this.Text.text = "";
    }

    void OnPingPong(bool pingPong) {
        this.pingPong = pingPong;
    }

    void OnController(ControllerInput input) {
        this.leftLevel = input.LeftLevel;
        this.rightLevel = input.RightLevel;
        this.input = input;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.Text == null)
            return;

        string connectionText = this.pingPong ? "connected" : "disconnected";
        string text = $@"Controller {connectionText}
" + input.DisplayString();

        this.Text.text = text;
    }
}
