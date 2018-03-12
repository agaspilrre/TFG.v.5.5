using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThree : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;   
    public float speed;    
    bool isHit; 
    public float timeToRespawn = 2;
    bool hasDead;
    public int life;
    Transform playerTr;
    public float speedSlow;
    public float timeSlow;
    int countCollision;
    bool isFinish;

    private void Start()
    {
        SetDestination(targets[0]);
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        isHit = false;
        hasDead = false;
        countCollision = 0;
        isFinish = false;
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
        if (transform.position == targets[targets.Count - 1].position)
            SetDestination(targets[0]);

        else
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (transform.position == targets[i].position)
                    SetDestination(targets[i + 1]);                
            }           
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
            
            //solo se llama una vez por cada colision
            if(countCollision<=0)
                collision.gameObject.GetComponent<Player>().setMakeSlow(true, timeSlow, speedSlow);
            countCollision++;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            countCollision = 0;
        }
    }

    void Respawn()
    {
        float dist = Vector3.Distance(playerTr.position, targets[0].position);

        if(dist > 5)
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
