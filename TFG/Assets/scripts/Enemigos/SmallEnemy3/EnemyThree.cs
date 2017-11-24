using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;   
    public float speed;
    Vector3 initialPosition;
    bool isHit; 
    public float timeToRespawn = 2;
    bool hasDead;


    private void Start()
    {
        SetDestination(targets[0]);
        initialPosition = transform.position;
        isHit = false;
        hasDead = false;
    }

    void Update()
    {
        if (!isHit)
        {
            float step = speed * Time.deltaTime;

            //Movimiento del enemigo
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
            moveToPoints();
        }       
            
    }

    //scriptPlayer speedLow HACER EN EL SCRIPT DEL PLAYER

    void moveToPoints()
    { 
        if (transform.position == targets[0].position)
            SetDestination(targets[1]);

        if (transform.position == targets[1].position)
            SetDestination(targets[2]);

        if (transform.position == targets[2].position)
            SetDestination(targets[3]);

        if (transform.position == targets[3].position)
            SetDestination(targets[0]);

        CancelInvoke();
    }

    private void OnEnable()
    {
        SetDestination(targets[0]);
    }

    //Cambia el destino
    void SetDestination(Transform dest)
    {
        destination = dest;        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isHit = true;
            gameObject.SetActive(false);
            Invoke("Respawn", timeToRespawn);
        }
    }

    void Respawn()
    {
        gameObject.transform.position = initialPosition;
        gameObject.SetActive(true);
        isHit = false;       
    }
}
