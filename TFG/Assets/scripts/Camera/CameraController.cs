using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Transform cameraTransform;
    Transform target;
    Transform player;

    [SerializeField]
    bool isActive = true;

    enum State{
        active, 
        inactive,
        blocked
    };

    int blockedDirection; //0 width 1 heigth

    State cameraState;

    [SerializeField]
    float startHeigth = 5;

    //direccion en la x, 0 es derecha 1 es izquierda
    int widthDirecion;
    //direccion del giro, 0 es arriba 1 es abajo
    int heightDirection;

    [SerializeField][Range(0,50)]
    float widthMax = 3f;
    [SerializeField][Range(0,-50)]
    float widthMin = -3f;

    [SerializeField]
    [Range(0, 50)]
    float heigthMax = 3f; 
    [SerializeField]
    [Range(0, -50)]
    float heigthMin = -3f;

    [SerializeField]
    [Range(0, 1)]
    float veclocidadSeguimiento = 0.7F;

    [SerializeField]
    float velocidadFueraDeCaja = 1.5f;

    void Start ()
    {
        blockedDirection = 0;

        if (isActive)
            cameraState = State.active;
        else
            cameraState = State.inactive;

        target = GameObject.Find("PlayerTarget").GetComponent<Transform>();
        cameraTransform = Camera.main.GetComponent<Transform>();
        player = GameObject.Find("Personaje").GetComponent<Transform>();
    }
	
	void Update ()
    {
        if(cameraState != State.inactive)
        {
            UpdateCamera();
        }
    }

    public void UpdateCamera()
    {
        if(cameraState == State.active || (cameraState == State.blocked && blockedDirection == 1))
        {
            bool movPermitido = CompareX();

            Vector3 aux;

            if (movPermitido & widthDirecion == 0)
            {
                Vector3 newPos = new Vector3(target.position.x - widthMax, cameraTransform.position.y, -10);
                cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos, velocidadFueraDeCaja * Time.deltaTime);
            }
            else
            if (movPermitido & widthDirecion == 1)
            {
                Vector3 newPos = new Vector3(target.position.x - widthMin, cameraTransform.position.y, -10);
                cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos, velocidadFueraDeCaja * Time.deltaTime);
            }
            aux = new Vector3(target.position.x, cameraTransform.position.y, cameraTransform.position.z);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, aux, veclocidadSeguimiento * Time.deltaTime);   
        }

        if(cameraState == State.active || (cameraState == State.blocked && blockedDirection == 0))
        {
            bool movAlturaPermitido = CompareY();

            Vector3 aux;

            if (movAlturaPermitido & heightDirection == 0)
            {
                Vector3 newPos = new Vector3(cameraTransform.position.x, target.position.y - heigthMax - startHeigth, -10);
                cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos, velocidadFueraDeCaja * Time.deltaTime);
            }
            else
            if (movAlturaPermitido & heightDirection == 1)
            {
                Vector3 newPos = new Vector3(cameraTransform.position.x, target.position.y - heigthMin - startHeigth, -10);
                cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos, velocidadFueraDeCaja * Time.deltaTime);
            }

            aux = new Vector3(cameraTransform.position.x, target.position.y - startHeigth, cameraTransform.position.z);
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, aux, veclocidadSeguimiento * Time.deltaTime);
            
        }

        heightDirection = 3;
        widthDirecion = 3;
    }

    public void SetCameraState(string state)
    {
        if (state == "active")
            cameraState = State.active;
        else if (state == "inactive")
            cameraState = State.inactive;
    }

    public void SetCameraState(string state, string direction)
    {
        cameraState = State.blocked;

        if (direction == "Camera/BlockWidth")
            blockedDirection = 0;
        else if (direction == "Camera/BlockHeigth")
            blockedDirection = 1;
        else
            blockedDirection = 2;
    }

    #region compare position
    //mirar si se sale del rango
    bool CompareX()
    {
        //se sale por la derecha
        if (target.position.x - cameraTransform.position.x > widthMax)
        {
            widthDirecion = 0;
            return true;
        }
        // se sale por la izquierda
        if (target.position.x - cameraTransform.position.x < widthMin)
        {
            widthDirecion = 1;
            return true;
        }
        return false;
    }

    //mirar si se sale de rango
    bool CompareY()
    {
        //se sale por arriba
        if (target.position.y - cameraTransform.position.y - startHeigth > heigthMax)
        {
            heightDirection = 0;
            return true;
        }// se sale por abajo
        if (target.position.y - cameraTransform.position.y - startHeigth < heigthMin)
        {
            heightDirection = 1;
            return true;
        }
        return false;
    }
    #endregion
}
