using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARDA DE GESTIONAR EL COMPORTAMIENTO DE LOS INTERRUPTORES DE PUERTAS
/// </summary>
public class DoorObjects : MonoBehaviour {

    /// <summary>
    /// bool que indica si el interruptor ha sido activado
    /// </summary>
    public bool activateObject;

    /// <summary>
    /// variable que guarda el sprite render del objeto interruptor
    /// usada en version anterior cuando el objeto no tenia grafica
    /// </summary>
    SpriteRenderer sr;

    /// <summary>
    /// variable que guarda el animator de este objeto
    /// </summary>
    Animator anim;

	// Use this for initialization
    /// <summary>
    /// Obtiene los componentes SpriteRendere y Animator
    /// </summary>
	void Start () {

        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

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
    /// En la nueva version activa la animacion del objeto interruptor
    /// </summary>
    /// <param name="collision"></param>
    public void OnParticleCollision(GameObject collision)
    {

        activateObject = true;
        anim.SetBool("ActivarPuerta", true);
        //sr.color = Color.green;

    }
}
