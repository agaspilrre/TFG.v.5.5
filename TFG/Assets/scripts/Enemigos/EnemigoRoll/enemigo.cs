using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour {

    public enum State { ataque, patrulla, carga, vulnerable };

    int direccion;//1 es derecha -1 izquierda

    State estado;

    public Material materialEnemigo;

    GameObject protagonista;

    bool endAttack;//if attack has ended
    bool canGetDamage;

    [SerializeField]
    int damage = 1;

    [SerializeField]
    float duracionCarga;
    [SerializeField]
    float durecionEnemigoVulnerable;

    [SerializeField]
    float maxDistanceFromStart;
    [SerializeField]
    float minDistanceFromStart;
    Vector3 startPosition;
    float timerForDirection;//timer so that isnt always changing direction

    float timerCarga;
    float timerVulnerable;

    Rigidbody2D rb;

    [SerializeField]
    float velocidadPatrulla;
    [SerializeField]
    float velocidadCarga;

    // Use this for initialization
    void Start () {

        estado = State.patrulla;

        protagonista = GameObject.Find("Personaje");
        startPosition = transform.position;

        direccion = 1;

        rb = GetComponent<Rigidbody2D>();

        materialEnemigo.color = Color.red;

        timerCarga = duracionCarga;
        timerVulnerable = durecionEnemigoVulnerable;

        timerForDirection = 0.5f;

        endAttack = true;
        canGetDamage = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(estado == State.patrulla)
        {
            patrullar();

            if (CheckDistance() && timerForDirection > 0.5f) // si se pasa de los maximos
                ChangeDirection();
        }
        else if(estado == State.carga)
        {
            carga();
        }
        else if(estado == State.ataque)
        {
            ataque();
        }
        else
        {
            vulnerable();
        }	
	}

    void patrullar()
    {
        rb.velocity = new Vector2(velocidadPatrulla * direccion * Time.deltaTime, 0);
    }

    void carga()
    {
        timerCarga -= Time.deltaTime;

        if (timerCarga <= 0)
        {
            setEstadoAtaque();

            endAttack = false;

            timerCarga = duracionCarga;
        }
    }

    void vulnerable()
    {
        timerVulnerable -= Time.deltaTime;

        if(timerVulnerable <= 0)
        {
            setEstadoPatrulla();

            canGetDamage = false;

            timerVulnerable = durecionEnemigoVulnerable;
        }
    }

    void ataque()
    {
        rb.velocity = new Vector2(velocidadCarga * direccion * Time.deltaTime, 0);
    }

    void setEstadoAtaque()
    {
        estado = State.ataque;

        materialEnemigo.color = Color.yellow;
    }

    public void setEstadoPatrulla()
    {
        estado = State.patrulla;

        materialEnemigo.color = Color.red;
    }

    void ChangeDirection()
    {
        timerForDirection = 0;

        endAttack = true;

        direccion = -direccion;
    }

    public void setEstadoVulnerable()
    {
        estado = State.vulnerable;

        canGetDamage = true;

        materialEnemigo.color = Color.white;
    }

    public void setCanGetDamage(bool a)
    {
        canGetDamage = true;
    }

    public bool getCanGetDamage()
    {
        return canGetDamage;
    }

    public void setEstadoCarga()
    {
        estado = State.carga;

        rb.velocity = new Vector2(0,0);

        materialEnemigo.color = Color.blue;

        if (protagonista.transform.position.x > gameObject.transform.position.x)//setea direccion para ataque
            direccion = 1;
        else
            direccion = -1;
    }
   
    public bool getEndAttack()
    {
        return endAttack;
    }

    bool CheckDistance()
    {
        if (startPosition.x + maxDistanceFromStart < transform.position.x)
            return true;
        else if (startPosition.x + minDistanceFromStart > transform.position.x)
            return true;
        else
            return false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Suelo")
        {
            direccion = -direccion;

            if (estado == State.ataque)
                setEstadoVulnerable();

            endAttack = true;
        }

        //nuevo para dañar al personaje
        if (coll.gameObject.tag == "Player")
        {
            if (!protagonista.GetComponent<lifeScript>().getInvulnerable())
            {
                protagonista.GetComponent<lifeScript>().makeDamage(damage);
            }
            //setEstadoVulnerable();
        }         
    }
}
