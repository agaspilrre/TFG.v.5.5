using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour {

    public enum Direction { ataque, patrulla };

    public int direccion;//1 es derecha -1 izquierda

    Direction estado;

    public Material materialEnemigo;

    GameObject protagonista;

    Rigidbody2D rb;

    public int prueba = 0;

    public float velocidad;

    // Use this for initialization
    void Start () {

        estado = Direction.patrulla;

        protagonista = GameObject.Find("Personaje");

        direccion = 1;

        rb = GetComponent<Rigidbody2D>();

        materialEnemigo.color = Color.red;

    }
	
	// Update is called once per frame
	void Update () {

        if(estado == Direction.patrulla)
        {
            patrullar();
        }
        else
        {
            ataque();
        }	
	}

    void patrullar()
    {
        rb.velocity = new Vector2(velocidad * direccion * Time.deltaTime, 0);
    }

    void ataque()
    {
        if(protagonista.transform.position.x > gameObject.transform.position.x)
        {
            direccion = 1;

            rb.velocity = new Vector2(velocidad* direccion * Time.deltaTime, 0);
        }
        else
        {
            direccion = -1;

            rb.velocity = new Vector2(velocidad * direccion * Time.deltaTime, 0);
        }
    }

    public void setEstadoAtaque()
    {
        estado = Direction.ataque;

        materialEnemigo.color = Color.yellow;
    }

    public void setEstadoPatrulla()
    {
        estado = Direction.patrulla;

        materialEnemigo.color = Color.red;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Pared")
        {
            prueba++;
            direccion = -direccion;
        }
           
    }
}
