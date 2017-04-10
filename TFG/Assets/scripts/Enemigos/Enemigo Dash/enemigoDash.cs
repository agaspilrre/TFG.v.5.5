using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoDash : MonoBehaviour {

    public enum State { ataque, dash, patrulla, carga };
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
    int damage = 2;

    [SerializeField]
    float waitTime;
    float timerCarga;

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

        direccion = 1;

        rb = GetComponent<Rigidbody2D>();

        materialEnemigo.color = Color.red;

        timerCarga = waitTime;

        endAttack = true;
        canGetDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (estado == State.patrulla)
        {
            patrullar();
        }
        else if (estado == State.carga)
        {
            carga();
        }
        else if (estado == State.ataque)
        {
            ataque();
        }
        else
        {
            dash();
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

