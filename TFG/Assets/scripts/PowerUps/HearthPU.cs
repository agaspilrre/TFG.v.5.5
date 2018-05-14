using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE QUE GESTIONA EL COMPORTAMIENTO DEL POWERUP DE VIDA
/// </summary>
public class HearthPU : MonoBehaviour {

    public int curePoints;

    [SerializeField]
    AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Metodo que detecta si el jugador ha entrado dentro del rango donde esta contenido este objeto
    /// cura vida al jugador y destruye este objeto
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.Play();
            collision.GetComponent<lifeScript>().cureLife(curePoints);
            Destroy(this.gameObject);
        }
    }
}
