using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR UNA CUENTA ATRAS Y DE MOSTRARLA POR LA INTERFAZ DE USUARIO
/// </summary>
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
            timer.text = "TIME: " +  (int)(seconds);
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

    /// <summary>
    /// Metodo que añade el tiempo pasado como parametro a la cuenta atras
    /// </summary>
    /// <param name="_time"></param>
    public void addTime(float _time)
    {
        seconds += _time;
    }

    
}
