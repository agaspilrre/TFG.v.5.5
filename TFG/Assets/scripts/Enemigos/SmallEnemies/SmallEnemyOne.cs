using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyOne : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;

    public float speed;
    public int Damage;
    private bool attack;

    public float timeAttack;
    private float timer;
    private int count;

    


    

    private void Start()
    {
        SetDestination(targets[1]);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeAttack)
        {
            float step = speed * Time.deltaTime;
            
            //Movimiento de la plataforma
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

            //Retorno a la plataforma desde donde empieza
            if (Vector3.Distance(transform.position, destination.position) < speed * Time.deltaTime)
            {
                SetDestination(destination == targets[0] ? targets[1] : targets[0]);
                

                if ( destination==targets[1])
                {
                    timer = 0;
                    //SetDestination(targets[1]);
                }
            }
        }
        
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
