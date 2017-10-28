using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;
   
    public float speed;

    private void Start()
    {
        SetDestination(targets[0]);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        
        //Movimiento de la plataforma
        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

        //Retorno a la plataforma desde donde empieza
        if (Vector3.Distance(transform.position, destination.position) < speed * Time.deltaTime)
        {
            SetDestination(destination == targets[0] ? targets[1] : targets[0]);
        }
    }

    //Cambia el destino
    void SetDestination(Transform dest)
    {
        destination = dest;
    }
}
