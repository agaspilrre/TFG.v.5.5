using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO DE SMALLENEMY. ENEMIGO QUE SALTA
/// actualmente descartado por diseño.
/// </summary>
public class SmallEnemyOne : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;

   

    public int Damage;
    private bool attack;

    public float timeAttack;
    private float timer;
    private int count;

    bool startCountTime;
    public float TimeToStart;
    Rigidbody2D rb;
    //variables para ajustar el salto del enemigo
    public float durationJump;
    public float distanceJump;
    float speedJump;

    private void Start()
    {
        SetDestination(targets[1]);
        StartCoroutine(StartCount());
        rb = GetComponent<Rigidbody2D>();
        speedJump = distanceJump / durationJump;
    }

    IEnumerator StartCount()
    {

        yield return new WaitForSeconds(TimeToStart);
        startCountTime = true;

    }

    void Update()
    {
        if (startCountTime)
        {
            if (rb.velocity.y == 0)
                timer += Time.deltaTime;

            if (timer >= timeAttack)
            {
                /*
                float step = speed * Time.deltaTime;

                //Movimiento de la plataforma
                transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

                //Retorno a la plataforma desde donde empieza
                if (Vector3.Distance(transform.position, destination.position) < speed * Time.deltaTime)
                {
                    SetDestination(destination == targets[0] ? targets[1] : targets[0]);


                    if (destination == targets[1])
                    {
                        timer = 0;
                        //SetDestination(targets[1]);
                    }
                }*/


                //rb.AddForce(Vector2.up * jumpPower);
                rb.velocity = new Vector2(0, 1 * speedJump);
                rb.gravityScale = 0;
                Invoke("setGravity", durationJump);
                timer = 0;
                
                
            }
        }
           
        
    }

    void setGravity()
    {
        //freno el salto anulando con una 4 parte de la velocidad que lleva en este momento
        rb.velocity = new Vector2(0, -1 * (rb.velocity.y/4));
        rb.gravityScale = 1;
    }

    //Cambia el destino
    void SetDestination(Transform dest)
    {
        destination = dest;

    }



    void OnCollisionEnter2D(Collision2D coll)
    {
        
            if (coll.gameObject.tag == "Player")
            {
                //call die function

                coll.gameObject.GetComponent<lifeScript>().makeDamage(Damage);
            }

            

    }

   



}
