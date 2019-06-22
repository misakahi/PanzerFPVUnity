using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus {

    static EventBus instance;
    public static EventBus Instance
    {
        get {
            if (instance == null) {
                instance = new EventBus ();
            }
            return instance;
        }
    }
    private EventBus() {}

    // PingPong
    public delegate void OnPingPong(bool success);
    event OnPingPong _OnPingPong;

    public void Subscribe(OnPingPong onPingPong) {
        _OnPingPong += onPingPong;
    }

    public void NotifyPingPong(bool pingPong) {
        if (_OnPingPong != null) _OnPingPong(pingPong);
    }

    // Controller
    public delegate void OnController(float leftLevel, float rightLevel);
    event OnController _onController;

    public void Subscribe(OnController onController) {
        _onController += onController;
    }

    public void NotifyController(float leftLevel, float rightLevel) {
        if(_onController != null) _onController(leftLevel, rightLevel);
    }
}