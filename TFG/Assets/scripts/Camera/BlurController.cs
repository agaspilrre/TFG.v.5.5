using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class BlurController : MonoBehaviour {

    [SerializeField]
    float maxBlur;

    [SerializeField]
    float blurPerSecond;
    [SerializeField]
    float anglePerSecond;

    Vortex vortexReference;
    MotionBlur blurReference;

    public static BlurController instance;

    [SerializeField]bool active;

    float blur;
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

    void Update()
    {
        if (active && blur < maxBlur)
        {
            blur += blurPerSecond * Time.deltaTime;
            angle += anglePerSecond * Time.deltaTime;

            vortexReference.angle = angle;
            blurReference.blurAmount = blur;
        }
   
	}

    public void SetActiveBlur()
    {
        if (active)
        {
            ResetBlur();
            active = false;
        }
        else
        {
            active = true;
        }
    }

    public void ResetBlur()
    {
        print("entre");
        active = false;
        blur = 0;
        angle = 0;
        vortexReference.angle = angle;
        blurReference.blurAmount = blur;
    }
}
