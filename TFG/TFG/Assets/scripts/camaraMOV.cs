using UnityEngine;
using System.Collections;

public class camaraMOV : MonoBehaviour {

    bool movPermitido;

    bool movAlturaPermitido;

    public Transform camaraTrans;
    public Transform personajeTrans;

    public float anchoMAX = 3f;
    public float anchoMIN = -3f;

    public float altoMAX = 3f;
    public float altoMIN = -3f;

    //distancia inicial entre camara y personaje
    float distanciaInicial;

    //direccion en la x, 0 es derecha 1 es izquierda

    int direccionAncho;

    //direccion del giro, 0 es arriba 1 es abajo

    int direccionAlto;


    // Use this for initialization
    void Start()
    {
        movPermitido = false;

        movAlturaPermitido = false;

        distanciaInicial = camaraTrans.position.y - personajeTrans.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //comparar posicion del personaje con el de la camara
        movPermitido = compararPosicion();

        movAlturaPermitido = compararAltura();

        //si el personaje se sale del rango de movimiento libre
        if (movPermitido & direccionAncho == 0)//diro derecha
        {
            //nueva posicion de la camara
            Vector3 newPos = new Vector3(personajeTrans.position.x - anchoMAX, camaraTrans.position.y, -10f);
            camaraTrans.position = newPos;

        }
        if (movPermitido & direccionAncho == 1)//giro izquierda
        {
            //nueva posicion de la camara
            Vector3 newPos = new Vector3(personajeTrans.position.x - anchoMIN, camaraTrans.position.y, -10f);
            camaraTrans.position = newPos;
        }
        if (movAlturaPermitido & direccionAlto == 0)//giro arriba
        {
            //nueva posicion de la camara
            Vector3 newPos = new Vector3(camaraTrans.position.x, personajeTrans.position.y - altoMAX + distanciaInicial, -10f);
            camaraTrans.position = newPos;
        }
        if (movAlturaPermitido & direccionAlto == 1)//giro abajo
        {
            //nueva posicion de la camara
            Vector3 newPos = new Vector3(camaraTrans.position.x, personajeTrans.position.y - altoMIN + distanciaInicial, -10f);
            camaraTrans.position = newPos;
        }

        //evitar que al volver a pasar se vuelva a meter en algun if sin querer
        direccionAlto = 3;
        direccionAncho = 3;

    }

    //mirar si se sale del rango
    bool compararPosicion()
    {
        //se sale por la derecha
        if (personajeTrans.position.x - camaraTrans.position.x > anchoMAX)
        {
            direccionAncho = 0;
            return true;        
        }
        // se sale por la izquierda
        if (personajeTrans.position.x - camaraTrans.position.x < anchoMIN)
        {
            direccionAncho = 1;
            return true;
        }
        return false;
    }

    //mirar si se sale de rango
    bool compararAltura()
    {
        //se sale por arriba
        if (personajeTrans.position.y - camaraTrans.position.y + distanciaInicial > altoMAX)
        {
            direccionAlto = 0;
            return true;
        }// se sale por abajo
        if (personajeTrans.position.y - camaraTrans.position.y + distanciaInicial < altoMIN)
        {
            direccionAlto = 1;
            return true;
        }
        return false;
    }
}