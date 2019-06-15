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

    public RunThrottle(int interval /* milliseconds */)
    {
        this.Interval = interval;
        this.Stopwatch.Start();
    }

    public async void Run(Action action)
    {
        var elasped = Stopwatch.Elapsed;
        if (elasped.Milliseconds > this.Interval)
        {
            await Task.Run(() => action.Invoke());
            Stopwatch.Restart();
        }
    }
}
