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

    Rigidbody2D characterRB;
    Player playerScript;
    Poderes powerPlayer;

    bool isJumping;
    float increment;

    [SerializeField]
    [Header("Trigger Vibration Settings")]
    [Space(10)]
    float quantityVibrationTrigger;
    [SerializeField]
    float timeVibrationTrigger;

    void Start () {

        characterRB = GameObject.Find("Personaje").GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Personaje").GetComponent<Player>();
        powerPlayer = GameObject.Find("Personaje").GetComponent<Poderes>();
        check = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log( characterRB.velocity);
        if (check)
        {
            if (characterRB.velocity.y <= decrementImpulse)
            {
                activateScriptMovement();
                player.GetComponent<SpriteRenderer>().enabled = true;
                isJumping = false;
                GamePad.SetVibration(0, 0, 0);
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
                //characterRB.velocity = Vector2.zero;


                //if (powerPlayer.getDashUse())
                //characterRB.velocity = new Vector2(0, (forceBouncy * speedImpulse));
                //else
                //{
                //    characterRB.velocity = Vector2.zero;
                //    playerScript.setVelocityY(0);
                //    characterRB.velocity = new Vector2(0, (forceBouncy * speedImpulse));
                //}


                if (powerPlayer.getDashUse())
                    increment = 1f;
                else
                    increment = 3;

                Vector2 upVector = new Vector2(0, (forceBouncy * speedImpulse * increment));
                characterRB.velocity = Vector2.zero;
                characterRB.AddForce(upVector, ForceMode2D.Impulse);


                check = true;
            }

            else if (south)
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
            }
        }
    }

    void ChangeGravity()
    {
        playerScript.enabled = false;
        powerPlayer.enabled = false;
    }

    void activateScriptMovement()
    {
        check = false;
        playerScript.enabled = true;   
        powerPlayer.enabled = true;
        playerScript.setVelocityY(0);
        characterRB.velocity = Vector2.zero;
        playerScript.setPermitido(true);
    }
}

