using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ControllerInput
{
    public float LeftLevel { get; }
    public float RightLevel { get; }
    public float TurretRot { get; }
    public float TurretUpDown { get; }

    public ControllerInput(float leftLevel, float rightLevel, float turretRot, float turretUpDown)
    {
        this.LeftLevel = leftLevel;
        this.RightLevel = rightLevel;
        this.TurretRot = turretRot;
        this.TurretUpDown = turretUpDown;
    }

    public float LevelAbs() {
        return Mathf.Max(Mathf.Abs(LeftLevel), Mathf.Abs(RightLevel));
    }

    public string DisplayString()
    {
        return
$@"Drive (left):    {this.LeftLevel}
Drive (right):   {this.RightLevel}
Turret (rot):    {this.TurretRot}
Turret (updown): {this.TurretUpDown}
";
    }

    public bool IsZero() {
        return LeftLevel == 0 && RightLevel == 0 && TurretRot == 0 && TurretUpDown == 0;
    }
}