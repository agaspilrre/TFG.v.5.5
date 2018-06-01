using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BlurController : MonoBehaviour {

    /// <summary>
    /// blur maximo ajustable en inspector
    /// </summary>
    [SerializeField]
    float maxBlur;

    /// <summary>
    /// valor de aumento por tick del blur
    /// </summary>
    [SerializeField]
    float blurPerSecond;

    /// <summary>
    /// aumento del angulo de distorsion por segundo
    /// </summary>
    [SerializeField]
    float anglePerSecond;

    /// <summary>
    /// referencias a scripts que controlan los shaders de distorsion
    /// </summary>
    Vortex vortexReference;
    MotionBlur blurReference;

    /// <summary>
    /// referencia estatica a la clase
    /// </summary>
    public static BlurController instance;

    /// <summary>
    /// booleano para activar el blur al comeinzo
    /// </summary>
    [SerializeField]bool active;

    /// <summary>
    /// varuable del blur actual
    /// </summary>
    float blur;

    /// <summary>
    /// variable de angulo actual
    /// </summary>
    float angle;

    private void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        blur = 0;
        angle = 0;

        vortexReference = Camera.main.GetComponent<Vortex>();
        blurReference = Camera.main.GetComponent<MotionBlur>();
	}

	void Update ()
    {
		if(active && blur < maxBlur)
        {
            blur += blurPerSecond * Time.deltaTime;
            angle += anglePerSecond * Time.deltaTime;

            vortexReference.angle = angle;
            blurReference.blurAmount = blur;
        }
	}

    /// <summary>
    /// activa y desactiva el blur
    /// </summary>
    public void SetActiveBlur()
    {
        if (active)
            active = false;
        else
            active = true;
    }

    /// <summary>
    /// reinicia los valores del blur
    /// </summary>
    public void ResetBlur()
    {
        blur = 0;
        angle = 0;
    }
}
