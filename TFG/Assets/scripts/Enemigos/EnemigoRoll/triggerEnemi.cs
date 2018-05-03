using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CLASE ENCARGADA DE GESTIONAR SI ENTRA EL PERSONAJE EN EL TRIGGER DEL ENEMIGO RODANTE
/// clase descartada.
/// </summary>
public class triggerEnemi : MonoBehaviour {

    public enemigo enemi;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Personaje" && enemi.getEndAttack())
        {
            print("damage");
        }
    }

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.name == "Personaje")
    //    {
    //        enemi.setEstadoPatrulla();
    //    }
    //}
}
