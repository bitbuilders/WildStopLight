using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : Light
{
    float m_Speed = 1.5f;

    public Red()
    {
        Next = typeof(Green);
    }

    public override Light Do(LightBrain brain)
    {
        brain.RedLight.enabled = true;

        brain.Time -= Time.deltaTime * m_Speed;
        if (brain.Time <= 0.0f)
        {
            brain.Time = brain.StartTime;
            return new Green();
        }

        return null;
    }
}
