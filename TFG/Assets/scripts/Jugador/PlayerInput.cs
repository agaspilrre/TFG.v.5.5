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

    public AnimationClip jump;

    enum Direccion { izquierda, derecha }
    Direccion direccion;

    enum PlayerMoving { yes,no}
    PlayerMoving moving;

    float stopTime = 0;
    UnityEditor.AnimationClipSettings settings;

    void Start()
    {
        settings = UnityEditor.AnimationUtility.GetAnimationClipSettings(jump);
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        poderes = GetComponent<Poderes>();
        direccion = Direccion.derecha;
        moving = PlayerMoving.no;
        playerAnim = GetComponent<PlayerAnim>();
        basicAttack = GetComponent<BasicAttack>();
    }

    void Update()
    {

        //Control de la animacion de salto, que la primera vez se ejecute normal y en el segundo se para en el ultimo frame
        if (player.getNumSaltos() == 0)
        {           
            settings.loopTime = true;
            UnityEditor.AnimationUtility.SetAnimationClipSettings(jump, settings);
        }

        if(player.getNumSaltos() == 1)
        {
            settings.loopTime = false;
            UnityEditor.AnimationUtility.SetAnimationClipSettings(jump, settings);
        }

        Vector2 directionalInput = Vector2.zero;
        if (Input.GetAxis("Horizontal") > 0)
            directionalInput.x = 1;
        else if (Input.GetAxis("Horizontal") < 0)
            directionalInput.x = -1;

        if (Input.GetAxis("Vertical") > 0)
            directionalInput.y = 1;
        else if (Input.GetAxis("Vertical") < 0)
            directionalInput.y = -1;
        ///Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //MOVIMIENTO HORIZONTAL
        //para activar las animaciones en caso de que nos movamos
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            stopTime = 0;
            moving = PlayerMoving.yes;
            //si nos movemos se activan las animaciones 
            playerAnim.IdlToRun();
            
               

        }

        else if (Input.GetAxis("Horizontal") == 0 )
        {    
            
            //comprobar cuanto tiempo permanece parado para el sistema de emojis
            stopTime += Time.deltaTime;

            if (stopTime >= 0.1f)
            {
                moving = PlayerMoving.no;

                playerAnim.RunToIdl();
            }
           
            //playerAnim.RunToIdl();
            //playerAnim.IdlToRunFalse();
            

            
                
        }

        player.SetDirectionalInput(directionalInput);

        //SALTO  
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("PS4_X"))
        {
            player.OnJumpInputDown();
            if (moving == PlayerMoving.no)
            {
                //de idl a salto
                playerAnim.idlToJump();
            }
            else
            {
                //de correr a salto
                playerAnim.runToJump();
            }
            //playerAnim.idlToJump();
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("PS4_X"))
        {
            player.OnJumpInputUp();
            //playerAnim.idlToJump();
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
            if (moving == PlayerMoving.no)
            {
                //de idl a dash
                playerAnim.idlToDash();
            }
            else
            {
                //de correr a dash
                playerAnim.runToDash();
            }
            if (player.getIsJumping())
                playerAnim.jumpToDash();
            else
            {
                playerAnim.dashToRun();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            basicAttack.Charge();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            // Vector2 aux = Mathf.Abs(directionalInput.x) > Mathf.Abs(directionalInput.y) ? new Vector2(directionalInput.x, 0) : new Vector2(0, directionalInput.y);
            Vector2 aux = new Vector2(directionalInput.x,directionalInput.y);
            if (aux == Vector2.zero)
                basicAttack.StopCharging(new Vector2(player.getDireccion(), 0));
            else
                basicAttack.StopCharging(aux);
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


