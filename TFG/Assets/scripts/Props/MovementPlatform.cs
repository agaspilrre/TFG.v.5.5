using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour {

    public List<Transform> targets;

    Transform destination;
    float timer = 0;
    public float speed;
    bool enableMovement;
    public float timeWait;

    private void Start()
    {
        SetDestination(targets[0]);
        enableMovement = true;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        
      
        if(enableMovement)
        {
            //Movimiento de la plataforma
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

           
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timeWait)
            {
                enableMovement = true;
                timer = 0;
            }
        }
       

        //Retorno a la plataforma desde donde empieza
        if (Vector3.Distance(transform.position, destination.position) < speed * Time.deltaTime)
        {
            SetDestination(destination == targets[0] ? targets[1] : targets[0]);
           
            enableMovement = false;
            
        }
    }

    //Cambia el destino
    void SetDestination(Transform dest)
    {
        destination = dest;
    }
}
