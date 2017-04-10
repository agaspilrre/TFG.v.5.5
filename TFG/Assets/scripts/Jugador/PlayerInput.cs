using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
   

    //variable para activar las animaciones
    private Animator anim;

    enum Direccion { izquierda, derecha }
    Direccion direccion;

    void Start () {
		player = GetComponent<Player> ();
        anim = GetComponent<Animator>();
        
        direccion = Direccion.derecha;
    }

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

        //para activar las animaciones en caso de que nos movamos
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //si nos movemos se activan las animaciones
            if (Input.GetAxisRaw("Horizontal")>0)
            {
                //si es falso corresponde animacion electro
                if (!player.GetComponent<Poderes>().getPlayerStates())
                {
                    anim.SetBool("idle", false);
                    anim.SetBool("runRigth", true);
                }

                else
                {
                    anim.SetBool("idle", false);
                    anim.SetBool("runShadow", true);
                }
               
                
               
            }

            else
            {

                //si es falso corresponde animacion electro
                if (!player.GetComponent<Poderes>().getPlayerStates())
                {
                    anim.SetBool("idle", false);
                    anim.SetBool("runRigth", true);
                }

                else
                {
                    anim.SetBool("idle", false);
                    anim.SetBool("runShadow", true);
                }

            }
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("runShadow", false);
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


        //Voltear personaje.
        if (Input.GetAxis("Horizontal") > 0 && direccion == Direccion.izquierda)
            flip();
        else if (Input.GetAxis("Horizontal") < 0 && direccion == Direccion.derecha)
            flip();
    }


    //funcion que voltea el personaje y animaciones
    void flip()
    {

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (direccion == Direccion.derecha)
            direccion = Direccion.izquierda;
        else
            direccion = Direccion.derecha;
    }

    

}

