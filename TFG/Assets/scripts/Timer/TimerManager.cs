using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour {


    public Text timer;

    private float seconds=0;
    
    public bool stop { get; set; }
    public static TimerManager instance;

	// Use this for initialization
	void Start () {

        instance = this;
	}
	
	// Update is called once per frame
	void Update () {

        if (!stop)
        {
            seconds += Time.deltaTime;
            if (seconds % 60 >= 10)
            {
                timer.text = "CRONO :  0" + (int)(seconds / 60) + " : " + (int)(seconds % 60);
            }

            else
            {
                timer.text = "CRONO :  0" + (int)(seconds / 60) + " :  0" + (int)(seconds % 60);
            }
            
        }


	}

    
}
