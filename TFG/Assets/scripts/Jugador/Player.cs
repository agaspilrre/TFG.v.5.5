using UnityEngine;
using System.Collections;
/// <summary>
/// CLASE ENCARGADA DE CALCULAR Y REALIZAR LOS MOVIMIENTOS DEL PLAYER, TANTO HORIZONTALES, COMO DE SALTO , COMO DE WALLJUMPING
/// requiere componente Controller2D que se encarga de detectar las colisiones
/// </summary>

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    /// <summary>
    /// Maxima altura de salto
    /// </summary>
    public float maxJumpHeight = 4;

    /// <summary>
    /// Valores de salto
    /// </summary>
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;  
    float accelerationTimeAirborne = .2f;
    public float accelerationTimeGrounded = .1f;

    /// <summary>
    /// Velocidad de movimiento 
    /// </summary>
    public float moveSpeed = 6;

    /// <summary>
    /// Velocidad al correr
    /// </summary>
    public float runSpeed;

    /// <summary>
    /// Velocidad de decrecimiento
    /// </summary>
    public float decreeseSpeed;

    /// <summary>
    /// Referencia al script Collider2D
    /// </summary>
    Collider2D myCollider;

    /// <summary>
    /// Variable para devolver la velocidad normal del jugador
    /// </summary>
    float normalSpeed;

    /// <summary>
    /// Vector2 que guardan valores relacionados con el walljump
    /// </summary>
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    /// <summary>
    /// Velocidad de deslizamiento
    /// </summary>
    public float wallSlideSpeedMax = 3;

    /// <summary>
    /// Tiempo de stick en la pared
    /// </summary>
    public float wallStickTime = .25f;

    /// <summary>
    /// Tiempo para despegarse de la pared
    /// </summary>
    public float timeToWallUnstick;

    /// <summary>
    /// Variable para el doble salto
    /// </summary>
    public float multiplicadorSalto;

    /// <summary>
    /// Variable auxiliar para el doble salto
    /// </summary>
    float savedMultiplicadorSaltos;

    /// <summary>
    /// Velocidad para atacar
    /// </summary>
    public float speedAttacking;

    /// <summary>
    /// Gravedad del personaje
    /// </summary>
    float gravity;

    /// <summary>
    /// Maxima velocidad de salto
    /// </summary>
    float maxJumpVelocity;

    /// <summary>
    /// Minima velocidad de salto
    /// </summary>
    float minJumpVelocity;

    /// <summary>
    /// Vector de velocidad
    /// </summary>
    Vector3 velocity;
    float velocityXSmoothing;

    /// <summary>
    /// Booleano para permitir o no el movimiento
    /// </summary>
    public bool permitido;

    /// <summary>
    /// Booleano para determinar si entra en colision con una pared
    /// </summary>
    bool entraColisionPared = false;

    /// <summary>
    /// Referencia al script de poderes
    /// </summary>
    Poderes poderesScript;

    /// <summary>
    /// Referencia a la direccion del personaje
    /// </summary>
    int direccion;
    
    /// <summary>
    /// Contador de saltos
    /// </summary>
    int numeroSaltos;

    /// <summary>
    /// Referencia al script controller2D
    /// </summary>
    Controller2D controller;

    /// <summary>
    /// Referencia al script playerInput
    /// </summary>
    PlayerInput input;

    /// <summary>
    /// Referencia al script de staminaBar
    /// </summary>
    HabilityBar staminaBar;

    /// <summary>
    /// Referencia al script de playerAnim
    /// </summary>
    PlayerAnim playerAnim;
    
    /// <summary>
    /// Vector2 para el input del personaje
    /// </summary>
    Vector2 directionalInput;

    /// <summary>
    /// Booleano para determinar si esta deslizando pro la pared
    /// </summary>
    public bool wallSliding;

    /// <summary>
    /// 
    /// </summary>
    int wallDirX;

    /// <summary>
    /// Booleano para ralentizar al personaje 
    /// </summary>
    private bool makeSlow;

    /// <summary>
    /// Timer auxiliar para ralentizar al personaje
    /// </summary>
    private float timer;

    /// <summary>
    /// Tiempo que se ralentiza al personaje
    /// </summary>
    private float timerSlow;

    /// <summary>
    /// Velocidad cuando esta ralentizado
    /// </summary>
    private float slowSpeed;

    /// <summary>
    /// Variable para modular peso en la caida
    /// </summary>
    public float fallWeight;

    /// <summary>
    /// Booleano para determinar si esta haciendo wall jump
    /// </summary>
    public bool wallJump;

    /// <summary>
    /// Booleano para determinar si el jugador esta situado en una plataforma por la que puede descender
    /// </summary>
    bool isInDescendPlatform;

    /// <summary>
    /// Booleano para determinar si el jugador puede hacer el segundo salto
    /// </summary>
    bool canSecondJump;

    /// <summary>
    /// Booleano para activar el doble salto al personaje
    /// </summary>
    public bool enableDoubleJump;

    /// <summary>
    /// Booleano para mostrar las particulas de caida
    /// </summary>
    bool canShowfallParticles;

    /// <summary>
    /// Referencia al rigidbody del personaje
    /// </summary>
    Rigidbody2D rb;

    /// <summary>
    /// Referencia al script de shake de la camara
    /// </summary>
    CameraShake shake;

    /// <summary>
    /// Particulas de salto
    /// </summary>
    [SerializeField]
    GameObject jumpParticles;

    /// <summary>
    /// Punto de spawn de de las particulas de salto
    /// </summary>
    [SerializeField]
    Transform spawnJumpParticles;

    /// <summary>
    /// Particulas de wallJump
    /// </summary>
    [SerializeField]
    GameObject wallParticles;

    /// <summary>
    /// Punto de spawn a la derecha de de las particulas de walljump
    /// </summary>
    [SerializeField]
    Transform spawnWallRightParticles;

    /// <summary>
    /// Punto de spawn a la izquierda de de las particulas de walljump
    /// </summary>
    [SerializeField]
    Transform spawnWallLeftParticles;

    /// <summary>
    /// Particulas de caida
    /// </summary>
    [SerializeField]
    GameObject fallParticles;


    void Start()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

        permitido = true;
        isInDescendPlatform = false;
        canShowfallParticles = false;
        direccion = 1;
        poderesScript = GetComponent<Poderes>();
        playerAnim = GetComponent<PlayerAnim>();
        
        input = GetComponent<PlayerInput>();
        staminaBar = GetComponent<HabilityBar>();
        //isJumping = false;
        speedAttacking = 1;
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        numeroSaltos = 0;
        //guardamos la velocidad normal del player en una variable
        normalSpeed = moveSpeed;
        savedMultiplicadorSaltos = multiplicadorSalto;

        rb = GetComponent<Rigidbody2D>();
        
    }

    /// <summary>
    /// Metodo que establece fuerza de gravedad al personaje
    /// </summary>
    public void returnGravity()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
    }

    /// <summary>
    /// Metodo que anula la gravedad y la velocidad en el eje y del player
    /// </summary>
    public void setGravity0()
    {
        gravity = 0;
        velocity.y = 0;
    }

    void Update()
    {
        CalculateVelocity();
        HandleWallSliding();          

        //habilidad de correr
        /*
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("PS4_R3"))
        {
            //se le asigna la velocidad de correr
            moveSpeed = runSpeed;
        }

        else
        {
            //se le asigna la velocidad normal
            moveSpeed = normalSpeed;
        }
        */

        //realentizacion o aumento de velocidad
        if (makeSlow)
        {
            moveSpeed = slowSpeed;
            playerAnim.setAnimatorSpeed(0.5f);
            timer += Time.deltaTime;
            if (timer >= timerSlow)
            {               
                makeSlow = false;
                timer = 0;
                playerAnim.setAnimatorSpeed(1f);
                moveSpeed = normalSpeed;
            }
        }

        if (permitido)
        {
            controller.Move(velocity * Time.deltaTime, directionalInput);            

            if (controller.collisions.above || controller.collisions.below)
            {
                //staminaBar.isWallJumping = false;

                if (controller.collisions.slidingDownMaxSlope)
                {
                    velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
                }
                else
                {
                    velocity.y = 0;
                }
            }

            if (directionalInput.x > 0)
            {
                direccion = 1;               
            }

            else if (0 > directionalInput.x)
            {
                direccion = -1;                
            }

        }

        //anular un salto si salimos de walljump o caemos
        if (velocity.y<-5 && !wallSliding && numeroSaltos==0)
        {
            numeroSaltos++;
          
            multiplicadorSalto = 1;
        }

        //activa la animacion de caer cuando no tenemos saltos y caemos
        //la animacion se desactiva en el metodo donde se desactivan todas las animaciones playeranim
        if (velocity.y < -5 && !wallSliding && numeroSaltos >= 1)
        {
            playerAnim.Fall(true);
            
        }

        

        //modular peso en la caida
        //Debug.Log("la velocidad en y es:"+velocity.y);
        if (velocity.y <= 0 && velocity.y >= -100)
        {
            //Debug.Log("la velocidad en y es:" + velocity.y);
           
            velocity.y *= fallWeight;//modula el peso de la caida
           
        }      

    }
    
  
    /// <summary>
    /// obtiene la velocidad en el eje y del player
    /// </summary>
    /// <returns></returns>
    public float getVelocityY()
    {
        return velocity.y;
    }

    /// <summary>
    /// establece una velocidad en el eje Y al player recibida como parametro.
    /// </summary>
    /// <param name="_value"></param>
    public void setVelocityY(float _value)
    {
        velocity.y = _value;
    }

    //public void activateScriptAndMovement()
    //{
    //    this.enabled = true;
    //    permitido = true;
    //}

    /// <summary>
    /// asigna la direccion que tiene los inputs
    /// </summary>
    /// <param name="input"></param>
    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    /// <summary>
    /// Getter del directional input del personaje
    /// </summary>
    /// <returns></returns>
    public Vector2 GetDirectionalInput()
    {
        return directionalInput;
    }

    /// <summary>
    /// Metodo que muestra si el jugador se encuentra o no en estado de walljumping
    /// </summary>
    /// <returns></returns>
    public bool getWallSliding()
    {
        return wallSliding;
    }

    /// <summary>
    /// Metodo que gestiona el comportamiento del salto, doble salto y wallJump 
    /// </summary>
    public void OnJumpInputDown()
    {
        if (!controller.getDown())
        {
            canShowfallParticles = false;

            if (wallSliding || wallJump)
            {               
                numeroSaltos = 1;                
                
                playerAnim.WallJump(true);

                if (wallDirX == directionalInput.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (directionalInput.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
                //}           

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    GameObject gb = Instantiate(wallParticles, spawnWallRightParticles.position, spawnWallRightParticles.rotation);
                    Destroy(gb, 1);                   
                }
                else
                {
                    GameObject gb = Instantiate(wallParticles, spawnWallLeftParticles.position, spawnWallLeftParticles.rotation);
                    Destroy(gb, 1);
                }
            }
            else
            {             

                if (1 > numeroSaltos)
                {
                    numeroSaltos++;
                    multiplicadorSalto = 1;
                    velocity.y = maxJumpVelocity * multiplicadorSalto;
                    GameObject gb = Instantiate(jumpParticles, spawnJumpParticles.position, spawnJumpParticles.rotation);
                    Destroy(gb, 2);
                    canShowfallParticles = true;
                }
                else if (2 > numeroSaltos && enableDoubleJump) // && staminaBar.slider.value > 0)
                {
                    numeroSaltos++;
                    multiplicadorSalto = savedMultiplicadorSaltos;
                    velocity.y = maxJumpVelocity * multiplicadorSalto;
                    GameObject gb = Instantiate(jumpParticles, spawnJumpParticles.position, spawnJumpParticles.rotation);
                    Destroy(gb, 2);
                    canShowfallParticles = true;

                }
            }

            if (controller.collisions.below)
            {
                if (controller.collisions.slidingDownMaxSlope)
                {
                    if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                    { // not jumping against max slope
                        velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
                        velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
                    }
                } /*else
            {                        
               velocity.y = maxJumpVelocity;	
			}*/
            }
        }
        

    }

    //funcion para controlar el numero de saltos para la accion de pulsar R despues del primer salto
    /// <summary>
    /// Funcion que devuelve el numero de saltos que ha dado el jugador en el aire
    /// </summary>
    /// <returns></returns>
    public int getNumSaltos()
    {
        return numeroSaltos;
    }

    //cambiar la variable para permitir el segundo salto, se cambia cuando pulsamos R y ya hemos saltado una vez script Poderes
    /// <summary>
    /// Funcion que asigna valor al bool que indica si el player puede realizar o no un segundo salto en el aire
    /// </summary>
    /// <param name="_value"></param>
    public void setCanSecondJump(bool _value)
    {
        canSecondJump = _value;
    }

    /// <summary>
    /// Metodo que ajusta la velocidad de salto a su minimo si la fuerza en Y es superada
    /// </summary>
    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;            
        }

        
    }
    
    /// <summary>
    /// Devuelve la direccion en la que el player esta mirando
    /// </summary>
    /// <returns></returns>
    public int getDireccion()
    {
        return direccion;
    }

    /// <summary>
    /// Funcion que establece el valor del bool para permitir o no el movimiento del player
    /// </summary>
    /// <param name="prueba"></param>
    public void setPermitido(bool prueba)
    {
        permitido = prueba;
    }

    /// <summary>
    /// Metodo que devuelve si el player se esta moviendo o no
    /// </summary>
    /// <returns></returns>
    public bool getIsMoving()
    {
        if (directionalInput.x != 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Cuando el jugador colisiona con determinados objetos
    /// </summary>
    /// <param name="coll"></param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Suelo")
        {
            isInDescendPlatform = false;
            poderesScript.SetDashUse(true);
            permitido = true;
            controller.down = false;
            //isJumping = false;
            input.isJumping = false;
            velocity = new Vector3(0, 0, 0);
            playerAnim.Fall(false);

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerAnim.jumpToRun();
                
                //playerAnim.dashToRun();
            }
            else
            {
                playerAnim.JumpToIdl();
                //playerAnim.DashToIdl();
            }

            if(numeroSaltos == 1 || numeroSaltos == 2)
            {                
                //shake.Shake(0.2f);
                input.setVibrationJump(true);
            }

            if ((numeroSaltos == 1 || numeroSaltos == 2) && canShowfallParticles)
            {
                GameObject gb = Instantiate(fallParticles, spawnJumpParticles.position, spawnJumpParticles.rotation);
                Destroy(gb, 2);
            }

            numeroSaltos = 0;
            canSecondJump = false;
            entraColisionPared = true;           
        }        

        if (coll.collider.name == "Platform")
        {
            transform.parent = coll.transform;
            rb.AddForce(new Vector2(0, -1000) , ForceMode2D.Force);
            //velocity.y = 0;
            this.enabled = false;
        }        

        if (coll.gameObject.tag == "EnemyRotate")
        {
            setMakeSlow(true, 3, 3);
        }
    }

    /// <summary>
    /// Cuando el jugador permanece en colision con determinados objetos
    /// </summary>
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.name == "Platform")
        {
            this.enabled = true;
            transform.parent = coll.transform;
            //rb.AddForce(new Vector2(0, -2), ForceMode2D.Force);
           
        }
    }

    /// <summary>
    /// Cuando el jugador deja de colisionar con determinados objetos
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.name == "Platform")
        {
            //this.enabled = false;
            transform.parent = null;
        }      
    }

    /// <summary>
    /// Cuando el personaje entra en determinados triggers
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ( coll.tag == "Through")
        {
            poderesScript.SetDashUse(true);
            permitido = true;
            isInDescendPlatform = true;
            //isJumping = false;
            //playerAnim.idlToJumpFalse(); 

            //PARA CRTAR LA ANIMACION DE SALTO CUANDO CAE AL SUELO
            if (Input.GetAxisRaw("Horizontal") != 0)
            {                
                playerAnim.jumpToRun();
                //playerAnim.dashToRun();
            }
            else
            {
                playerAnim.JumpToIdl();
                input.setIsJumping(false);
                //playerAnim.DashToIdl();
            }

            numeroSaltos = 0;
            canSecondJump = false;
            entraColisionPared = true;
        }
        else if(coll.tag == "WallJump")
        {
            wallJump = true;
            playerAnim.setFalseAllAnimations();
            playerAnim.ForceWallJump();
            playerAnim.DoubleJumpFalse();
            canShowfallParticles = false;

        }
        else 
        if (coll.tag == "PowerUp")
        {
            Destroy(coll.gameObject);
            coll.transform.parent.GetComponent<PowerUp>().setBoxBroken(true);
            coll.transform.parent.GetComponent<PowerUp>().PowerUpInstantiate();
        }

        //if (coll.tag == "Gravity")
        //{
        //    permitido = false;
        //    this.enabled = true;
        //}

    }

    /// <summary>
    /// Cuando el personaje sale de determinados triggers
    /// </summary>
    /// <param name="coll"></param>
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "WallJump")
        {
            wallJump = false;
            //playerAnim.WallJump(false);            
        }

        if (coll.tag == "Through")
        {
            isInDescendPlatform = false;
        }
    }

    /// <summary>
    /// Metodo para el deslizamiento en la pared del wall jump
    /// </summary>
    void HandleWallSliding()
    {        
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if (( controller.collisions.left || controller.collisions.right) && !controller.collisions.below)
        {           
             playerAnim.WallJump(true);
            
            if (entraColisionPared)
            {
                canShowfallParticles = false;
                timeToWallUnstick = wallStickTime;
                entraColisionPared = false;
            }

            wallSliding = true;
            

            if (velocity.y < wallSlideSpeedMax)
            {               
                velocity.y = -wallSlideSpeedMax;
            }

            //if (timeToWallUnstick > 0)
            //{                
            //    velocityXSmoothing = 0;
            //    velocity.x = 0;
            //    velocity.y = 0;                
            //    timeToWallUnstick -= Time.deltaTime;

            //}
        }

    }

    /// <summary>
    /// metodo que indica si el player esta en el aire
    /// </summary>
    /// <returns></returns>
    public bool GetIsInAir()
    {
        return controller.collisions.below ? true : false;
    }

    /// <summary>
    /// Metodo para calcular la velocidad en x del personaje
    /// </summary>
    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;

        targetVelocityX = controller.collisions.below ? targetVelocityX : targetVelocityX * decreeseSpeed;

        if (speedAttacking == 0)
        {
            velocity.x = 0;
        }
        else
        {
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            //velocity.x = targetVelocityX;
        }

        
        velocity.y += gravity * Time.deltaTime;
    }
    
    /// <summary>
    /// Metodo que asigna la realentizacion del player con los parametros de tiempo, velocidad y bool recibidos
    /// </summary>
    /// <param name="_makeS"></param>
    /// <param name="_timeSlow"></param>
    /// <param name="_speed"></param>
    public void setMakeSlow(bool _makeS,float _timeSlow,float _speed)
    {
        
        timerSlow = _timeSlow;
        slowSpeed = _speed;
        makeSlow = _makeS;
    }

    /// <summary>
    /// Getter del booleano para determinar si esta en una plataforma por la que puede descender
    /// </summary>
    /// <returns></returns>
    public bool GetIsInDescendPlatform()
    {
        return isInDescendPlatform;
    }

   
}

