using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE QUE GESTIONA EL COMPORTAMIENTO DEL POWERUP DE VIDA
/// </summary>
public class HearthPU : MonoBehaviour {

    /// <summary>
    /// Cantidad de vida que recupera el power up
    /// </summary>
    public int curePoints;

    /// <summary>
    /// Referencia al audio source del power up
    /// </summary>
    [SerializeField]
    AudioSource source;

    /// <summary>
    /// Referencia al clip que suena cuando coges el power up
    /// </summary>
    [SerializeField]
    AudioClip clip;

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
            source.clip = clip;
            source.Play();
            collision.GetComponent<lifeScript>().cureLife(curePoints);
            Destroy(this.gameObject);
        }
    }


}
