using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

    //variable para activar las animaciones
    private Animator anim;

    void Start () {
		player = GetComponent<Player> ();
        anim = GetComponent<Animator>();
    }

	void FixedUpdate () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

        //para activar las animaciones en caso de que nos movamos
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //si nos movemos se activan las animaciones
            if (Input.GetAxisRaw("Horizontal")>0)
            {
                anim.SetBool("idle", false);
                anim.SetBool("runRigth", true);
                anim.SetBool("runLeft", false);
                
            }

            else
            {
                anim.SetBool("idle", false);
                anim.SetBool("runLeft", true);
                anim.SetBool("runRigth", false);
                

            }
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("runLeft", false);
            anim.SetBool("runRigth", false);
            anim.SetBool("idle", true);
        }

        player.SetDirectionalInput (directionalInput);




		if (Input.GetKeyDown (KeyCode.Space)) {

			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
		}
	}
}
