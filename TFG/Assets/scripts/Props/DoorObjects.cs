using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARDA DE GESTIONAR EL COMPORTAMIENTO DE LOS INTERRUPTORES DE PUERTAS
/// </summary>
public class DoorObjects : MonoBehaviour {


    public bool activateObject;
    SpriteRenderer sr;
    Animator anim;

	// Use this for initialization
	void Start () {

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Metodo que devuelve el el valor del bool que indica si el interruptor ha sido activado
    /// </summary>
    /// <returns></returns>
    public bool getActivationObject()
    {
        return activateObject;
    }

    /// <summary>
    /// Indica que el interruptor ha sido activado y cambia su coloar a verde
    /// </summary>
    /// <param name="collision"></param>
    public void OnParticleCollision(GameObject collision)
    {

        activateObject = true;
        anim.SetBool("ActivarPuerta", true);
        //sr.color = Color.green;

    }
}
