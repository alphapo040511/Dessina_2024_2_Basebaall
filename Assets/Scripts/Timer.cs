using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float coolTime = 0.1f;
    private float currentTime = 0;
    private bool isRunning = false;
    private bool isReady = true;

    public Timer(float time)
    {
        coolTime = time;
        currentTime = 0;
        isRunning = false;
        isReady = true;
    }

    public void ResetTimer()
    {
        currentTime = coolTime;
        isRunning = true;
        isReady = false;
    }

    public void TimeUpdata(float deltatime)
    {
        if (!isRunning) return;

        currentTime -= deltatime;
        if(currentTime <= 0)
        {
            isRunning = false;
            isReady = true;
        }
    }

    public bool ReadyCheck()
    {
        return isReady;
    }
}
