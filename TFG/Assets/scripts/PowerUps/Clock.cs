using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    TimerManager tmanager;
    public float timeValue;
    
	// Use this for initialization
	void Start () {

        tmanager = GameObject.Find("GameManager").GetComponent<TimerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            tmanager.addTime(timeValue);
            Destroy(this.gameObject);
        }
    }
}
