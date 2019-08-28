using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LightFollowers : UnityEvent<LightColor, float> { }

public class LightBrain : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] public float StartTime = 3.0f;
    [SerializeField] public UnityEngine.Light GreenLight = null;
    [SerializeField] public UnityEngine.Light YellowLight = null;
    [SerializeField] public UnityEngine.Light RedLight = null;
    [SerializeField] public LightFollowers Followers = null;

    public float Time { get; set; }

    Light m_Light;
    int m_TotalLightColors = 0;
    
    void Start()
    {
        Time = StartTime;
        m_Light = new Green();
        m_TotalLightColors = System.Enum.GetNames(typeof(LightColor)).Length - 1;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && ValidSwap(typeof(Green)))
            m_Light = new Green();
        if (Input.GetKeyDown(KeyCode.Alpha2) && ValidSwap(typeof(Yellow)))
            m_Light = new Yellow();
        if (Input.GetKeyDown(KeyCode.Alpha3) && ValidSwap(typeof(Red)))
            m_Light = new Red();

        GreenLight.enabled = false;
        YellowLight.enabled = false;
        RedLight.enabled = false;

        Light newLight = m_Light.Do(this);

        if (newLight != null) m_Light = newLight;

        LightColor color = GetCurrentLightColor();
        float percent = GetLightPercent(color);
        Followers.Invoke(color, percent);
    }

    bool ValidSwap(Type next)
    {
        return m_Light.Next == next;
    }

    LightColor GetCurrentLightColor()
    {
        if (typeof(Green) == m_Light.GetType()) return LightColor.GREEN;
        else if (typeof(Yellow) == m_Light.GetType()) return LightColor.YELLOW;
        else return LightColor.RED;
    }

    float GetLightPercent(LightColor lightColor)
    {
        return (float)lightColor / (float)m_TotalLightColors;
    }
}
