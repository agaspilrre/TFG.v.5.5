using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemiDash : MonoBehaviour {

    public enemigoDash enemi;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Personaje" && enemi.GetState() == "patrulla")
        {
            enemi.setEstadoCarga();
        }
    }
}
