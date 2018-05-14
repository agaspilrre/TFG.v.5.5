using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using System.Collections.Generic;
/// <summary>
/// CLASE ENCARGADA DE DETECTAR LOS INPUTS QUE EL JUGADOR ESTA PULSANDO 
/// </summary>


[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{

    Player player;
    private PlayerAnim playerAnim;
    Poderes poderes;


    BasicAttack basicAttack;

    lifeScript lifeScript;

    //variable para activar las animaciones
    private Animator anim;

    public AnimationClip jump;

    enum Direccion { izquierda, derecha }
    Direccion direccion;

    enum PlayerMoving { yes, no }
    PlayerMoving moving;

    float stopTime = 0;
    // UnityEditor.AnimationClipSettings settings;

    bool isJumpingVibr;

    public bool isJumping;
    float timerJump;
    float playerTransformX;

    [SerializeField]
    [Header("Jump Vibration Settings")]
    [Space(10)]
    float quantityVibrationJump;
    [SerializeField]
    float timeVibrationJump;
    [Space(10)]

    bool isDashing;
    float timerDash;

    [SerializeField]
    [Header("Dash Vibration Settings")]
    [Space(10)]
    float quantityVibrationDash;
    [SerializeField]
    float timeVibrationDash;
    [Space(10)]

    bool isAttack;
    float timerAttack;

    [SerializeField]
    [Header("Attack Vibration Settings")]
    [Space(10)]
    float quantityVibrationAttack;
    [SerializeField]
    float timeVibrationAttack;

    HabilityBar staminaBar;

    [SerializeField]
    float totalTimeSacrifice;

    [SerializeField]
    float startToSacrifice;

    float timer;
    bool pressed;

    public GameObject brazo1;
    public GameObject brazo2;

    CameraShake shake;

    [SerializeField]
    float shakeForce;

    [SerializeField]
    float vibrationForce;

    public List<AudioClip> clips = new List<AudioClip>();
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //settings = UnityEditor.AnimationUtility.GetAnimationClipSettings(jump);
        player = GetComponent<Player>();
        lifeScript = gameObject.GetComponent<lifeScript>();
        anim = GetComponent<Animator>();
        poderes = GetComponent<Poderes>();
        direccion = Direccion.derecha;
        moving = PlayerMoving.no;
        playerAnim = GetComponent<PlayerAnim>();
        basicAttack = GetComponent<BasicAttack>();
        staminaBar = GetComponent<HabilityBar>();
        shake = Camera.main.GetComponent<CameraShake>();        
        isJumping = false;
        timerJump = 0;
        pressed = false;
    }

    void Update()
    {
        //VIBRACION SALTO

        if (isJumpingVibr)
        {
            timerJump++;
            GamePad.SetVibration(0, quantityVibrationJump, quantityVibrationJump);
        }

        if (timerJump >= timeVibrationJump)
        {
            timerJump = 0;
            isJumpingVibr = false;
            GamePad.SetVibration(0, 0, 0);
        }

        //VIBRACION PARA EL DASH

        if (isDashing)
        {
            timerDash++;
            GamePad.SetVibration(0, quantityVibrationDash, quantityVibrationDash);
        }

        if (timerDash >= timeVibrationDash)
        {
            timerDash = 0;
            isDashing = false;
            GamePad.SetVibration(0, 0, 0);
        }

        //VIBRACION PARA EL ATAQUE

        if (isAttack)
        {
            timerAttack++;
            GamePad.SetVibration(0, quantityVibrationAttack, quantityVibrationAttack);
        }

        if (timerAttack >= timeVibrationAttack)
        {
            timerAttack = 0;
            isAttack = false;
            GamePad.SetVibration(0, 0, 0);
        }

        if (timer >= startToSacrifice)
        {
            pressed = true;
        }

        if (pressed)
        {
            shake.Shake(shakeForce);
            timer += Time.deltaTime;
            GamePad.SetVibration(0, vibrationForce, vibrationForce);

            if (timer >= totalTimeSacrifice)
            {
                pressed = false;
                BlurController.instance.ResetBlur();
                lifeScript.ResetBlur();               
                timer = 0;
                GamePad.SetVibration(0, 0, 0);
            }
        }

        /* //Control de la animacion de salto, que la primera vez se ejecute normal y en el segundo se para en el ultimo frame
         if (player.getNumSaltos() == 0)
         {           
             settings.loopTime = true;
             UnityEditor.AnimationUtility.SetAnimationClipSettings(jump, settings);
         }

         if(player.getNumSaltos() == 1)
         {
             settings.loopTime = false;
             UnityEditor.AnimationUtility.SetAnimationClipSettings(jump, settings);
         }*/

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
           

            if (player.getWallSliding())
            {
                 playerTransformX = this.transform.position.x;
            }
            stopTime = 0;
            moving = PlayerMoving.yes;
            //si nos movemos se activan las animaciones 
            

            //condicion q comprueba el transform en x para solventar el problema que existia con el walljump 
            //en las esquinas se alternavan las animaciones de correr y walljump con esta condicion lo solventams
            if(!player.getWallSliding()&& playerTransformX!=0 && Mathf.Abs(this.transform.position.x-playerTransformX)>0.1f)
                playerAnim.WallJump(false);

            playerAnim.IdlToRun();

            
            
        }

        else if (Input.GetAxis("Horizontal") == 0)
        {

            //comprobar cuanto tiempo permanece parado para el sistema de emojis
            stopTime += Time.deltaTime;

            if (stopTime >= 0.1f)
            {
                moving = PlayerMoving.no;
                //if (!player.getWallSliding())
                //    playerAnim.WallJump(false);
                playerAnim.RunToIdl();
                
            }

            //playerAnim.RunToIdl();
            //playerAnim.IdlToRunFalse();

        }

        player.SetDirectionalInput(directionalInput);

        //SALTO  
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("AButton"))
        {
            if (!basicAttack.isCharging)
            {
                isJumping = true;

                player.OnJumpInputDown();
                

                if (player.GetDirectionalInput().y == -1 && player.GetIsInDescendPlatform() && player.GetDirectionalInput().x == 0)
                {
                    playerAnim.Fall(true);
                }
                else                
                {
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
                }
                
               
                //playerAnim.idlToJump();
            }

            if (player.getNumSaltos() == 2 && anim.GetCurrentAnimatorStateInfo(0).IsName("jump"))
            {
                playerAnim.DoubleJump();
            }

        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("AButton"))
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

        if (Input.GetButtonUp("Dash") || Input.GetButtonDown("LBButton") && !player.getWallSliding())
        {
            poderes.checkDush();
            if (!staminaBar.isBarEmpty())
            {
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
                if (isJumping)
                    playerAnim.jumpToDash();
            }
            else
            {
                playerAnim.jumpToRun();                
            }

            //else
            //{
            //    playerAnim.dashToRun();
            //}
        }

        if ((Input.GetButton("BButton") || Input.GetKey(KeyCode.Y)) && pressed == false)
        {
            timer += Time.deltaTime;            
        }

        if ((Input.GetButtonUp("BButton") || Input.GetKeyUp(KeyCode.Y)) && pressed == false)
            timer = 0;

        if (Input.GetKeyDown(KeyCode.L) || Input.GetButtonDown("XButton"))
        {
            basicAttack.Charge();
        }

        Vector2 basicAttackDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (Input.GetAxis("Vertical") < 0)
        {
            basicAttack.direction = new Vector2(basicAttack.direction.x, 0);
        }
        else if(basicAttackDirection == Vector2.zero)
        {
            basicAttack.direction = new Vector2(player.getDireccion(), 0);
        }
        else
        {
            basicAttack.direction = basicAttackDirection.normalized;
        }
        if (Input.GetKeyUp(KeyCode.L) || Input.GetButtonUp("XButton"))
        {
            basicAttack.StopCharging();
        }

        //Voltear personaje.
        if (Input.GetAxis("Horizontal") > 0 && direccion == Direccion.izquierda)
            flip();
        else if (Input.GetAxis("Horizontal") < 0 && direccion == Direccion.derecha)
            flip();
    }

    public void AttackAnimations(bool boolean)
    {
        if(boolean)
        {
            brazo1.SetActive(true);
            brazo2.SetActive(true);
            playerAnim.Attack(true);
            playerAnim.RightArm(false);
            playerAnim.LeftArm(false);
        }
        else
        {
            playerAnim.Attack(false);
            playerAnim.RightArm(true);
            playerAnim.LeftArm(true);
            Invoke("ResetArms", 0.5f);
        }
    }

    void ResetArms()
    {
        brazo1.SetActive(false);
        brazo2.SetActive(false);
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

    public bool getIsJumping()
    {
        return isJumping;
    }

    public void setIsJumping(bool value)
    {
        isJumping = value;
    }

    public void setVibrationJump(bool value)
    {
        isJumpingVibr = value;
    }

    public void setVibrationDash(bool value)
    {
        isDashing = value;
    }

}
