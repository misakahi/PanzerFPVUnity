﻿using System.Collections;
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

    public bool EnableVibration = false;
    public bool StickWithCameraDirection = false;

    DriveInputProcessor leftInputProcessor;
    DriveInputProcessor rightInputProcessor;

    // Start is called before the first frame update
    void Start()
    {
        this.leftInputProcessor  = new DriveInputProcessor(Hand.LEFT, MinLevelDelta, DistToLevel);
        this.rightInputProcessor = new DriveInputProcessor(Hand.RIGHT, MinLevelDelta, DistToLevel);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        Vector3 direction = StickWithCameraDirection ? Camera.main.transform.forward : Vector3.forward;
        float leftLevel  = leftInputProcessor.GetLevel(direction);
        float rightLevel = rightInputProcessor.GetLevel(direction);

        ControllerInput input = new ControllerInput(leftLevel, rightLevel, stickR.x, stickR.y);

        PanzerCommandSender.RemoteControlThrottle(input);

        if (this.EnableVibration)
            Vibrate(leftLevel, rightLevel);

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
