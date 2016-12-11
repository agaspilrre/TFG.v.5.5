using UnityEngine;
using System.Collections;

public class Poderes : MonoBehaviour {

    public float duracionDash = 1f;

    public float distanciaDash = 1f;

    float velocidadDash;

    float initGravity;

    bool dashUse;

    personajeMOV personajeMovimiento;
    //rigidbody del personaje
    Rigidbody2D personajeRB;

	// Use this for initialization
	void Start () {
        //calcular la velocidad del dash
        velocidadDash = distanciaDash / duracionDash;
        //referencia al protagonista
        personajeMovimiento = GetComponent<personajeMOV>();
        //referencia al personaje
        personajeRB = GetComponent<Rigidbody2D>();
        //guarda la escala 
        initGravity = personajeRB.gravityScale;

        //variable que controla el numero de dush que se puede hacer, en principio se activa cuando el personaje toca el suelo
        dashUse = true;

    }
	
	// Update is called once per frame
	void Update () {
        //input para el dash
        if (Input.GetKeyDown(KeyCode.E) && dashUse)
        {
            dash();
        }
    }

    void dash()
    {
        personajeMovimiento.setPermitido(false);
        personajeRB.gravityScale = 0;//para que el personaje no caiga mientras hace el dush
        personajeRB.velocity = new Vector2(personajeMovimiento.getDireccion() * velocidadDash * distanciaDash, 0);

        dashUse = false;
        //despues del tiempo del dash volver a permitir movimiento
        Invoke("dashPermitido",duracionDash);
    }

    void dashPermitido()
    {
        personajeMovimiento.setPermitido(true);
        //volvemos activar la gravedad una vez finalizado el dush
        personajeRB.gravityScale = initGravity;
        

    }


    public void SetDashUse(bool use)
    {

        dashUse = use;
    }

}
