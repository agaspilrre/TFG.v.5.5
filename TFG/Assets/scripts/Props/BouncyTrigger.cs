using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyTrigger : MonoBehaviour {

    // Use this for initialization
    public bool north;
    public bool south;
    public bool est;
    public bool west;
    public float forceBouncy;
    public float speedImpulse;

    Rigidbody2D characterRB;
    Player playerScript;
    

	void Start () {

        characterRB = GameObject.Find("Personaje").GetComponent<Rigidbody2D>();
        playerScript = GameObject.Find("Personaje").GetComponent<Player>();
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (north)
            {                
                ChangeGravity();
                characterRB.velocity = new Vector2(0, (forceBouncy*speedImpulse));                
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
    }
}

