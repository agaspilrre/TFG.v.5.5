using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CLASE ENCARGADA DE ASIGNAR AL ENEMIGO DASH EL ESTADO DE CARGA
/// </summary>
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
