using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /// <summary>
    /// posicion de la camara
    /// </summary>
    Transform cameraTransform;

    /// <summary>
    /// posicion del target de la camara
    /// </summary>
    Transform target;

    /// <summary>
    /// posicion del jugador
    /// </summary>
    Transform player;

    /// <summary>
    /// variable para activar movimiento de la camara
    /// </summary>
    [SerializeField]
    bool isActive = true;

    /// <summary>
    /// 3 estados de la camara
    /// </summary>
    [SerializeField]
    enum State{
        active, 
        inactive,
        blocked
    };

    /// <summary>
    /// direccion de bloqueo de la camara (ancho alto)
    /// </summary>
    int blockedDirection; //0 width 1 heigth

    /// <summary>
    /// estado de la camra
    /// </summary>
    [SerializeField]
    State cameraState;


    /// <summary>
    /// altura inicial de la camara
    /// </summary>
    [SerializeField]
    float startHeigth = 5;

    /// <summary>
    /// direccion en la x, 0 es derecha 1 es izquierda
    /// </summary>
    int widthDirecion;
    /// <summary>
    /// direccion del giro, 0 es arriba 1 es abajo
    /// </summary>
    int heightDirection;


    /// <summary>
    /// limites de ancho de la camara
    /// </summary>
    [SerializeField][Range(0,50)]
    float widthMax = 3f;
    [SerializeField][Range(0,-50)]
    float widthMin = -3f;


    /// <summary>
    /// limites de alto de la camara
    /// </summary>
    [SerializeField]
    [Range(0, 50)]
    float heigthMax = 3f; 
    [SerializeField]
    [Range(0, -50)]
    float heigthMin = -3f;

    /// <summary>
    /// velocidad de seguimiento en el interior de los limites
    /// </summary>
    [SerializeField]
    [Range(0, 1)]
    float veclocidadSeguimiento = 0.7F;

    /// <summary>
    /// velocidad de seguimiento en el exterior de los limites
    /// </summary>
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

    /// <summary>
    /// control de la camara, en funcion del estado en el que se encuentra hace un lerp de la posicion siempre y cuanod no se salga de los limites de esta
    /// </summary>
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

    /// <summary>
    /// reinicia el estado de la camara
    /// </summary>
    public void RestartCamera()
    {
        cameraState = State.active;
    }

    /// <summary>
    /// actualiza la posicion de la camara al cambiar de pantalla
    /// </summary>
    /// <param name="position"></param>
    public void ChangeGameScreen(Vector3 position)
    {
        cameraTransform.position = position;
    }

    /// <summary>
    /// cambio de camara
    /// </summary>
    /// <param name="state"></param>
    public void SetCameraState(string state)
    {
        if (state == "active")
            cameraState = State.active;
        else if (state == "inactive")
            cameraState = State.inactive;
        else
        {
            cameraState = State.blocked;

            if (state == "Camera/BlockWidth")
                blockedDirection = 0;
            else if (state == "Camera/BlockHeigth")
                blockedDirection = 1;
            else
                blockedDirection = 2;
        }

    }

    /// <summary>
    /// compara las posiciones para que no se salga de los limites
    /// </summary>
    /// <returns></returns>
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
