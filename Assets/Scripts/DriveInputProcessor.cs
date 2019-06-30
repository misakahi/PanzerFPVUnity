using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hand
{
    LEFT,
    RIGHT
}

public class DriveInputProcessor
{
    public OVRInput.Controller ControllerType { get; }
    public OVRInput.RawButton RawButton { get; }

    public float MinLevelDelta { get; }
    public float DistToLevel { get; }

    private float level { get; set; }
    private Vector3 origin { get; set; }

    public DriveInputProcessor(Hand hand, float minLevelDelta, float deltaToLevel) {
        this.ControllerType = hand == Hand.LEFT ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        this.RawButton      = hand == Hand.LEFT ? OVRInput.RawButton.LIndexTrigger : OVRInput.RawButton.RIndexTrigger;
        this.MinLevelDelta  = minLevelDelta;
        this.DistToLevel    = deltaToLevel;
    }

    public Vector3 GetLocalControllerPosition() {
        return OVRInput.GetLocalControllerPosition(ControllerType);
    }

    public float GetLevel() {
        var currentPos = GetLocalControllerPosition();
        if (OVRInput.GetDown(RawButton))
        {
            origin = currentPos;
            level = 0f;
        }
        else if (OVRInput.Get(RawButton))
        {
            // calculate level diff to the previous value
            Vector3 delta = currentPos - origin;
            float tempLevel = delta.z * DistToLevel;
            float levelDelta = Mathf.Abs(tempLevel - level);

            // update only when level delta is larger than threshold
            if (levelDelta >= MinLevelDelta)
                level = tempLevel;
        }
        else if (OVRInput.GetUp(RawButton)) {
            origin = Vector3.zero;
            level = 0f;
        }
        return level = Mathf.Clamp(level, -1, 1);
    }
}
