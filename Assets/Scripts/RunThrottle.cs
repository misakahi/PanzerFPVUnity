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
    private Stopwatch Stopwatch = new Stopwatch();
    private bool IsLocked = false;

    public RunThrottle(int interval /* milliseconds */)
    {
        this.Interval = interval;
        this.Stopwatch.Start();
    }

    public async void Run(Action action)
    {
        var elasped = Stopwatch.Elapsed;
        if (!IsLocked && elasped.Milliseconds > this.Interval)
        {
            IsLocked = true;
            await Task.Run(() => action.Invoke());
            Stopwatch.Restart();
            IsLocked = false;
        }
    }
}
