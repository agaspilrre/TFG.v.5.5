using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCameraSize : MonoBehaviour {

    bool lerp = false;
    public int size =0;
    public float velocidadEscala = 0.2F;

    public Vector2 vector;

    public Camera cam;

    camaraMOV camMov;

    void Start()
    {
        camMov = cam.GetComponent<camaraMOV>();
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

            camMov.setMoveExtra(vector);

            if(cam.orthographicSize >= size || cam.orthographicSize ==13)
            {
                lerp = false;
                velocidadEscala = Mathf.Abs(velocidadEscala);               
            }       
            if (cam.orthographicSize == 13)
            {
                camMov.setMoveExtra(new Vector2(0,0));
            }              
        }
    }

    public void setVelocidadEscala(float a)
    {    
 
        velocidadEscala = a * Mathf.Abs(velocidadEscala);

    }
}
