using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    [SerializeField][Range(0,5)]
    float shakeIntensity;
    [SerializeField][Range(0,0.5f)]
    float shakeDecay;

    float shakeAux;

	void Update ()
    {
        if (shakeAux > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shakeIntensity;
            shakeAux -= shakeDecay;
        }
    }

    public void Shake()
    {
        shakeAux = shakeIntensity;
    }

    public void Shake(float intensity)
    {
        shakeAux = intensity;
    }
}
