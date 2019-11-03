using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    public List<TimerObject> timers = new List<TimerObject>();

    void Update()
    {
        if (timers.Count > 0)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (Time.time > timers[i].timer)
                {
                    timers[i].action();

                    timers.RemoveAt(i);
                }
            }
        }
    }

    public void AddToTimer(float duration, TimerObject.ExecutableAction method)
    {
        TimerObject t = new TimerObject();
        t.timer = Time.time + duration;
        t.action = method;

        timers.Add(t);
    }
}
