using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

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

    Animator anim;

    void Start () {

        characterRB = GameObject.Find("Personaje").GetComponent<Rigidbody2D>();
        characterCollider = GameObject.Find("Personaje").GetComponent<BoxCollider2D>();
        playerScript = GameObject.Find("Personaje").GetComponent<Player>();
        poderes = GameObject.Find("Personaje").GetComponent<Poderes>();
        anim = GetComponent<Animator>();
        check = false;
     
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

        //if (timerJump >= timeVibrationTrigger)
        //{
        //    timerJump = 0;
        //    isJumping = false;
        //    GamePad.SetVibration(0, 0, 0);
        //}
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (north)
            {                
                ChangeGravity();
                isJumping = true;
                if (disapearCharacter)
                {
                    player = collision.gameObject;
                    player.GetComponent<SpriteRenderer>().enabled = false;
                }
                characterRB.velocity = new Vector2(0, (forceBouncy*speedImpulse));
                check = true;
                characterCollider.enabled = false;
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


    private void OnParticleTrigger()
    {
        print("entra");
        anim.SetBool("Awake", true);
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

