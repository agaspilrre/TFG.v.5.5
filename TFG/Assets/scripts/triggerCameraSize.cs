using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCameraSize : MonoBehaviour {

    bool lerp = false;
    public int size =0;
    public float velocidadEscala = 0.2F;

    public Camera cam;

    void Start()
    {

    }

    public int getSize()
    {
        return size;
    }

    public void setLerp(bool a)
    {
        lerp = a;
    }

    void Update()
    {
        if(lerp)
        {
            cam.orthographicSize = cam.orthographicSize + velocidadEscala;

            if(cam.orthographicSize >= size || cam.orthographicSize ==13)
            {
                lerp = false;
                velocidadEscala = Mathf.Abs(velocidadEscala);
            }
                
            
        }
    }

    public void setVelocidadEscalaNegativa()
    {
        velocidadEscala = -velocidadEscala;
    }
}
