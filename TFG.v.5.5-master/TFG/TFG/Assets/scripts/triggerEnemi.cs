﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerEnemi : MonoBehaviour {

    public enemigo enemi;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name=="Personaje")
        {
            enemi.setEstadoAtaque();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Personaje")
        {
            enemi.setEstadoPatrulla();
        }
    }
}
