using UnityEngine;
using System.Collections;

public class Poderes : MonoBehaviour {

    public float duracionDash = 1f;

    public Material materialCargaDash;

    public float distanciaDash = 1f;

    public float distanciaElectroDash = 1f;

    public float duracionElectroDash = 1f;

    public float velocidadDash;

    public float velocidadElectroDash;

    Vector3 Seguimiento;

    float initGravity;

    public float cargaDash;

     public bool dashUse;

    public Transform personajeTrans;

    Player personajeMovimiento;
    //rigidbody del personaje
    Rigidbody2D personajeRB;

    ObjectAbsorb objectAb;

	// Use this for initialization
	void Start () {
        //calcular la velocidad del dash
        velocidadDash = distanciaDash / duracionDash;

        velocidadElectroDash = distanciaElectroDash / duracionElectroDash;
        //referencia al protagonista
        personajeMovimiento = GetComponent<Player>();
        //referencia al personaje
        personajeRB = GetComponent<Rigidbody2D>();
        //guarda la escala 
        initGravity = personajeRB.gravityScale;

        objectAb = GetComponent<ObjectAbsorb>();

        //variable que controla el numero de dush que se puede hacer, en principio se activa cuando el personaje toca el suelo
        dashUse = true;

        cargaDash = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //input para el dash
        if (Input.GetButton("Dash") && dashUse)//calcula cuanto tiempo llevas apretando
        {
            personajeMovimiento.setPermitido(false);

            cargaDash += Time.deltaTime;

            if (cargaDash > 0.3)
            {
                materialCargaDash.color = Color.white;
            }
        }
        if (Input.GetButtonUp("Dash") && dashUse)
        {

            materialCargaDash.color = Color.black;

            if (cargaDash<0.3)//si es menor alo que este numero dash normal
            {
                dash();
            }
            else
            {
                electroDash();
            }
            
            cargaDash = 0;
        }

      // if (Input.GetKeyDown(KeyCode.C))
       //     objectAb.Absorb();
        
        
    }

    void dash()
    {
        personajeMovimiento.setGravity0();
        personajeRB.velocity = new Vector2(personajeMovimiento.getDireccion() * velocidadDash , 0);

        dashUse = false;
        //despues del tiempo del dash volver a permitir movimiento
        Invoke("dashPermitido",duracionDash);
    }   

    void electroDash()
    {
        personajeMovimiento.setGravity0();
        personajeRB.velocity = new Vector2(personajeMovimiento.getDireccion() * velocidadElectroDash, 0);

        dashUse = false;
        //despues del tiempo del dash volver a permitir movimiento
        Invoke("dashPermitido", duracionElectroDash);
    }

    void dashPermitido()
    {
        personajeMovimiento.returnGravity();
        personajeMovimiento.setPermitido(true);
        //volvemos activar la gravedad una vez finalizado el dush
        personajeRB.gravityScale = initGravity;

        if (!personajeMovimiento.getIsJumping())
        {
            Invoke("dushGround",duracionDash);
        }
        

    }


    public void SetDashUse(bool use)
    {

        dashUse = use;
    }

    void dushGround()
    {
        dashUse = true;
    }

}
