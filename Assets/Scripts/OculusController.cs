using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using UnityEngine;


public class OculusController : MonoBehaviour
{
    PanzerCommandSender PanzerAdaptor;

    // parameter for DriveInputProcessor
    public float DistToLevel = 3f;
    public float MinLevelDelta = 0.05f;

    public int SendCommandInterval = 100;  // milliseconds
    public bool EnableVibration = false;

    RunThrottle SendCommandThrottle;
    DriveInputProcessor leftInputProcessor;
    DriveInputProcessor rightInputProcessor;

    // Start is called before the first frame update
    void Start()
    {
        this.SendCommandThrottle = new RunThrottle(SendCommandInterval);
        this.leftInputProcessor  = new DriveInputProcessor(Hand.LEFT, MinLevelDelta, DistToLevel);
        this.rightInputProcessor = new DriveInputProcessor(Hand.RIGHT, MinLevelDelta, DistToLevel);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        float leftLevel  = leftInputProcessor.GetLevel();
        float rightLevel = rightInputProcessor.GetLevel();

        ControllerInput input = new ControllerInput(leftLevel, rightLevel, stickR.x, stickR.y);

        if (!input.IsZero())
        {
            SendCommandThrottle.Run(() =>
            {
                try
                {
                    PanzerCommandSender.RemoteControl(input);
                }
                catch (RpcException e)
                {
                    // Debug.LogException(e);
                }
            });
        }

        if (this.EnableVibration) {
            Vibrate(leftLevel, rightLevel);
        }

        EventBus.Instance.NotifyController(input);
    }

    void Vibrate(float level, OVRInput.Controller controller) {
        float amp = Mathf.Min(1, Mathf.Abs(level));
        OVRInput.SetControllerVibration(1, amp, controller);
    }

    void Vibrate(float leftLevel, float rightLevel) {
        Vibrate(leftLevel, OVRInput.Controller.LTouch);
        Vibrate(rightLevel, OVRInput.Controller.RTouch);
    }
}
