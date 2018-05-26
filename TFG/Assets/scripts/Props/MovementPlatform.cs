using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DEL MOVIMIENTO DE PLATAFORMAS ENTRE DIFERENTES PUNTOS
/// </summary>
public class MovementPlatform : MonoBehaviour {

    /// <summary>
    /// Lista de targets points a los que tiene que ir la plataforma
    /// </summary>
    public List<Transform> targets;

    /// <summary>
    /// Transform del siguiente destino al que tiene que ir la plataforma
    /// </summary>
    Transform destination;

    /// <summary>
    /// Timer para controlar el tiempo de espera de la plataforma
    /// </summary>
    float timer = 0;

    /// <summary>
    /// Velocidad de la plataforma
    /// </summary>
    public float speed;

    /// <summary>
    /// Booleano para controlar el movimiento 
    /// </summary>
    bool enableMovement;

    /// <summary>
    /// Tiempo de espera
    /// </summary>
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

    /// <summary>
    /// Metodo para cambiar el destino de la plataforma
    /// </summary>
    /// <param name="dest"></param>
    void SetDestination(Transform dest)
    {
        destination = dest;
    }
}
