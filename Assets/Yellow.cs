using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : Light
{
    float m_Speed = 2.0f;

    public override Light Do(LightBrain brain)
    {
        brain.YellowLight.enabled = true;

        brain.Time -= Time.deltaTime * m_Speed;
        if (brain.Time <= 0.0f)
        {
            brain.Time = brain.StartTime;
            return new Red();
        }

        return null;
    }
}
