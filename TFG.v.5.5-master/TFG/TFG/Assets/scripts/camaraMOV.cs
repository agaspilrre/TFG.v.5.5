using UnityEngine;
using System.Collections;

public class camaraMOV : MonoBehaviour
{

    bool movPermitido;

    //si esta quieto el personaje se balancea
    bool personajeQuieto;

    float timer = 0;

    bool movAlturaPermitido;


    Vector3 originPosition;
    Quaternion originRotation;
    float shake_decay;
    float shake_intensity;


    //cuanto se balancea
    public float balanceoX = 1;
    public float balanceoY = 0.3f;

    //controla que solo se guarde una vez si es true se puede guardar si no no.
    bool guardar = true;

    //a que velocidad se balancea
    public float veclocidadBalanceo = 0.5F;

    //vector guarda posicion camra para respirar
    Vector3 vectorGuarda = new Vector3();

    public Transform camaraTrans;
    public Transform personajeTrans;

    public float anchoMAX = 3f;
    public float anchoMIN = -3f;

    public float altoMAX = 3f;
    public float altoMIN = -3f;

    public float veclocidadSeguimiento = 0.7F;

    public bool cambioDireccionBalanceo = false;

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

        personajeQuieto = true;


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

        //calcular nueva posicion para el balanceo

        Vector3 Seguimiento = new Vector3(personajeTrans.position.x, personajeTrans.position.y + distanciaInicial, camaraTrans.position.z);

        //Camara sigue despacio
        camaraTrans.position = Vector3.Lerp(camaraTrans.position, Seguimiento, veclocidadSeguimiento * Time.deltaTime);


        if (shake_intensity > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shake_intensity;        
            shake_intensity -= shake_decay;
            
        }
       

        if(Input.GetKey(KeyCode.V))
        {
            vectorGuarda = new Vector3(transform.position.x , transform.position.y, -10f);
            Shake();
        }

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

    void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = .3f;
        shake_decay = 0.002f;
    }

}