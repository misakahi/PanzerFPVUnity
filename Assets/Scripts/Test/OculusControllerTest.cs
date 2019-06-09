﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusControllerTest : MonoBehaviour
{
    PanzerAdaptor PanzerAdaptor;

    // Start is called before the first frame update
    void Start()
    {
        PanzerAdaptor = new PanzerAdaptor();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Primary Index Trigger");   
        }
        // Vector2 stickL = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        // Vector2 stickR = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        Vector2 stickL = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        Vector2 stickR = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);

        if (!stickL.Equals(Vector2.zero) || !stickR.Equals(Vector2.zero)) {
            Debug.Log("stick L" + stickL);
            Debug.Log("stick R" + stickR);
            this.transform.position += new Vector3(stickR.x * 0.1f, stickR.y * 0.1f, 0);
            PanzerAdaptor.remoteControll(stickL, stickR);
        }
    }
}
