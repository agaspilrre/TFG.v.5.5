using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;

    //GameObject player;
    public bool verticalDirection;
    public bool rigthDiagonalDirection;
    public bool leftDiagonalDirection;

    public GameObject enemy;

    

    // Use this for initialization
    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        



    }

    // Update is called once per frame
    void Update()
    {
        //know direction bullet
        //Enemy look up
        if(enemy.transform.rotation.eulerAngles.z>=0 && enemy.transform.rotation.eulerAngles.z < 89)
        {
            //direction bullet
            if (verticalDirection)
                rb.velocity = new Vector2(0, 1 * speed);

            else if (rigthDiagonalDirection)
                rb.velocity = new Vector2(1 * speed, 1 * speed);

            else if (leftDiagonalDirection)
                rb.velocity = new Vector2(-1 * speed, 1 * speed);
        }

        //enemy look left
        else if(enemy.transform.rotation.eulerAngles.z > 89 && enemy.transform.rotation.eulerAngles.z < 170)
        {
            if (verticalDirection)
                rb.velocity = new Vector2(-1 * speed, 0);

            else if (rigthDiagonalDirection)
                rb.velocity = new Vector2(-1 * speed, 1 * speed);

            else if (leftDiagonalDirection)
                rb.velocity = new Vector2(-1 * speed, -1 * speed);
        }

        //enemy look down
        else if (enemy.transform.rotation.eulerAngles.z > 170 && enemy.transform.rotation.eulerAngles.z < 260)
        {
            if (verticalDirection)
                rb.velocity = new Vector2(0, -1 * speed);

            else if (rigthDiagonalDirection)
                rb.velocity = new Vector2(-1 * speed, -1 * speed);

            else if (leftDiagonalDirection)
                rb.velocity = new Vector2(1 * speed, -1 * speed);
        }

        //enemy look rigth
        else if (enemy.transform.rotation.eulerAngles.z > 260 && enemy.transform.rotation.eulerAngles.z < 360)
        {
            if (verticalDirection)
                rb.velocity = new Vector2(1 * speed, 0);

            else if (rigthDiagonalDirection)
                rb.velocity = new Vector2(1 * speed, -1 * speed);

            else if (leftDiagonalDirection)
                rb.velocity = new Vector2(1 * speed, 1 * speed);
        }



    }


    public void setEnemy(GameObject _enemy)
    {
        enemy = _enemy;
    }
    
    public void setSpeedBullet(float _speed)
    {
        speed = _speed;
    }

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        if ( coll.gameObject.tag != "Enemy")
        {
            if (coll.gameObject.tag == "Player")
            {
                //call die function
               
                coll.gameObject.GetComponent<lifeScript>().makeDamage(1);
            }

            Destroy(gameObject);

        }
         


    }*/

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag != "Enemy")
        {
            if (coll.gameObject.tag == "Player")
            {
                //call die function

                coll.gameObject.GetComponent<lifeScript>().makeDamage(1);
            }

            if(coll.gameObject.tag=="Player" || coll.gameObject.tag == "Pared" || coll.gameObject.tag == "Suelo" || coll.gameObject.tag == "techo" || coll.gameObject.tag == "Platform")
                Destroy(gameObject);

        }
    }
}
