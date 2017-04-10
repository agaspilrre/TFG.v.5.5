using UnityEngine;
using System.Collections;

public class Poderes : MonoBehaviour {

    public float duracionDash = 1f;

    public Material materialCargaDash;

    public float distanciaDash = 1f;

    public float distanciaElectroDash = 1f;

    public float duracionElectroDash = 1f;

    public float velocidadDash;

    public float velocidadElectroDash;

    Vector3 Seguimiento;

    float initGravity;

    public float cargaDash;

     public bool dashUse;

    public Transform personajeTrans;

    Player personajeMovimiento;
    //rigidbody del personaje
    Rigidbody2D personajeRB;

    //variables para el poder de la particion de sombras
    enum Partition { NORMAL, PARTITION }
    Partition state;

    //variables para controlar la personalidad del personaje
    enum Shades {ELECTRIC, SHADOW }
    Shades playerState;

    //para cargar los sprites dependiendo en que estado estemos
    public Sprite ElectricShade;
    public Sprite ShadowShade;

    SpriteRenderer sr;

    public GameObject partitionPrefab;
    GameObject partitonObject;
    Vector2 positionPartition;
    bool returnPartitionPosition;
    //private float journeyLength;
    [SerializeField]
    private float speedLerp = 10;
    private Transform startMarker;
    private Collider2D playerCollider;

    private bool cambioPersonalidad; 

