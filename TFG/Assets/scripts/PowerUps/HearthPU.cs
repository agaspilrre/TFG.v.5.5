using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearthPU : MonoBehaviour {

    public int curePoints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.GetComponent<lifeScript>().cureLife(curePoints);
            Destroy(this.gameObject);
        }
    }
}
