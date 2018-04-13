using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObjects : MonoBehaviour {


    public bool activateObject;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {

        sr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getActivationObject()
    {
        return activateObject;
    }

    public void OnParticleCollision(GameObject collision)
    {

        activateObject = true;
        sr.color = Color.green;

    }
}
