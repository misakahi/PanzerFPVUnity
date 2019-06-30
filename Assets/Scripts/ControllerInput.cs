using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ControllerInput
{
    public float LeftLevel { get; }
    public float RightLevel { get; }
    public float TurrentRot { get; }
    public float TurrentUpDown { get; }

    public ControllerInput(float leftLevel, float rightLevel, float turretRot, float turretUpDown)
    {
        this.LeftLevel = leftLevel;
        this.RightLevel = rightLevel;
        this.TurrentRot = turretRot;
        this.TurrentUpDown = turretUpDown;
    }

    public float LevelAbs() {
        return Mathf.Max(Mathf.Abs(LeftLevel), Mathf.Abs(RightLevel));
    }

    public string DisplayString()
    {
        return
$@"Drive (left):    {this.LeftLevel}
Drive (right):   {this.RightLevel}
Turret (rot):    {this.RightLevel}
Turret (updown): {this.RightLevel}
";
    }
}