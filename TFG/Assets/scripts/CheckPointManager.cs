using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

    // Use this for initialization
    public Transform[] CheckPoints;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Transform GetCheckPoint(int CheckPoint)
    {
        return CheckPoints[CheckPoint];
    }
}
