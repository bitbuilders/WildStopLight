using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Light
{
    float m_Speed = 1.0f;

    public Green()
    {
        Next = typeof(Yellow);
    }

    public override Light Do(LightBrain brain)
    {
        brain.GreenLight.enabled = true;

        brain.Time -= Time.unscaledDeltaTime * m_Speed;
        
        if (brain.Time <= 0.0f)
        {
            brain.Time = brain.StartTime;
            return new Yellow();
        }

        return null;
    }
}
