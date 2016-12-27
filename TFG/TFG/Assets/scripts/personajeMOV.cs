using UnityEngine;
using System.Collections;

public class personajeMOV : MonoBehaviour {

    public float speed = 10f;

    public float alturaSalto;

    //comprueba la velocidad para que no sea superior al speed
    float comparador;

    //permitir saltar con la pared
    bool permitirSaltoPared;

    float movex = 0f;

    //numero de salto, 1 primer salto 2 segundo salto
    int numSalto;

    public Rigidbody2D rb;

    bool permitido;

    float fuerza;

    public float reboteSaltoPared = 10;

    //PROVISIONAL
    public float distanciaSaltoPared;
    public float alturaSaltoPared;
    enum Direccion { izquierda, derecha }
    Direccion direccionMov;


    //1 derecha  && - 1 izquierda
    int direccion;

    public float speedRun;
    public bool run;

    bool isJumping;

    //variable que usamos para guardar el script de los poderes
    Poderes poderesScript;

    public float timeWallJumping;
    float gravityInit;

    void Start()
    {
        numSalto = 1;

        permitido = true;

        direccion = 1;

        permitirSaltoPared = false;

        isJumping = false;

        //necesito el script de poderes para modificar booleano del dush para controlarlo cada vez que toque el suelo
        poderesScript = GetComponent<Poderes>();

        gravityInit = rb.gravityScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //control y dinamica de salto
        //si la velocidad en Y es negativa significa que el personaje ya esta cayendo
        
        if (rb.velocity.y < 0 && numSalto==2)
        {
            rb.gravityScale = gravityInit + 1;
        }


        //PROVISIONAL
        if (permitirSaltoPared)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(direccionMov);
                //hacer un enum de izquierda derecha.
                if (direccionMov == Direccion.derecha)
                {
                    rb.AddForce(new Vector2(-distanciaSaltoPared, alturaSaltoPared), ForceMode2D.Impulse);
                    direccionMov = Direccion.izquierda;
                }

                else
                {
                    rb.AddForce(new Vector2(distanciaSaltoPared, alturaSaltoPared), ForceMode2D.Impulse);
                    direccionMov = Direccion.derecha;
                }
                
            }
        }


        //si se permite el movimiento del personaje
        if (permitido)
        {
            //movimiento
          
             movex = Input.GetAxis("Horizontal");



            //velocidad en x del personaje
            if (!run)
                comparador = movex * speed + rb.velocity.x;
            else
                comparador = movex * speedRun + rb.velocity.x;


            //para correr
            if (Input.GetKey(KeyCode.P))
            {
                
                run = true;
                
            }

            
            if (Input.GetKeyUp(KeyCode.P))
            {
                run = false;
            }
            

                //si es superior se igualan
            if (comparador > speed)
            {
                if (!run)
                    comparador = speed;

                else
                    comparador = speedRun;
            }
               
            //comprobacion en ambas direcciones
            if (comparador < -speed)
            {
                if (!run)
                    comparador = -speed;
                else
                    comparador = -speedRun;
            }
                

            rb.velocity = new Vector2(comparador, rb.velocity.y);

            //izquierda
            if (movex < 0)
            {
                direccion = -1;
                direccionMov = Direccion.izquierda;
            }

            if (movex > 0)
            {
                //derecha
                direccion = 1;
                direccionMov = Direccion.derecha;
            }

            //salto
            if (Input.GetKeyDown("space"))
            {
                //solo entra si no esta en contacto con la pared
                if (!permitirSaltoPared)
                {
                    //comprobacion del doble salto
                    if (numSalto < 3)
                    {
                        //saltar();


                        if (numSalto == 1)
                            rb.AddForce(new Vector2(0, alturaSalto) - new Vector2(0, rb.velocity.y), ForceMode2D.Impulse);


                        else if (numSalto == 2)
                            rb.AddForce(new Vector2(0, alturaSalto + 2) - new Vector2(0, rb.velocity.y), ForceMode2D.Impulse);

                        isJumping = true;
                        numSalto++;
                    }
                }
                else
                {
                    //giramos al personaje
                    direccion = -direccion;
                    direccionMov = Direccion.izquierda;

                    //saltarPared();

                    //Invoke("DesactivationWallJumping", timeWallJumping);

                }

              

            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //comprobacion choque con el suelo
        if (coll.collider.name =="Suelo")
        {
            //resetear los saltos
            numSalto = 1;
            //pongo la escala de gravedad a su valor original
            rb.gravityScale = gravityInit;

            //PROVISIONAL
            isJumping = false;
            permitido = true;

            //resetear el dush
            poderesScript.SetDashUse(true);

        }
        //comprobacion choque con pared
        if(coll.collider.tag == "Pared")
        {
            
            if (isJumping)
            {
                permitirSaltoPared = true;
                permitido = false;
            }
               
            
        }
    }

    

    void OnCollisionExit2D(Collision2D coll)
    {
        //comprobacion choque con pared
        if (coll.collider.tag == "Pared")
        {
            permitirSaltoPared = false;

            //PROVISIONAL
            //permitido = true;
        }
    }

    void saltar()
    {
        if(numSalto==1)
             rb.AddForce(new Vector2(0, alturaSalto) - new Vector2(0, rb.velocity.y), ForceMode2D.Impulse);

        else if(numSalto==2)
            rb.AddForce(new Vector2(0, alturaSalto+2)-new Vector2(0,rb.velocity.y),ForceMode2D.Impulse);
       
    }

    //salto con la pared
    void saltarPared()
    {

        rb.AddForce(new Vector2(reboteSaltoPared, alturaSalto)); //- new Vector2(rb.velocity.x, rb.velocity.y), ForceMode2D.Impulse);
    }

    public void setPermitido(bool permiso)
    {
        permitido = permiso;
    }

    public int getDireccion()
    {
        return direccion;
    }


    //funcion que invocaremos segun el tiempo de wallJumping
    public void DesactivationWallJumping()
    {
        permitirSaltoPared = false;

    }


}
