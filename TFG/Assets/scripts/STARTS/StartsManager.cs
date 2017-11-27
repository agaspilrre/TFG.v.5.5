using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartsManager : MonoBehaviour {

    public int numberStartsLevel;
    public Text startsText;
    //public int starts;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        startsText.text = "STARTS :  " + fixedVar.totalStarts + "  /  " + numberStartsLevel;

    }

    /*
    public void incrementNumberStarts()
    {
        starts++;
    }*/
}
