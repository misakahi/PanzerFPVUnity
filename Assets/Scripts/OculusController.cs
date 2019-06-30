using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using UnityEngine;


enum LR {
    LEFT, RIGHT
}

public class OculusController : MonoBehaviour
{
    PanzerCommandSender PanzerAdaptor;

    Vector3 leftPosZero;
    Vector3 rightPosZero; 

    public float deltaLevelRatio = 3f;

    float leftLevel = 0f;
    float rightLevel = 0f;

    public int SendCommandInterval = 100;  // milliseconds
    public float minLevelDelta = 0.05f;
    public bool enableVibration = false;

    RunThrottle SendCommandThrottle;

    private GUIStyle style = new GUIStyle();

    // Start is called before the first frame update
    void Start()
    {
        this.style.fontSize = 30;
        this.SendCommandThrottle = new RunThrottle(SendCommandInterval);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        // if (!stickL.Equals(Vector2.zero) || !stickR.Equals(Vector2.zero)) {
        //     Debug.Log("stick L" + stickL);
        //     Debug.Log("stick R" + stickR);
        //     this.transform.position += new Vector3(stickR.x * 0.1f, stickR.y * 0.1f, 0);
        //     PanzerAdaptor.remoteControll(stickL, stickR);
        // }

        // left input
        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            this.leftPosZero = GetControllerPos(LR.LEFT);
        }
        else if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Vector3 delta = GetControllerPos(LR.LEFT) - this.leftPosZero;
            float level = delta.z * deltaLevelRatio;
            if (Mathf.Abs(level - this.leftLevel) >= minLevelDelta)
                this.leftLevel = level;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)) {
            this.leftPosZero = Vector3.zero;
            this.leftLevel = 0f;
        }

        // right input
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            this.rightPosZero = GetControllerPos(LR.RIGHT);
        }
        else if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Vector3 delta = GetControllerPos(LR.RIGHT) - this.rightPosZero;
            float level = delta.z * deltaLevelRatio;
            if (Mathf.Abs(level - this.rightLevel) >= minLevelDelta)
                this.rightLevel = level;
        }
        else if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) {
            this.rightPosZero = Vector3.zero;
            this.rightLevel = 0f;
        }

        // level has to be in [-1, 1]
        this.leftLevel = Mathf.Clamp(this.leftLevel, -1, 1);
        this.rightLevel = Mathf.Clamp(this.rightLevel, -1, 1);

        if (leftLevel != 0f || rightLevel != 0f || stickR != Vector2.zero)
        {
            SendCommandThrottle.Run(() =>
            {
                try
                {
                    PanzerCommandSender.RemoteControl(leftLevel, rightLevel, 0, 0);
                }
                catch (RpcException e)
                {
                    // Debug.LogException(e);
                }
            });

        }

        if (this.enableVibration) {
            Vibrate();
        }
        EventBus.Instance.NotifyController(this.leftLevel, this.rightLevel);
    }

    Vector3 GetControllerPos(LR leftRight)
    {
        var controller = leftRight == LR.LEFT ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        return OVRInput.GetLocalControllerPosition(controller);
    }

    public float Level() {
        return Mathf.Max(Mathf.Abs(leftLevel), Mathf.Abs(rightLevel));
    }

    void Vibrate(float level, OVRInput.Controller controller) {
        float absLevel = Mathf.Min(1, Mathf.Abs(level));
        OVRInput.SetControllerVibration(1, absLevel, controller);
    }

    void Vibrate() {
        Vibrate(this.leftLevel, OVRInput.Controller.LTouch);
        Vibrate(this.rightLevel, OVRInput.Controller.RTouch);
    }
}
