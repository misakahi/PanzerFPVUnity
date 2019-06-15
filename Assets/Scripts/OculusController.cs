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
    public bool showInfo = false;

    float leftLevel = 0f;
    float rightLevel = 0f;

    public int SendCommandInterval = 100;  // milliseconds

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

        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger))
        {
            this.leftPosZero = GetControllerPos(LR.LEFT);
        }
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Vector3 delta = GetControllerPos(LR.LEFT) - this.leftPosZero;
            this.leftLevel = delta.z * deltaLevelRatio;
        }
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
        {
            this.rightPosZero = GetControllerPos(LR.RIGHT);
        }
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Vector3 delta = GetControllerPos(LR.RIGHT) - this.rightPosZero;
            rightLevel = delta.z * deltaLevelRatio;
        }
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
                    Debug.LogException(e);
                }
            });
        }

        SendCommandThrottle.Run(() =>
        {
            try
            {
                PanzerCommandSender.RemoteControl(0.1f, 0.2f, 0, 0);
            }
            catch (RpcException e)
            {
                // Debug.LogException(e);
            }
        });
    }

    void OnGUI()
    {
        if (showInfo)
        {
            GUI.TextField(new Rect(0, 220, 180, 50), "Left Level: " + this.leftLevel, style);
            GUI.TextField(new Rect(0, 270, 180, 50), "Right Level: " + this.rightLevel, style);
        }
    }

    Vector3 GetControllerPos(LR leftRight)
    {
        var controller = leftRight == LR.LEFT ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        return OVRInput.GetLocalControllerPosition(controller);
    }
}
