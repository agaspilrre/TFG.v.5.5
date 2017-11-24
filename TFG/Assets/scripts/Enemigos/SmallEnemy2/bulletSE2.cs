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

	// Use this for initialization
	void Awake () {

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {


        rb.velocity = new Vector2(0, -1 * speed);

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

        



    }

}
