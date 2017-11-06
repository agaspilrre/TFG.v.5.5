using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoDash : MonoBehaviour {

    public enum State { ataque, dash, patrulla, carga, knockout, goingBack };
    int direccion;//1 es derecha -1 izquierda
    State estado;

    public Material materialEnemigo;

    Transform protagonista;
    [SerializeField]
    GameObject triggerDamage;

    bool canGetDamage;

    [SerializeField]
    float spaceForAnimation;

    [SerializeField][Range(0,100)]
    float maxDistanceFromStart;
    [SerializeField][Range(-100, 0)]
    float minDistanceFromStart;
    Vector3 startPosition;
    float timerForDirection;//timer so that isnt always changing direction

    [SerializeField]
    int damage = 2;

    [SerializeField]
    float chargeTime;
    float timerCarga;

    [SerializeField]
    float knockoutTime;
    float knockoutSaveTime;

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

        protagonista = GameObject.Find("Personaje").GetComponent<Transform>();
        startPosition = transform.position;

        direccion = 1;

        rb = GetComponent<Rigidbody2D>();

        materialEnemigo.color = Color.red;

        timerCarga = chargeTime;
        knockoutSaveTime = knockoutTime;

        timerForDirection = 0f;

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
        else if(estado == State.goingBack)
        {
            GoingBack();
        }
        else if (estado == State.knockout)
        {
            knockout();
        }
    }

    void patrullar()
    {
        rb.velocity = new Vector2(velocidadPatrulla * direccion * Time.deltaTime, rb.velocity.y);
    }

    void GoingBack()
    {
        transform.position = startPosition;

        estado = State.patrulla;

        direccion = 1;
    }

    public void ResetPosition()
    {
        transform.position = startPosition;

        estado = State.patrulla;
    }

    void carga()
    {
        timerCarga -= Time.deltaTime;

        if (timerCarga <= 0)
        {
            setEstadoDash();

            timerCarga = chargeTime;
        }
    }

    void knockout()
    {
        knockoutTime -= Time.deltaTime;

        if (knockoutTime <= 0)
        {
            SetStateGoingBack();

            knockoutTime = knockoutSaveTime;
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
            SetStateKnockout();
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

    void SetStateGoingBack()
    {
        estado = State.goingBack;
    }

    void SetStateKnockout()
    {
        estado = State.knockout;

        materialEnemigo.color = Color.black;
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

        playerTr = protagonista.position.x;

        materialEnemigo.color = Color.grey;
    }

    void ChangeDirection()
    {
        timerForDirection = 0;

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

        if (protagonista.position.x > gameObject.transform.position.x)//setea direccion para ataque
            direccion = 1;
        else
            direccion = -1;
    }

    
    public string GetState()
    {
        return estado.ToString();
    }

    bool CheckDistance()
    {
        if (startPosition.x + maxDistanceFromStart <= transform.position.x)
            return true;
        else if (startPosition.x + minDistanceFromStart >= transform.position.x)
            return true;
        else
            return false;
    }
}

