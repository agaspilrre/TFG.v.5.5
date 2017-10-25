using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoDash : MonoBehaviour {

    public enum State { ataque, dash, patrulla, carga, goingBack };
    int direccion;//1 es derecha -1 izquierda
    State estado;

    public Material materialEnemigo;

    GameObject protagonista;
    [SerializeField]
    GameObject triggerDamage;

    bool endAttack;//if attack has ended
    bool canGetDamage;

    [SerializeField]
    float spaceForAnimation;

    [SerializeField]
    float maxDistanceFromStart;
    [SerializeField]
    float minDistanceFromStart;
    Vector3 startPosition;
    float timerForDirection;//timer so that isnt always changing direction

    [SerializeField]
    int damage = 2;

    [SerializeField]
    float waitTime;
    float timerCarga;

    [SerializeField]


    Rigidbody2D rb;
    float playerTr;

    [SerializeField]
    float velocidadPatrulla;

    [SerializeField]
    float velocidadDash;

    // Use this for initialization
    void Start()
    {
        estado = State.patrulla;

        protagonista = GameObject.Find("Personaje");
        startPosition = transform.position;

        direccion = 1;

        rb = GetComponent<Rigidbody2D>();

        materialEnemigo.color = Color.red;

        timerCarga = waitTime;
        timerForDirection = 0f;

        endAttack = true;
        canGetDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        //update timer

        if (timerForDirection <= 0.5f)
            timerForDirection += Time.deltaTime;

        //compare states
        if (estado == State.patrulla)
        {
            patrullar();

            if (CheckDistance() && timerForDirection > 0.5f) // si se pasa de los maximos
                ChangeDirection();
        }
        else if (estado == State.carga)
        {
            carga();
        }
        else if (estado == State.ataque)
        {
            ataque();
        }
        else if(estado == State.dash)
        {
            dash();
        }
        else
        {
            GoingBack();
        }
    }

    void patrullar()
    {
        rb.velocity = new Vector2(velocidadPatrulla * direccion * Time.deltaTime, rb.velocity.y);
    }

    void GoingBack()
    {

    }

    public void ResetPosition()
    {
        transform.position = startPosition;

        estado = State.patrulla;
    }

    public void SetPatrullaOut()
    {
        estado = State.goingBack;
    }

    void carga()
    {
        timerCarga -= Time.deltaTime;

        if (timerCarga <= 0)
        {
            setEstadoDash();

            endAttack = false;

            timerCarga = waitTime;
        }
    }

    void dash()
    {
        rb.velocity = new Vector2(velocidadDash * direccion * Time.deltaTime, 0);

        if (Mathf.Abs(transform.position.x - playerTr) <= spaceForAnimation)
        {
            setEstadoAtaque();
            rb.velocity = new Vector2(0, 0);
        }
    }

    void ataque()
    {
        if (triggerDamage.activeSelf)
        {
            setEstadoPatrulla();
            triggerDamage.SetActive(false);
        }
        else
            triggerDamage.SetActive(true);
    }

    void setEstadoAtaque()
    {
        estado = State.ataque;

        materialEnemigo.color = Color.yellow;
    }

    public bool getCanGetDamage()
    {
        return canGetDamage;
    }

    public void setEstadoPatrulla()
    {
        estado = State.patrulla;

        materialEnemigo.color = Color.red;
    }

    public void setEstadoDash()
    {
        estado = State.dash;

        playerTr = protagonista.transform.position.x;

        materialEnemigo.color = Color.grey;
    }

    void ChangeDirection()
    {
        timerForDirection = 0;

        endAttack = true;

        direccion = -direccion;
    }

    public int getDamage()
    {
        return damage;
    }

    public void setEstadoCarga()
    {
        estado = State.carga;

        rb.velocity = new Vector2(0, 0);

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

            endAttack = true;
        }

        //si colisiona con el player le hace daño
        if (coll.gameObject.tag == "Player")
        {
            if (!protagonista.GetComponent<lifeScript>().getInvulnerable())
            {
                protagonista.GetComponent<lifeScript>().makeDamage(damage);
            }
        }
    }
}

