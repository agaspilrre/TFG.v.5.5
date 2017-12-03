using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferentEnemyThree : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;
    public float speed;
   
    bool isHit;
    public float timeToRespawn = 2;
    bool hasDead;
    public int life;
    bool inverseMode = false;
    Transform playerTr;

    public float speedSlow;
    public float timeSlow;

    private void Start()
    {
        SetDestination(targets[0]);        
        isHit = false;
        hasDead = false;
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
            inverseMode = true;

        if (inverseMode)
        {
            if (transform.position == targets[0].position)
                inverseMode = false;

            if (transform.position == targets[1].position)
                SetDestination(targets[0]);

            if (transform.position == targets[2].position)
                SetDestination(targets[1]);

            if (transform.position == targets[3].position)
                SetDestination(targets[2]);
        }

        CancelInvoke();
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
            collision.gameObject.GetComponent<Player>().setMakeSlow(true, timeSlow, speedSlow);
        }
    }

    void Respawn()
    {
        float dist = Vector3.Distance(playerTr.position, targets[0].position);

        if (dist > 5)
            gameObject.transform.position = targets[0].position;
        else
            gameObject.transform.position = targets[1].position;

        gameObject.SetActive(true);
        isHit = false;
    }

    public void EnemyMakeDamage(int _damage)
    {
        life -= _damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
