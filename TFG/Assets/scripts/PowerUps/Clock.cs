using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO DEL POWER UP RELOJ
/// actualmente descartada por diseño
/// </summary>
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

    /// <summary>
    /// Detecta si ha entrado el player en su area añade tiempo al cronocmetro y destruye este objetos
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            tmanager.addTime(timeValue);
            Destroy(this.gameObject);
        }
    }
}
