using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOverlord : MonoBehaviour, LightFollower
{
    float m_TargetScale = 0.0f;

    private void Update()
    {
        Time.timeScale = Mathf.Lerp(Time.timeScale, m_TargetScale, Time.unscaledDeltaTime);
    }

    public void ReactToColor(LightColor lightColor, float percent)
    {
        m_TargetScale = 1.0f - percent;
    }
}