    // Use this for initialization
    void Start () {
        //calcular la velocidad del dash
        velocidadDash = distanciaDash / duracionDash;

        velocidadElectroDash = distanciaElectroDash / duracionElectroDash;
        //referencia al protagonista
        personajeMovimiento = GetComponent<Player>();
        //referencia al personaje
        personajeRB = GetComponent<Rigidbody2D>();
        //guarda la escala 
        initGravity = personajeRB.gravityScale;

        //variable que controla el numero de dush que se puede hacer, en principio se activa cuando el personaje toca el suelo
        dashUse = true;

        cargaDash = 0;

        //al iniciar el juego inicia en estado normal
        state = Partition.NORMAL;

        //al iniciar el juego inicia en estado electrico
        playerState = Shades.ELECTRIC;

        playerCollider = GetComponent<Collider2D>();

        cambioPersonalidad = false;

        //para poder modificar el sprite del sprite renderer cuando cambiemos de estados
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ElectricShade;
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!cambioPersonalidad)
            {
                playerState = Shades.SHADOW;                
                cambioPersonalidad = true;
                sr.sprite = ShadowShade;
                

                print("sombra");
            }
            else
            {
                playerState = Shades.ELECTRIC;               
                cambioPersonalidad = false;
                sr.sprite = ElectricShade;

                print("elec");
            }
        }

        //PODERES QUE TIENE LA PROTA SIENDO ELECTRICA
        if(playerState == Shades.ELECTRIC)
        {

        }

        if (!returnPartitionPosition)
        {
            //input para el dash
            if (Input.GetButton("Dash") && dashUse)//calcula cuanto tiempo llevas apretando
            {
                personajeMovimiento.setPermitido(false);

                cargaDash += Time.deltaTime;

                if (cargaDash > 0.3)
                {
                    materialCargaDash.color = Color.white;
                }
            }
            if (Input.GetButtonUp("Dash") && dashUse)
            {

                materialCargaDash.color = Color.black;

                if (cargaDash < 0.3)//si es menor alo que este numero dash normal
                {
                    dash();
                }
                else
                {
                    //solo puedo hacer el dash electrico si estoy en estado electrico
                    if (playerState == Shades.ELECTRIC)
                    {
                        electroDash();
                    }

                    else
                    {
                        dash();
                    }
                }

                cargaDash = 0;
            }

            //PODERES QUE TIENE LA PROTA SIENDO SOMBRA
            if (playerState == Shades.SHADOW)
            {

            }

            //poder de particion de sombras
            if (Input.GetKeyDown(KeyCode.F) && playerState==Shades.SHADOW)
            {

                if( state == Partition.NORMAL && personajeMovimiento.getIsJumping() == false)
                {
                    //cambio de estado
                    state = Partition.PARTITION;
                    //guardamos la posicion de la instancia dependiendo de la direccion q este mirando el personaje
                    if (personajeMovimiento.getDireccion() == 1)
                        positionPartition = new Vector2(this.transform.position.x - 2.5f, this.transform.position.y);

                    else
                        positionPartition = new Vector2(this.transform.position.x + 2.5f, this.transform.position.y);
                    //instanciamos cascaron vacio
                    partitonObject = Instantiate(partitionPrefab, positionPartition, Quaternion.identity);

                    if(personajeMovimiento.getDireccion() == 1)
                        partitonObject.transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);

                }

                else if (state == Partition.PARTITION)
                {
                    startMarker = this.transform;
                    //journeyLength = Vector3.Distance(startMarker.position, partitonObject.transform.position);
                    returnPartitionPosition = true;
                }
            }
        }

        //estamos retornando a la posicion del cascaron
        else
        {
            //bloqueamos mov personaje
            personajeMovimiento.setPermitido(false);
            //desactivar el collider para que pueda trasladarse
            playerCollider.enabled = false;
            //hacemos lerp
           
            float distCovered = Time.deltaTime * speedLerp;
            float fracJourney = distCovered;

            transform.position = Vector3.Lerp(startMarker.position, partitonObject.transform.position, fracJourney);
            //comprobamos si ha llegado al destino si es asi ponemos bool a false de nuevo y permitimos el movimiento
            //contemplar si la sombra esta a la izquierda o derecha de la posicion del cascaron
            if(this.transform.position.x> partitonObject.transform.position.x)
            {
                if (this.transform.position.x - partitonObject.transform.position.x < 1 && this.transform.position.y - partitonObject.transform.position.y < 0.5f)
                {
                    returnPartitionPosition = false;
                    personajeMovimiento.setPermitido(true);
                    state = Partition.NORMAL;
                    playerCollider.enabled = true;
                }
            }

            else
            {
                if (this.transform.position.x - partitonObject.transform.position.x >-1 && this.transform.position.y - partitonObject.transform.position.y >-0.5f)
                {
                    returnPartitionPosition = false;
                    personajeMovimiento.setPermitido(true);
                    state = Partition.NORMAL;
                    playerCollider.enabled = true;
                }
            }
           
        }
       

        
    }
    public bool getStatePartition()
    {
        if (state == Partition.PARTITION)
            return true;
        else
            return false;
    }

    void dash()
    {
        personajeMovimiento.setGravity0();
        personajeRB.velocity = new Vector2(personajeMovimiento.getDireccion() * velocidadDash , 0);

        dashUse = false;
        //despues del tiempo del dash volver a permitir movimiento
        Invoke("dashPermitido",duracionDash);
    }   

    void electroDash()
    {
        
            personajeMovimiento.setGravity0();
            personajeRB.velocity = new Vector2(personajeMovimiento.getDireccion() * velocidadElectroDash, 0);

            dashUse = false;
            //despues del tiempo del dash volver a permitir movimiento
            Invoke("dashPermitido", duracionElectroDash);
        
    }
        

    void dashPermitido()
    {
        personajeMovimiento.returnGravity();
        personajeMovimiento.setPermitido(true);
        //volvemos activar la gravedad una vez finalizado el dush
        personajeRB.gravityScale = initGravity;

        if (!personajeMovimiento.getIsJumping())
        {
            Invoke("dushGround",duracionDash);
        }
    }


    public void SetDashUse(bool use)
    {
        dashUse = use;
    }

    void dushGround()
    {
        dashUse = true;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        //si chocamos con el cuerpo cascaron vacio se destruye el objeto cascaron instanciado
        if (coll.gameObject.tag == "Partition")
        {
            GameObject.Destroy(partitonObject);
            state = Partition.NORMAL;
            //poner permitido a true;
        }

        else if(coll.gameObject.tag=="Enemy" && state == Partition.PARTITION)
        {
            startMarker = this.transform;
            //journeyLength = Vector3.Distance(startMarker.position, partitonObject.transform.position);
            returnPartitionPosition = true;
        }
    }

    public bool getPlayerStates()
    {
        return cambioPersonalidad;
    }
   

}
