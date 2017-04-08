using UnityEngine;
using System.Collections;

public class camaraMOV : MonoBehaviour
{

    bool movPermitido;

    bool movAlturaPermitido;

    float desplzamientoGuardado;

    [SerializeField]
    private float timerBalanceo;

    float tiempoBalanceo;

    float shake_decay;
    float shake_intensity;

    //cuanto se balancea
    public float balanceoX = 1;
    public float balanceoY = 10f;

    //a que velocidad se balancea
    public float veclocidadBalanceoX = 0.8F;
    public float veclocidadBalanceoY = 0.8F;

    //guarda posicion para balanceo
    public Vector3 vectorGuardaBalanceo = new Vector3();

    public Transform camaraTrans;
    public Transform personajeTrans;

    public float velocidadReajuste;

    public float anchoMAX = 3f;
    public float anchoMIN = -3f;

    public float altoMAX = 3f;
    public float altoMIN = -3f;

    Player player;
    Poderes poder;

    Vector2 movExtraTrigger;//mov extra eb caso de entrar en trigger


    public float veclocidadSeguimiento = 0.7F;

    //distancia inicial entre camara y personaje
    float distanciaInicial;
    //distancia entre personaje y centro de camara
    public float desplazamientoX;

    //direccion en la x, 0 es derecha 1 es izquierda

    int direccionAncho;

    //direccion del giro, 0 es arriba 1 es abajo

    int direccionAlto;

    public void setMoveExtra(Vector2 a)
    {
        movExtraTrigger = a;
    }
    // Use this for initialization
    void Start()
    {
        movPermitido = false;

        movAlturaPermitido = false;

        distanciaInicial = camaraTrans.position.y - personajeTrans.position.y;

        vectorGuardaBalanceo = Vector3.zero;

        player = GameObject.Find("Personaje").GetComponent<Player>();
        poder = GameObject.Find("Personaje").GetComponent<Poderes>();

        desplzamientoGuardado = desplazamientoX;
    }

    // Update is called once per frame
    void Update()
    {
     
        //if (player.getIsMoving() || poder.getStatePartition())
        {

            tiempoBalanceo = 0;
            //comparar posicion del personaje con el de la camara
            movPermitido = compararPosicion();

            movAlturaPermitido = compararAltura();

            //si el personaje se sale del rango de movimiento libre


            if (movPermitido & direccionAncho == 0)//diro derecha
            {
                //nueva posicion de la camara
                Vector3 newPos = new Vector3(personajeTrans.position.x - anchoMAX - desplazamientoX + movExtraTrigger.x, camaraTrans.position.y, -10f);
                if (player.getDireccion() == 1 && desplazamientoX > desplzamientoGuardado && player.getIsMoving())
                {
                    desplazamientoX = desplazamientoX - (velocidadReajuste * Time.deltaTime);
                }
                camaraTrans.position = newPos;

            }
            if (movPermitido & direccionAncho == 1)//giro izquierda
            {
                //nueva posicion de la camara
                Vector3 newPos = new Vector3(personajeTrans.position.x - anchoMIN - desplazamientoX + movExtraTrigger.x, camaraTrans.position.y, -10f);
                if (player.getDireccion() == -1 && desplazamientoX < -desplzamientoGuardado && player.getIsMoving())
                {
                    desplazamientoX = desplazamientoX + (velocidadReajuste * Time.deltaTime);
                }
                camaraTrans.position = newPos;

            }
            if (movAlturaPermitido & direccionAlto == 0)//giro arriba
            {
                //nueva posicion de la camara
                Vector3 newPos = new Vector3(camaraTrans.position.x, personajeTrans.position.y - altoMAX + distanciaInicial + movExtraTrigger.y, -10f);
                camaraTrans.position = newPos;

            }
            if (movAlturaPermitido & direccionAlto == 1)//giro abajo
            {
                //nueva posicion de la camara
                Vector3 newPos = new Vector3(camaraTrans.position.x, personajeTrans.position.y - altoMIN + distanciaInicial + movExtraTrigger.y, -10f);
                camaraTrans.position = newPos;

            }

            //evitar que al volver a pasar se vuelva a meter en algun if sin querer
            direccionAlto = 3;
            direccionAncho = 3;

            
            vectorGuardaBalanceo = Vector3.zero;
            
        }/*else
        {
            tiempoBalanceo += Time.deltaTime;
        }*/

        //movimiento leve
        Vector3 Seguimiento = new Vector3(personajeTrans.position.x - desplazamientoX + movExtraTrigger.x + balanceoX, personajeTrans.position.y + distanciaInicial + movExtraTrigger.y + balanceoY, camaraTrans.position.z);

        //Camara sigue despacio
        camaraTrans.position = Vector3.Lerp(camaraTrans.position, Seguimiento, veclocidadSeguimiento * Time.deltaTime);

        /*if (tiempoBalanceo >= timerBalanceo)
        {
            if (vectorGuardaBalanceo == Vector3.zero)
            {
                vectorGuardaBalanceo = new Vector3(camaraTrans.position.x, camaraTrans.position.y, -10f);
            }

            if((vectorGuardaBalanceo.x + balanceoX <= camaraTrans.position.x && veclocidadBalanceoX > 0 ) || (vectorGuardaBalanceo.x + balanceoX >= camaraTrans.position.x && 0 > veclocidadBalanceoX))
            {
                veclocidadBalanceoX = -veclocidadBalanceoX;
                balanceoX = -balanceoX;
            }

            if((vectorGuardaBalanceo.y + balanceoY <= camaraTrans.position.y && veclocidadBalanceoY > 0) || (vectorGuardaBalanceo.y + balanceoY >= camaraTrans.position.y && 0 > veclocidadBalanceoY))
            {
                veclocidadBalanceoY = -veclocidadBalanceoY;
                balanceoY = -balanceoY;

            }

            Vector3 a = new Vector3(camaraTrans.position.x +(veclocidadBalanceoX * Time.deltaTime) , camaraTrans.position.y + (veclocidadBalanceoY * Time.deltaTime), -10);

            camaraTrans.position = a;
        }
        */

        if (shake_intensity > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shake_intensity;
            shake_intensity -= shake_decay;

        }
        if (Input.GetKey(KeyCode.V))
        {

            Shake();
        }

    }

    //mirar si se sale del rango
    bool compararPosicion()
    {
        //se sale por la derecha
        if (personajeTrans.position.x - camaraTrans.position.x - desplazamientoX + movExtraTrigger.x > anchoMAX)
        {
            direccionAncho = 0;
            return true;
        }
        // se sale por la izquierda
        if (personajeTrans.position.x - camaraTrans.position.x - desplazamientoX + movExtraTrigger.x < anchoMIN)
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
        if (personajeTrans.position.y - camaraTrans.position.y + distanciaInicial + movExtraTrigger.y > altoMAX)
        {
            direccionAlto = 0;
            return true;
        }// se sale por abajo
        if (personajeTrans.position.y - camaraTrans.position.y + distanciaInicial - movExtraTrigger.y < altoMIN)
        {
            direccionAlto = 1;
            return true;
        }
        return false;
    }

    void Shake()
    {
        shake_intensity = .3f;
        shake_decay = 0.002f;
    }
}