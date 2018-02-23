using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour {


    public Text timer;

    public  float seconds;
    public float limitTime;
    public bool stop { get; set; }
    public static TimerManager instance;
    GameManager gm;

	// Use this for initialization
	void Start () {

        instance = this;
        gm = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!stop)
        {
            seconds -= Time.deltaTime;
            timer.text = "CRONO :  " +  (int)(seconds);
            if (seconds<=limitTime)
            {
                //llamar a la funcion de muerte
                fixedVar.totalStarts = 0;
                gm.loadGameOver();
            }
            //if (seconds % 60 >= 10)
            //{
            //    timer.text = "CRONO :  0" + (int)(seconds / 60) + " : " + (int)(seconds % 60);
            //}

            //else
            //{
            //    timer.text = "CRONO :  0" + (int)(seconds / 60) + " :  0" + (int)(seconds % 60);
            //}
            
        }


	}

    public void addTime(float _time)
    {
        seconds += _time;
    }

    
}
