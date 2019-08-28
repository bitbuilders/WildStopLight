using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyGoodness : MonoBehaviour
{
    [SerializeField, Range(0.0f, 360.0f)] float MinRotation = 30.0f;
    [SerializeField, Range(0.0f, 360.0f)] float MaxRotation = 90.0f;
    [SerializeField, Range(0.0f, 10.0f)] float MinScale = 0.25f;
    [SerializeField, Range(0.0f, 10.0f)] float MaxScale = 4.0f;

    Vector3 m_Torque = Vector3.zero;
    float m_Lifetime = 5.0f;

    private void Start()
    {
        m_Torque = new Vector3(Random.Range(MinRotation, MaxRotation), Random.Range(MinRotation, MaxRotation), Random.Range(MinRotation, MaxRotation));
        transform.localScale = Vector3.one * Random.Range(MinScale, MaxScale);
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddTorque(m_Torque * Time.deltaTime, ForceMode.Force);

        m_Lifetime -= Time.deltaTime;
        if (m_Lifetime <= 0.0f) Destroy(gameObject);
    }
}
