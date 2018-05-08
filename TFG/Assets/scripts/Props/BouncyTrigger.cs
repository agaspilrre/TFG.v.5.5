using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO DEL OBJETO MUELLE IMPULSADOR
/// </summary>
public class BouncyTrigger : MonoBehaviour {

    // Use this for initialization
    public bool north;
    public bool south;
    public bool est;
    public bool west;
    public float forceBouncy;
    public float speedImpulse;
    public float decrementImpulse;
    bool check;//para que haga la comprobacion justo despues de saltar en el trampolin
    public bool disapearCharacter;
    GameObject player;
    Poderes poderes;

    Rigidbody2D characterRB;
    BoxCollider2D characterCollider;
    Player playerScript;

    bool isJumping;
    float timerJump;

    [SerializeField]
    [Header("Trigger Vibration Settings")]
    [Space(10)]
    float quantityVibrationTrigger;
    [SerializeField]
    float timeVibrationTrigger;

    Collider2D colliderBouncy;

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
        
        //Debug.Log( characterRB.velocity);
        if (check)
        {
            if (characterRB.velocity.y < 0)
            {
                print("sdsdsdsdsdsd");
            }
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
            //timerJump++;
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
        
        anim.SetBool("Awake", true);
        colliderBouncy.isTrigger = true;
        Invoke("startIdle", 1);
    }

    void startIdle()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Awake", false);
    }

    void ChangeGravity()
    {       
        playerScript.setGravity0();
        poderes.CancelInvokes();
        playerScript.setPermitido(false);
    }

    void activateScriptMovement()
    {
        check = false;
        playerScript.returnGravity();
        playerScript.setPermitido(true);
    }
}

