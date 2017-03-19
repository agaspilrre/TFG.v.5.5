using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCameraSize : MonoBehaviour {

    public bool lerp = false;
    public int size =0;
    public float velocidadEscala = 0.2F;

    public Vector2 vector;

    float vectorGuardado;

    public Camera cam;

    camaraMOV camMov;

    void Start()
    {
        camMov = cam.GetComponent<camaraMOV>();
        vectorGuardado = cam.orthographicSize;
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
      
        if (lerp)
        {
            cam.orthographicSize = cam.orthographicSize + (velocidadEscala * Time.deltaTime);
            camMov.setMoveExtra(vector);

            if(cam.orthographicSize >= size)
            {
                lerp = false;               
            }
                
            if (cam.orthographicSize <= vectorGuardado)
            {
                lerp = false;
                camMov.setMoveExtra(new Vector2(0,0));
            }              
        }
    }

    public void setVelocidadEscala(float a)
    {    
 
        velocidadEscala = a * Mathf.Abs(velocidadEscala);

    }
}
