using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class onOffLightAnimation : MonoBehaviour
{
    public Light2D lt;

    public float maxRange = 0.54f;
    public float minRange = 0.31f;
    public float flickerSpeed = 0.5f;

    
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lt.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, flickerSpeed));
    }
}
