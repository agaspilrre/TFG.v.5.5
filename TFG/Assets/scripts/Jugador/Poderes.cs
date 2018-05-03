using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// CLASE QUE GESTIONA EL COMPORTAMIENTO DE LOS PODERES DEL PLAYER
/// </summary>
public class Poderes : MonoBehaviour
{
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
    enum Shades { ELECTRIC, SHADOW }
    Shades playerState;

    /// <summary>
    /// Almacena los sprites dependiendo en que estado estemos
    /// </summary>
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
    bool isInAir;

    private PlayerAnim playerAnim;

    //variables para testeo con y sin dush infinito
    public bool infinityDush;
    bool verticalDush;

    HabilityBar staminaBar;
    BasicAttack basicAttack;
    PlayerInput input;

    // Use this for initialization
    void Start()
    {
        //calcular la velocidad del dash
        velocidadDash = distanciaDash / duracionDash;

        velocidadElectroDash = distanciaElectroDash / duracionElectroDash;
        //referencia al protagonista
        personajeMovimiento = GetComponent<Player>();
        input = GetComponent<PlayerInput>();
        //referencia al personaje
        personajeRB = GetComponent<Rigidbody2D>();
        //guarda la escala 
        initGravity = personajeRB.gravityScale;

        //variable que controla el numero de dush que se puede hacer, en principio se activa cuando el personaje toca el suelo
        dashUse = true;
        isInAir = false;

        staminaBar = GetComponent<HabilityBar>();

        cargaDash = 0;

        //al iniciar el juego inicia en estado normal
        state = Partition.NORMAL;

        //al iniciar el juego inicia en estado electrico
        playerState = Shades.ELECTRIC;

        playerCollider = GetComponent<Collider2D>();

        cambioPersonalidad = false;

        //para poder modificar el sprite del sprite renderer cuando cambiemos de estados
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ElectricShade;
        sr = GetComponent<SpriteRenderer>();

        playerAnim = GetComponent<PlayerAnim>();
        basicAttack = gameObject.GetComponent<BasicAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        //input para el dash
        /*
        if ((Input.GetButton("Dash") || Input.GetButtonDown("PS4_L1")) && dashUse && staminaBar.slider.value > 0)//calcula cuanto tiempo llevas apretando
        {
            personajeMovimiento.setPermitido(false);

            cargaDash += Time.deltaTime;

            if (cargaDash > 0.3)
            {
                materialCargaDash.color = Color.white;                   
            }
        }*/

        /*
         if ((Input.GetButtonUp("Dash") || Input.GetButtonDown("PS4_L1") )&& dashUse && staminaBar.slider.value > 0)
         {
             materialCargaDash.color = Color.black;
             staminaBar.LoseStamina();

             if (cargaDash < 0.3)//si es menor alo que este numero dash normal
             {
                 dash();
             }

             cargaDash = 0;
         }*/


    }

    
    /// <summary>
    /// llama a cambio de personalidad y comprueba el salto para la transformacion doble salto, en desuso por razones de diseño
    /// </summary>
    public void ControlChangePersonality()
    {
        personalityChange();
        //activa el segundo salto al cambiar de personalidad
        if (personajeMovimiento.getNumSaltos() == 1)
        {
            personajeMovimiento.setCanSecondJump(true);
        }
    }
    
    /// <summary>
    /// comprueba si puede realizar el dush y si es posible lo realiza 
    /// </summary>
    public void checkDush()
    {
        if (dashUse && !staminaBar.isBarEmpty())
        {
            materialCargaDash.color = Color.black;
            staminaBar.loseSquare();

            if (cargaDash < 0.3)//si es menor alo que este numero dash normal
            {
                dash();
            }

            cargaDash = 0;
        }        
    }

    /// <summary>
    /// Comprueba si esta en estado de particion. actualmente en desuso
    /// </summary>
    /// <returns></returns>
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

        personajeRB.velocity = new Vector2(personajeMovimiento.getDireccion() * velocidadDash, 0);

        dashUse = false;
        
        //despues del tiempo del dash volver a permitir movimiento
        Invoke("dashPermitido", duracionDash);

        basicAttack.CancelAttack();

        input.setVibrationDash(true);
    }

    public void CancelInvokes()
    {
        CancelInvoke();
    }

    void dashPermitido()
    {
        personajeMovimiento.returnGravity();
        personajeMovimiento.setPermitido(true);
        //volvemos activar la gravedad una vez finalizado el dush
        personajeRB.velocity = new Vector2(0, 0);
        personajeRB.gravityScale = initGravity;

        //quitar las animaciones del dush        
        if (Input.GetAxisRaw("Horizontal") != 0)
            playerAnim.jumpToRun();

        else
            playerAnim.JumpToIdl();


        //condicion para testear con dush infinito y sin dush infinito
        if (infinityDush)
        {
            Invoke("dushGround", duracionDash);
        }

        else
        {
            if (personajeMovimiento.getNumSaltos() == 0 && !verticalDush)
            {
                Invoke("dushGround", duracionDash);
            }
        }


        verticalDush = false;
    }

    /// <summary>
    /// Devuelve el valor del bool que indica si se puede usar el dash o no
    /// </summary>
    /// <returns></returns>
    public bool getDashUse()
    {
        return dashUse;
    }

    /// <summary>
    /// Asgina valor al bool que indica si se puede usar el dash o no
    /// </summary>
    /// <param name="use"></param>
    public void SetDashUse(bool use)
    {
        dashUse = use;
    }

    /// <summary>
    /// Setea la variable de dashUse a true
    /// </summary>
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

        else if (coll.gameObject.tag == "Enemy" && state == Partition.PARTITION)
        {
            startMarker = this.transform;
            //journeyLength = Vector3.Distance(startMarker.position, partitonObject.transform.position);
            returnPartitionPosition = true;
        }
    }

    /// <summary>
    /// Devuelve el estado de personalidad en el cual se encuentra el player. actualmente en desuso
    /// </summary>
    /// <returns></returns>
    public bool getPlayerStates()
    {
        return cambioPersonalidad;
    }

    
    /// <summary>
    /// Método para cambiar de personalidad. 
    /// Se hace funcion porque no solo se activa con el boton R si no que hay trigger que lo cambian automaticamente
    /// </summary>
    public void personalityChange()
    {

        if (!cambioPersonalidad)
        {
            playerState = Shades.SHADOW;
            cambioPersonalidad = true;
            //sr.sprite = ShadowShade;
            //cambiamos a animacion idle de sombra
            //playerAnim.IdlSToIdlFalse();
            //playerAnim.IdlToIdlS();

            print("sombra");
        }
        else
        {
            playerState = Shades.ELECTRIC;
            cambioPersonalidad = false;
            //sr.sprite = ElectricShade;
            //playerAnim.IdlToIdlSFalse();
            //playerAnim.IdlSToIdl();
            print("elec");
        }

    }


}
