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
    /// <summary>
    /// Referencia al script del player
    /// </summary>
    Player player;

    /// <summary>
    /// Referencia al script del playerAnim
    /// </summary>
    PlayerAnim playerAnim;

    /// <summary>
    /// Referencia al script de poderes
    /// </summary>
    Poderes poderes;

    /// <summary>
    /// Referencia al script de basicAttack
    /// </summary>
    BasicAttack basicAttack;

    /// <summary>
    /// Referencia al script de lifescript
    /// </summary>
    lifeScript lifeScript;
    
    /// <summary>
    /// Referencia a la animacion de salto
    /// </summary>
    public AnimationClip jump;

    /// <summary>
    /// Enumeracion utilizada para la direccion del personaje
    /// </summary>
    enum Direccion { izquierda, derecha }
    Direccion direccion;

    /// <summary>
    /// Enumeracion utilizada para determinar si el personaje se esta moviendo o no
    /// </summary>
    enum PlayerMoving { yes, no }
    PlayerMoving moving;

    /// <summary>
    /// Timer para determinar si el player esta parado
    /// </summary>
    float stopTime = 0;
    
    /// <summary>
    /// Booleano para determinar la vibracion del mando al saltar
    /// </summary>
    bool isJumpingVibr;

    /// <summary>
    /// Booleano para determinar si el player esta saltando
    /// </summary>
    public bool isJumping;

    /// <summary>
    /// Timer auxiliar para ajustar la vibracion del mando al saltar
    /// </summary>
    float timerJump;

    /// <summary>
    /// Variable auxiliar para la asignacion del transform del personaje en el eje x
    /// </summary>
    float playerTransformX;

    /// <summary>
    /// Valores de la vibracion para el salto
    /// </summary>
    [SerializeField]
    [Header("Jump Vibration Settings")]
    [Space(10)]
    float quantityVibrationJump;
    [SerializeField]
    float timeVibrationJump;
    [Space(10)]

    /// <summary>
    /// Booleano para determinar la vibracion del mando al hacer dash 
    /// </summary>
    bool isDashing;

    /// <summary>
    /// Timer auxiliar para ajustar la vibracion del mando al hacer dash
    /// </summary>
    float timerDash;

    /// <summary>
    /// Valores de la vibracion para el dash
    /// </summary>
    [SerializeField]
    [Header("Dash Vibration Settings")]
    [Space(10)]
    float quantityVibrationDash;
    [SerializeField]
    float timeVibrationDash;
    [Space(10)]

    /// <summary>
    /// Booleano para determinar la vibracion del mando al atacar
    /// </summary
    bool isAttack;

    /// <summary>
    /// Timer auxiliar para ajustar la vibracion del mando al atacar
    /// </summary>
    float timerAttack;

    /// <summary>
    /// Valores de la vibracion al atacar
    /// </summary>
    [SerializeField]
    [Header("Attack Vibration Settings")]
    [Space(10)]
    float quantityVibrationAttack;
    [SerializeField]
    float timeVibrationAttack;

    /// <summary>
    /// Referencia al script de la staminaBar
    /// </summary>
    HabilityBar staminaBar;

    /// <summary>
    /// Tiempo total del sacrificio de un corazon
    /// </summary>
    [SerializeField]
    float totalTimeSacrifice;

    /// <summary>
    /// Tiempo en el que comienza el sacrificio
    /// </summary>
    [SerializeField]
    float startToSacrifice;

    /// <summary>
    /// Timer auxiliar para determinar el sacrificio de corazones 
    /// </summary>
    float timer;

    /// <summary>
    /// Booleano para determinar si el boton de sacrificio esta pulsado
    /// </summary>
    bool pressed;

    /// <summary>
    /// Referencia a los gameobject de los brazos utilizados para la animacion de ataque
    /// </summary>
    public GameObject brazo1;
    public GameObject brazo2;

    /// <summary>
    /// Referencia al script de camera shake
    /// </summary>
    CameraShake shake;

    /// <summary>
    /// Valores de fuerza del shake y vibracion del mando cuando se produce
    /// </summary>
    [SerializeField]
    float shakeForce;
    [SerializeField]
    float vibrationForce;

    /// <summary>
    /// Lista de audio clips del personaje
    /// </summary>
    [SerializeField]
    List<AudioClip> clips;

    /// <summary>
    /// Audio source general del personaje
    /// </summary>
    [SerializeField]
    AudioSource source;

    /// <summary>
    /// Audio source del personaje para el disparo del personaje
    /// </summary>
    [SerializeField]
    AudioSource sourceShoot;

    /// <summary>
    /// Audio source del personaje para caminar
    /// </summary>
    [SerializeField]
    public AudioSource sourceWalk;

    void Start()
    {       
        player = GetComponent<Player>();
        lifeScript = gameObject.GetComponent<lifeScript>();       
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
                lifeScript.makeDamage(1);
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

        //Control de la direccion del input
        Vector2 directionalInput = Vector2.zero;
        if (Input.GetAxis("Horizontal") > 0)
            directionalInput.x = 1;
        else if (Input.GetAxis("Horizontal") < 0)
            directionalInput.x = -1;

        if (Input.GetAxis("Vertical") > 0)
            directionalInput.y = 1;
        else if (Input.GetAxis("Vertical") < 0)
            directionalInput.y = -1;
        

        //MOVIMIENTO HORIZONTAL
        //para activar las animaciones en caso de que nos movamos
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (player.getWallSliding())
            {
                playerTransformX = this.transform.position.x;
            }
            //stopTime = 0;
            moving = PlayerMoving.yes;
            //si nos movemos se activan las animaciones 


            //condicion q comprueba el transform en x para solventar el problema que existia con el walljump 
            //en las esquinas se alternavan las animaciones de correr y walljump con esta condicion lo solventams
            if (!player.getWallSliding() && playerTransformX != 0 && Mathf.Abs(this.transform.position.x - playerTransformX) > 0.2f)
                playerAnim.WallJump(false);

            playerAnim.IdlToRun();        

        }

        else if (Input.GetAxis("Horizontal") == 0)
        {           
            sourceWalk.loop = false;

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
            if (player.getNumSaltos() <= 1)
            {
                PlayClipJump();
            }

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

            if (player.getNumSaltos() == 2 && playerAnim.GetAnimator().GetCurrentAnimatorStateInfo(0).IsName("jump"))
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

        //DASH

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
                //playerAnim.jumpToRun();                
            }

            //else
            //{
            //    playerAnim.dashToRun();
            //}
        }

        //SACRIFICIO DE CORAZON
        if ((Input.GetButton("BButton") || Input.GetKey(KeyCode.Y)) && pressed == false)
        {            
            timer += Time.deltaTime;            
        }

        if ((Input.GetButtonUp("BButton") || Input.GetKeyUp(KeyCode.Y)) && pressed == false)
        {
            timer = 0;            
        }
            
        //ATAQUE DEL PERSONAJE
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

    /// <summary>
    /// Control de las animaciones del personaje al atacar
    /// </summary>
    /// <param name="boolean"></param>
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

    /// <summary>
    /// Reseteo de los brazos una vez terminado el ataque
    /// </summary>
    void ResetArms()
    {
        brazo1.SetActive(false);
        brazo2.SetActive(false);
    }


    /// <summary>
    /// Funcion que voltea al personaje y las animaciones
    /// </summary>
    void flip()
    {

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (direccion == Direccion.derecha)
            direccion = Direccion.izquierda;
        else
            direccion = Direccion.derecha;
    }

    /// <summary>
    /// Getter del tiempo que permanece el player quieto
    /// </summary>
    /// <returns></returns>
    public float getStopTime()
    {
        return stopTime;
    }

    /// <summary>
    /// Getter de si el personaje esta saltando
    /// </summary>
    /// <returns></returns>
    public bool getIsJumping()
    {
        return isJumping;
    }

    /// <summary>
    /// Setter de si el personaje esta saltando
    /// </summary>
    /// <param name="value"></param>
    public void setIsJumping(bool value)
    {
        isJumping = value;
    }

    /// <summary>
    /// Setter de la vibracion del mando al saltar
    /// </summary>
    /// <param name="value"></param>
    public void setVibrationJump(bool value)
    {
        isJumpingVibr = value;
    }
    /// <summary>
    /// Setter de la vibracion del mando al hacer dash
    /// </summary>
    /// <param name="value"></param>
    public void setVibrationDash(bool value)
    {
        isDashing = value;
    }

    /// <summary>
    /// Play del sonido cuando el jugador salta
    /// </summary>
    public void PlayClipJump()
    {
        source.clip = clips[0];
        source.Play();
    }

    /// <summary>
    /// Play del sonido cuando el jugador cae
    /// </summary>
    public void PlayClipFall()
    {
        source.clip = clips[1];
        source.Play();
    }
        
    /// <summary>
    /// Play del sonido cuando el jugador dispara
    /// </summary>
    public void PlayClipShoot()
    {
        source.clip = clips[2];
        source.Play();
    }

    /// <summary>
    /// Play del sonido cuando el disparo colisiona
    /// </summary>
    public void PlayClipShotHit()
    {
        sourceShoot.clip = clips[3];
        sourceShoot.Play();
    }

    /// <summary>
    /// Play del sonido cuando el jugador hace dash
    /// </summary>
    public void PlayClipDash()
    {
        source.clip = clips[4];
        source.Play();
    }

    /// <summary>
    /// Play del sonido cuando el jugador es herido
    /// </summary>
    public void PlayClipHurt()
    {
        source.clip = clips[5];
        source.Play();
    }

    /// <summary>
    /// Play del sonido cuando el jugador camina
    /// </summary>
    public void PlayClipWalk()
    {
        sourceWalk.clip = clips[4];
        sourceWalk.loop = true;
        sourceWalk.Play();
    }
}
