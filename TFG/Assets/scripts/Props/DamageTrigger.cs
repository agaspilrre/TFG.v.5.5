using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour {

    // Use this for initialization
    public int Damage;
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //si este trigger detecta al personaje le hace daño
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<lifeScript>().makeDamage(Damage);

        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<lifeScript>().makeDamage(Damage);

        }
    }
}
