using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR UNA CUENTA ATRAS Y DE MOSTRARLA POR LA INTERFAZ DE USUARIO
/// </summary>
public class TimerManager : MonoBehaviour {

    /// <summary>
    /// Texto del timer
    /// </summary>
    public Text timer;

    /// <summary>
    /// Segundos del timer
    /// </summary>
    public  float seconds;

    /// <summary>
    /// Tiempo limite
    /// </summary>
    public float limitTime;

    /// <summary>
    /// Propiedad para parar el timer
    /// </summary>
    public bool stop { get; set; }

    /// <summary>
    /// Referencia al game manager
    /// </summary>
    GameManager gm;

    /// <summary>
    /// Singleton del timeManager
    /// </summary>
    public static TimerManager instance;   

	// Use this for initialization
	void Start () {

        instance = this;
        gm = GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

        //Se va descontando tiempo hasta llegar al limite donde activamos el gameover
        if (!stop)
        {
            seconds -= Time.deltaTime;
            timer.text = "TIME: " +  (int)(seconds);
            if (seconds<=limitTime)
            {
                //llamar a la funcion de muerte
                //fixedVar.totalStarts = 0;
                gm.loadGameOver();
            }           
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

    /// <summary>
    /// Metodo para obtener los segundos que quedan
    /// </summary>
    /// <returns></returns>
    public float getTime()
    {
        return seconds;
    }

    /// <summary>
    /// Metodo para setear segundos al timer
    /// </summary>
    /// <param name="_value"></param>
    public void setTime(float _value)
    {
        seconds = _value;
    }

    
}
