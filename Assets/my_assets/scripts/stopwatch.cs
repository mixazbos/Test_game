using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class stopwatch : MonoBehaviour
{
    bool stopwatchEnabled = false;
    float currTime;

    public Text ElapsedTimeText, ElapsedTimeTextEnd;

    void Start()
    {
        currTime = 0;
        stopwatchEnabled = true;
    }

    void Update()
    {
        if (stopwatchEnabled)
            currTime = currTime + Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(currTime);
        ElapsedTimeText.text = ElapsedTimeTextEnd.text = time.ToString(@"mm\:ss\:fff");
    }

    public void StopStopwatch()
    {
        stopwatchEnabled = false;
    }
}
