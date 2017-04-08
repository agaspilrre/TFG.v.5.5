using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoDashDamage : MonoBehaviour {

    GameObject player;
    public enemigoDash enemi;

    void Start()
    {
        player = GameObject.Find("Personaje");
    }

        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Personaje")
        {
            player.GetComponent<lifeScript>().makeDamage(enemi.getDamage());
        }
    }
}
