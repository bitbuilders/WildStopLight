using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLight : MonoBehaviour
{
    [SerializeField] Player m_Player = null;
    [SerializeField] AnimationCurve m_FollowCurve = null;
    [SerializeField] [Range(0.0f, 5.0f)] float m_RefreshRate = 0.5f;
    [SerializeField] [Range(0.0f, 20.0f)] float m_Distance = 8.0f;
    [SerializeField] [Range(0.0f, 20.0f)] float m_Speed = 5.0f;

    Vector3 m_TargetPosition;
    Vector3 m_LastPosition;
    float m_Time = 1000.0f;

    void LateUpdate()
    {
        m_Time = 0.0f;
        m_TargetPosition = m_Player.transform.position + m_Player.transform.rotation * Vector3.forward * m_Distance;
        m_LastPosition = transform.position;

        float t = m_Time / m_RefreshRate;
        float p = m_FollowCurve.Evaluate(t);
        transform.position = Vector3.Slerp(transform.position, m_TargetPosition, Time.deltaTime * m_Speed);

        transform.LookAt(m_Player.transform.position + Vector3.down * 1.25f);
    }
}
