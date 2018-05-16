using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE APLICAR DAÑO AL JUGADOR CUANDO ESTE ATRAVIESA UN AREA CONTENIDA POR ESTE TRIGGER
/// </summary>
public class DamageTrigger : MonoBehaviour {

    // Use this for initialization
    public int Damage;
    lifeScript lifeScript;
    
	void Start ()
    {
        lifeScript = GameObject.Find("Personaje").GetComponent<lifeScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
    /// <summary>
    /// Metodo que detecta si el personaje a entrado y se encarga de aplicarle daño
    /// </summary>
    /// <param name="collision"></param>
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        lifeScript.setInvulnerable(false);
    //        collision.GetComponent<lifeScript>().makeDamage(Damage);
    //    }

    //}

    /// <summary>
    /// Metodo que detecta si el personaje permanece dentro del trigger para seguir aplicandole daño
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Damage == 4)
                lifeScript.setInvulnerable(false);

            collision.GetComponent<lifeScript>().makeDamage(Damage);
        }
    }
}
