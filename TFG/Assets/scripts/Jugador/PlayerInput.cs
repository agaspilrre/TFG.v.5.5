using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{

    Player player;
    private PlayerAnim playerAnim;
    Poderes poderes;

    BasicAttack basicAttack;

    //variable para activar las animaciones
    private Animator anim;

    enum Direccion { izquierda, derecha }
    Direccion direccion;

    float stopTime = 0;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        poderes = GetComponent<Poderes>();
        direccion = Direccion.derecha;
        playerAnim = GetComponent<PlayerAnim>();
        basicAttack = GetComponent<BasicAttack>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //MOVIMIENTO HORIZONTAL
        //para activar las animaciones en caso de que nos movamos
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            stopTime = 0;
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
            //comprobar cuanto tiempo permanece parado para el sistema de emojis
            stopTime += Time.deltaTime;

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

        //SALTO  
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("PS4_X"))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("PS4_X"))
        {
            player.OnJumpInputUp();
        }

        //CAMBIO PERSONALIDAD
        /*
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("PS4_Triangle")))
        {
            poderes.ControlChangePersonality();
        }*/

        //DUSH

        if (Input.GetButtonUp("Dash") || Input.GetButtonDown("PS4_L1"))
        {
            poderes.checkDush();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            basicAttack.Attack(new Vector3(1,0));
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

    public float getStopTime()
    {
        return stopTime;
    }



}


