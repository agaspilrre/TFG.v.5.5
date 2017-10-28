using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInputPS4 : MonoBehaviour
{

    Player player;
    private PlayerAnim playerAnim;


    //variable para activar las animaciones
    private Animator anim;

    enum Direccion { izquierda, derecha }
    Direccion direccion;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        direccion = Direccion.derecha;
        playerAnim = GetComponent<PlayerAnim>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //para activar las animaciones en caso de que nos movamos
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            //si nos movemos se activan las animaciones

            //comprobamos que no esta ejecutando el dash
            if (player.GetComponent<Poderes>().getDashUse())
            {
                //si es falso corresponde animacion electro
                if (!player.GetComponent<Poderes>().getPlayerStates())
                {
                    playerAnim.IdlToRun();
                    playerAnim.RunToIdlFalse();
                }

                else
                {
                    playerAnim.IdlSToRunS();
                    playerAnim.RunSToIdlSFalse();
                }
            }







        }

        else if (Input.GetAxis("Horizontal") == 0)
        {
            if (!player.GetComponent<Poderes>().getPlayerStates())
            {
                playerAnim.RunToIdl();
                playerAnim.IdlToRunFalse();
            }

            else
            {
                playerAnim.RunSToIdlS();
                playerAnim.IdlSToRunSFalse();
            }
        }

        player.SetDirectionalInput(directionalInput);


        if (Input.GetButtonDown("PS4_X"))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetButtonUp("PS4_X"))
        {
            player.OnJumpInputUp();
        }





        //Voltear personaje.
        if (Input.GetAxisRaw("Horizontal") > 0 && direccion == Direccion.izquierda)
            flip();
        else if (Input.GetAxisRaw("Horizontal") < 0 && direccion == Direccion.derecha)
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

