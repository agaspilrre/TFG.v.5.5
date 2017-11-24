using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThroughtPlatform : MonoBehaviour {

    public BoxCollider2D parentBox { get; set; }

	// Use this for initialization
	void Start ()
    {   
        parentBox = transform.parent.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print("sss");
            if (other.transform.position.y > this.transform.position.y)
                parentBox.isTrigger = false;
            else
                parentBox.isTrigger = true;
        }
    }
}
