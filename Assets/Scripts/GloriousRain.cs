using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloriousRain : MonoBehaviour, LightFollower
{
    [SerializeField] public GameObject RainTemplate = null;
    [SerializeField] public BoxCollider RainLocation = null;
    [SerializeField] public AnimationCurve SpeedOverColor = null;

    float m_CurrentSpeed = 1.0f;
    float m_TargetSpeed = 1.0f;
    float m_Time = 0.0f;

    private void Update()
    {
        m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_TargetSpeed, Time.unscaledDeltaTime);

        m_Time += Time.unscaledTime * m_CurrentSpeed;
        if (m_Time >= 1.0f)
        {
            m_Time = 0.0f;
            CreateRainDrop();
        }
    }

    void CreateRainDrop()
    {
        GameObject go = Instantiate(RainTemplate);

        Vector3 min = RainLocation.bounds.min;
        Vector3 max = RainLocation.bounds.max;
        Vector3 position = new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
        go.transform.position = position;
    }

    public void ReactToColor(LightColor lightColor, float percent)
    {
        m_TargetSpeed = SpeedOverColor.Evaluate(percent);
    }
}
