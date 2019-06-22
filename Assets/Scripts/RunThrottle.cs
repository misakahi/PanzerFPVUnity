using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class RunThrottle
{
    int Interval { get; set; }
    private Stopwatch stopwatch = new Stopwatch();
    private bool isLocked = false;

    public RunThrottle(int interval /* milliseconds */)
    {
        this.Interval = interval;
        this.stopwatch.Start();
    }

    public async void Run(Action action)
    {
        var elasped = stopwatch.Elapsed;
        if (!isLocked && elasped.Milliseconds > this.Interval)
        {
            isLocked = true;
            await Task.Run(() => action.Invoke());
            stopwatch.Restart();
            isLocked = false;
        }
    }
}
