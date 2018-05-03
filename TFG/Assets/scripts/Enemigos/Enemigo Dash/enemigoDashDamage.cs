using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase encargada de detectar si el enemigo a envestido al jugador y aplicarle el daño correspondiente
/// Clase actualmente no utilizada por descarte de diseño
/// </summary>
public class enemigoDashDamage : MonoBehaviour {

    GameObject player;
    enemigoDash enemi;

    void Start()
    {
        player = GameObject.Find("Personaje");

        enemi = gameObject.GetComponentInParent<enemigoDash>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Personaje")
        {
            player.GetComponent<lifeScript>().makeDamage(enemi.getDamage());
        }
    }
}
