using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown {

    static bool waveTime = false;
    static float timer = 0.0f;

    public static bool IsWaveTime() 
    {
        return waveTime;
    }

    public static void SetWaveTime(bool v)
    {
        waveTime = v;
    }

    public static float GetTimer()
    {
        return timer;
    }

    public static void SetTimer(float f)
    {
        timer = f;
    }
}