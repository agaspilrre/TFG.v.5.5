using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSE2 : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public int damage;
    public bool makeDamage;
    public bool makeSlow;
    public float speedSlow;
    public float timeSlow;
    public bool UpShoot;
    public bool DownShoot;
    public bool RightShoot;
    public bool LeftShoot;

    // Use this for initialization
    void Awake () {

        rb = GetComponent<Rigidbody2D>();
       
        
    }
	
	// Update is called once per frame
	void Update () {

        if (UpShoot)
        {
            rb.velocity = new Vector2(0, 1 * speed);
        }

        else if (DownShoot)
        {
            rb.velocity = new Vector2(0, -1 * speed);
        }

        else if (RightShoot)
        {
            rb.velocity = new Vector2(1 * speed, 0);
        }

        else if (LeftShoot)
        {
            rb.velocity = new Vector2(-1 * speed, 0);
        }
        

    }

    public void setUpShoot(bool _value)
    {
        UpShoot = _value;

        
        DownShoot = false;
        RightShoot = false;
        LeftShoot = false;



    }

    public void setDownShoot(bool _value)
    {
        DownShoot = _value;
        UpShoot = false;
       
        RightShoot = false;
        LeftShoot = false;
    }

    public void setRightShoot(bool _value)
    {
        RightShoot = _value;
        UpShoot = false;
        DownShoot = false;
        
        LeftShoot = false;
    }

    public void setLeftShoot(bool _value)
    {
        LeftShoot = _value;
        UpShoot = false;
        DownShoot = false;
        RightShoot = false;
        
    }


    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    public void setDamage(int _damage)
    {
        damage = _damage;
    }

    public void setMakeDamage(bool _makeDamage)
    {
        makeDamage = _makeDamage;
    }
    public void setMakeSlow(bool _makeSlow)
    {
        makeSlow = _makeSlow;
    }
    public void setSlowSpeed(float _slowSpeed)
    {
        speedSlow = _slowSpeed;
    }

    public void setSlowTimer(float _timer)
    {
        timeSlow = _timer;
    }

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        
            if (coll.gameObject.tag == "Player")
            {
                //call die function
                if(makeDamage)
                    coll.gameObject.GetComponent<lifeScript>().makeDamage(damage);

                //hacer realentizacion tb
                if (makeSlow)
                    coll.gameObject.GetComponent<Player>().setMakeSlow(true, timeSlow, speedSlow);
            }

            Destroy(gameObject);

        



    }*/



    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //call die function
            if (makeDamage)
                coll.gameObject.GetComponent<lifeScript>().makeDamage(damage);

            //hacer realentizacion tb
            if (makeSlow)
                coll.gameObject.GetComponent<Player>().setMakeSlow(true, timeSlow, speedSlow);
        }

        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Pared" || coll.gameObject.tag == "Suelo" || coll.gameObject.tag == "techo" || coll.gameObject.tag == "Platform")
            Destroy(gameObject);
    }

}
