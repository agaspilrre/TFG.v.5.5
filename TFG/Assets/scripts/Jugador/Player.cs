using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    public float moveSpeed = 6;
    public float runSpeed;

    float normalSpeed;
    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    public float timeToWallUnstick;
    public float multiplicadorSalto;
    float savedMultiplicadorSaltos;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    public bool permitido;
    bool entraColisionPared = false;
    Poderes poderesScript;
    int direccion;
    bool isJumping;
    int numeroSaltos;

    Controller2D controller;
    PlayerInput input;
    HabilityBar staminaBar;
    PowerUp controlPU;

    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;

    private bool makeSlow;
    private float timer;
    private float timerSlow;
    private float slowSpeed;
    //variable para modular peso en la caida
    public float fallWeight;

    public bool canSecondJump;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

        permitido = true;
        direccion = 1;
        poderesScript = GetComponent<Poderes>();
        controlPU = GameObject.Find("ControlPowerUp").GetComponent<PowerUp>();
        input = GetComponent<PlayerInput>();
        staminaBar = GetComponent<HabilityBar>();
        isJumping = false;
       
        numeroSaltos = 0;
        //guardamos la velocidad normal del player en una variable
        normalSpeed = moveSpeed;
        savedMultiplicadorSaltos = multiplicadorSalto;
    }

    public void returnGravity()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
    }

    public void setGravity0()
    {
        gravity = 0;
        velocity.y = 0;

    }

    void Update()
    {
        CalculateVelocity();


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
            timer += Time.deltaTime;
            if (timer >= timerSlow)
            {
                
                makeSlow = false;
                timer = 0;
                moveSpeed = normalSpeed;
            }
        }

        if (permitido)
        {
            controller.Move(velocity * Time.deltaTime, directionalInput);            

            if (controller.collisions.above || controller.collisions.below)
            {
                staminaBar.isWallJumping = false;

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

        //modular peso en la caida
        //Debug.Log("la velocidad en y es:"+velocity.y);
        if (velocity.y <= 0 && velocity.y >= -100)
        {
            velocity.y *= fallWeight;
        }

    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        HandleWallSliding();
        if (wallSliding && staminaBar.slider.value > 0)
        {
            staminaBar.isWallJumping = true;
            //para quitar el salto extra que hay al hacer walljumping
            numeroSaltos = 1;            
            //if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetKeyDown(KeyCode.Space))
            //{
                if (wallDirX == directionalInput.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;
                }
                else if (directionalInput.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            //}
            
        }
        else
        {
            if (1 > numeroSaltos)
            {
                numeroSaltos++;
                multiplicadorSalto = 1;
                velocity.y = maxJumpVelocity * multiplicadorSalto;
            }
            else if (2 > numeroSaltos  && staminaBar.slider.value > 0)
            {
                numeroSaltos++;
                multiplicadorSalto = savedMultiplicadorSaltos;
                velocity.y = maxJumpVelocity * multiplicadorSalto;
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

    //funcion para controlar el numero de saltos para la accion de pulsar R despues del primer salto
    public int getNumSaltos()
    {
        return numeroSaltos;
    }

    //cambiar la variable para permitir el segundo salto, se cambia cuando pulsamos R y ya hemos saltado una vez script Poderes
    public void setCanSecondJump(bool _value)
    {
        canSecondJump = _value;
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }

    }

    public bool getIsJumping()
    {
        return isJumping;
    }

    public int getDireccion()
    {
        return direccion;
    }

    public void setPermitido(bool prueba)
    {
        permitido = prueba;
    }

    public bool getIsMoving()
    {
        if (directionalInput.x != 0)
            return true;
        else
            return false;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.tag == "Suelo" )
        {
            poderesScript.SetDashUse(true);
            permitido = true;
            isJumping = false;
            numeroSaltos = 0;
            canSecondJump = false;
            entraColisionPared = true;
        }        

        if (coll.collider.name == "Platform")
        {
            transform.parent = coll.transform;
        }

        if (coll.gameObject.tag == "PowerUp")
        {
            Destroy(coll.gameObject);
            controlPU.setBoxBroken(true);
            controlPU.PowerUpInstantiate();
        }

        if (coll.gameObject.tag == "EnemyRotate")
        {
            setMakeSlow(true, 3, 3);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if ( coll.tag == "Through")
        {
            poderesScript.SetDashUse(true);
            permitido = true;
            isJumping = false;
            numeroSaltos = 0;
            canSecondJump = false;
            entraColisionPared = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.name == "Platform")
            transform.parent = null;
    }


    void HandleWallSliding()
    {        
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below)
        {            
            if (entraColisionPared)
            {               
                timeToWallUnstick = wallStickTime;
                entraColisionPared = false;
            }

            wallSliding = true;
            
            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {                
                velocityXSmoothing = 0;
                velocity.x = 0;
                velocity.y = 0;                
                timeToWallUnstick -= Time.deltaTime;

            }
        }

    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }

    
    public void setMakeSlow(bool _makeS,float _timeSlow,float _speed)
    {
        
        timerSlow = _timeSlow;
        slowSpeed = _speed;
        makeSlow = _makeS;
    }

   
}

