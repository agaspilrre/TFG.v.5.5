using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO DEL OBJETO MUELLE IMPULSADOR
/// </summary>
public class BouncyTrigger : MonoBehaviour {

    /// <summary>
    /// Booleano para determinar la direccion en la que impulsa
    /// </summary>
    public bool north;
    public bool south;
    public bool est;
    public bool west;

    /// <summary>
    /// Fuerza del muelle
    /// </summary>
    public float forceBouncy;

    /// <summary>
    /// Velocidad de impulso que da al jugador
    /// </summary>
    public float speedImpulse;

    /// <summary>
    /// Velocidad a la que que queremos que se vuelva a recuperar el control del personaje
    /// tras chocar con el muelle
    /// </summary>
    public float decrementImpulse;

    /// <summary>
    /// Booleano para que haga la comprobacion justo despues de saltar en el trampolin
    /// </summary>
    bool check;

    /// <summary>
    /// Booleano para establecer la desparicion del jugador
    /// </summary>
    public bool disapearCharacter;

    /// <summary>
    /// Referencia al gameobject del jugador
    /// </summary>
    GameObject player;

    /// <summary>
    /// Referencia al script de poderes
    /// </summary>
    Poderes poderes;

    /// <summary>
    /// Referencia al rigidbody del jugador
    /// </summary>
    Rigidbody2D characterRB;

    /// <summary>
    /// Referencia al box collide del jugador
    /// </summary>
    BoxCollider2D characterCollider;

    /// <summary>
    /// Referencia al player script
    /// </summary>
    Player playerScript;

    /// <summary>
    /// Referencia al audiosource del muelle
    /// </summary>
    [SerializeField]
    AudioSource source;

    /// <summary>
    /// Lista de clips de sonido que va a emitir el muelle en sus distintos estados
    /// </summary>
    [SerializeField]
    List<AudioClip> clips;

    /// <summary>
    /// Booleano para establecer la vibracion del mando cuando el jugador esta en el aire
    /// </summary>
    bool isJumping;  

    /// <summary>
    /// Valores para la vibracion del mando
    /// </summary>
    [SerializeField]
    [Header("Trigger Vibration Settings")]
    [Space(10)]
    float quantityVibrationTrigger;
    [SerializeField]
    float timeVibrationTrigger;

    /// <summary>
    /// Collider del muelle
    /// </summary>
    Collider2D colliderBouncy;

    /// <summary>
    /// Referencia al animator del muelle
    /// </summary>
    Animator anim;

    void Start () {

        characterRB = GameObject.Find("Personaje").GetComponent<Rigidbody2D>();
        characterCollider = GameObject.Find("Personaje").GetComponent<BoxCollider2D>();
        playerScript = GameObject.Find("Personaje").GetComponent<Player>();
        poderes = GameObject.Find("Personaje").GetComponent<Poderes>();
        anim = GetComponent<Animator>();
        check = false;
        colliderBouncy = GetComponent<Collider2D>();
     
	}
	
	// Update is called once per frame
	void Update () {        
        
        if (check)
        {            
            //Cuando queremos devolver el control al personaje
            if (characterRB.velocity.y <= decrementImpulse)
            {
                activateScriptMovement();
                player.GetComponent<SpriteRenderer>().enabled = true;
                isJumping = false;
                GamePad.SetVibration(0, 0, 0);
                characterCollider.enabled = true;
            }
        }

        if (isJumping)
        {           
            GamePad.SetVibration(0, quantityVibrationTrigger, quantityVibrationTrigger);
        }

        //if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Impulsar") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //{
        //    anim.SetBool("Impulse", false);
        //    anim.SetBool("Idle", true);
        //}

        //if (timerJump >= timeVibrationTrigger)
        //{
        //    timerJump = 0;
        //    isJumping = false;
        //    GamePad.SetVibration(0, 0, 0);
        //}
    }

    /// <summary>
    /// Activa la animacion de impulso cuando algo invade su area
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayImpulseClip();
        anim.SetBool("Impulse", true);
        anim.SetBool("Idle", false);
    }

    /// <summary>
    /// Activa la animacion de Idle cuando algo sale de su area, generalmente el jugador
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Impulse", false);
        anim.SetBool("Idle", true);
    }

    /// <summary>
    /// Detecta si el jugador permanece dentro del trigger y le da una fuerza de impulso
    /// Desactiva el render del jugador
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (north)
            {
                anim.SetBool("Impulse", true);
                anim.SetBool("Idle", false);
                ChangeGravity();
                isJumping = true;
                if (disapearCharacter)
                {
                    player = collision.gameObject;
                    player.GetComponent<SpriteRenderer>().enabled = false;
                }
                characterRB.velocity = new Vector2(0, (forceBouncy*speedImpulse));
                check = true;
                //characterCollider.enabled = false;
                //anim.SetBool("Impulse", false);
            }

            /*else if (south)
            {
                characterRB.velocity = new Vector2(0, (forceBouncy * -speedImpulse));
            }

            else if (est)
            {
                characterRB.velocity = new Vector2((forceBouncy * speedImpulse),0 );
            }

            else if (west)
            {
                characterRB.velocity = new Vector2((forceBouncy * -speedImpulse), 0);
            }*/
        }       
    }


    //private void OnParticleTrigger()
    //{
    //    print("entra");
    //    anim.SetBool("Awake", true);
    //}

    /// <summary>
    /// Metodo que detecta si una particula del disparo de jugador ha entrado en contacto
    /// Activa la animacion de despertar y convierte la malla de collision en un trigger
    /// </summary>
    /// <param name="collision"></param>
    public void OnParticleCollision(GameObject collision)
    {
        PlayWakeUpClip();
        anim.SetBool("Awake", true);
        Invoke("startIdle", 1);
    }

    /// <summary>
    /// Metodo para poner a idle al muelle
    /// </summary>
    void startIdle()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Awake", false);
        Invoke("activarTrigger", 0.5f);
    }

    /// <summary>
    /// Metodo para quitar el control del personaje
    /// </summary>
    void ChangeGravity()
    {       
        playerScript.setGravity0();
        poderes.CancelInvokes();
        playerScript.setPermitido(false);
    }

    /// <summary>
    /// Metodo para devolver el control del personaje
    /// </summary>
    void activateScriptMovement()
    {
        check = false;
        playerScript.returnGravity();
        playerScript.setPermitido(true);
    }

    /// <summary>
    /// Activar sonido de despertarse del muelle
    /// </summary>
    void PlayWakeUpClip()
    {
        source.clip = clips[0];
        source.Play();
    }

    /// <summary>
    /// Activar sonido de impulso del muelle
    /// </summary>
    void PlayImpulseClip()
    {
        source.clip = clips[1];
        source.Play();
    }

    void activarTrigger()
    {
        colliderBouncy.isTrigger = true;

    }
}

