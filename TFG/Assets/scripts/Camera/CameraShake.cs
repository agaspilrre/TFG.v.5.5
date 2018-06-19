using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE REALIZAR UN SHAKE DE LA CAMARA
/// </summary>
public class CameraShake : MonoBehaviour {

    /// <summary>
    /// Intensidad del shake de la camara
    /// </summary>
    [SerializeField][Range(0,5)]
    float shakeIntensity;

    /// <summary>
    /// Tiempo del shake
    /// </summary>
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

    /// <summary>
    /// Metodo para realizar el shake
    /// </summary>
    public void Shake()
    {
        shakeAux = shakeIntensity;
    }

    /// <summary>
    /// Metodo para realizar el shake con la intensidad que recibe
    /// </summary>
    /// <param name="intensity"></param>
    public void Shake(float intensity)
    {
        shakeAux = intensity;
    }
}
