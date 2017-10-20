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

    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;

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
        HandleWallSliding();

        //habilidad de correr
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //se le asigna la velocidad de correr
            moveSpeed = runSpeed;
        }

        else
        {
            //se le asigna la velocidad normal
            moveSpeed = normalSpeed;
        }

        if (permitido)
        {
            controller.Move(velocity * Time.deltaTime, directionalInput);

            if (controller.collisions.above || controller.collisions.below)
            {
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
                //para voltear el sprite en la direccion a la que nos dirigmos
                //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            else if (0 > directionalInput.x)
            {
                direccion = -1;
                //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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

        isJumping = true;
        if (wallSliding)
        {
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
        }
        else
        {
            if (1 > numeroSaltos)
            {
                numeroSaltos++;
                multiplicadorSalto = 1;
                velocity.y = maxJumpVelocity * multiplicadorSalto;
            }
            else
            if (2 > numeroSaltos && canSecondJump)
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
        if (coll.collider.tag == "Suelo")
        {
            poderesScript.SetDashUse(true);
            permitido = true;
            isJumping = false;
            numeroSaltos = 0;
            canSecondJump = false;
            entraColisionPared = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.name == "Trigger")
        {
            triggerCameraSize tri = other.gameObject.GetComponent<triggerCameraSize>();

            tri.setLerp(true);

            tri.setVelocidadEscala(-1);

            tri.setMoveExtra(new Vector3(0, 0, 0));
        }

        if (other.name == "CameraBlock")
        {
            TriggerCameraBlock tri = other.gameObject.GetComponent<TriggerCameraBlock>();

            tri.SetBlockMov(false);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Trigger")
        {
            triggerCameraSize tri = other.gameObject.GetComponent<triggerCameraSize>();

            tri.setLerp(true);

            tri.setVelocidadEscala(1);

            tri.setMoveExtraGuardado();
        }

        if (other.name == "CameraBlock")
        {
            TriggerCameraBlock tri = other.gameObject.GetComponent<TriggerCameraBlock>();

            tri.SetBlockMov(true);
        }

    }

    void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
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
}

