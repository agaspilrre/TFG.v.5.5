using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCameraSize : MonoBehaviour
{

    public bool lerp = false;
    public int size = 0;
    public float velocidadEscala = 0.2F;

    public Vector2 vector;

    float vectorGuardado;

    Vector3 vGuardado;

    public Camera cam;

    camaraMOV camMov;

    void Start()
    {
        camMov = cam.GetComponent<camaraMOV>();
        vectorGuardado = cam.orthographicSize;
        vGuardado = vector;
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
        if (size == vectorGuardado)
            velocidadEscala = 0;
        if (lerp)
        {
            if (size > vectorGuardado)
                cam.orthographicSize = cam.orthographicSize + (velocidadEscala * Time.deltaTime);
            else
                cam.orthographicSize = cam.orthographicSize - (velocidadEscala * Time.deltaTime);

            camMov.setMoveExtra(vector);


            if (cam.orthographicSize >= size && size > vectorGuardado)
            {
                lerp = false;
            }
            else if (size >= cam.orthographicSize && vectorGuardado > size)
            {
                lerp = false;
            }

            if (cam.orthographicSize <= vectorGuardado && size > vectorGuardado)
            {
                lerp = false;

            }
            else if (vectorGuardado <= cam.orthographicSize && vectorGuardado > size)
            {
                lerp = false;
            }
        }
    }

    public void setVelocidadEscala(float a)
    {

        velocidadEscala = a * Mathf.Abs(velocidadEscala);

    }

    public void setMoveExtra(Vector3 a)
    {
        vector = a;
    }

    public void setMoveExtraGuardado()
    {
        vector = vGuardado;
    }
}
