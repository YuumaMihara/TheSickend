using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] float speed;
    [SerializeField] float intensity;
 
    Light m_light;
    float t = 0f;
 
    // Start is called before the first frame update
    void Start()
    {
        m_light = GetComponent<Light>();
    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        m_light.intensity = intensity * curve.Evaluate(t * speed);
    }
}
