using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsMovement : MonoBehaviour {

    [SerializeField] List<Vector3> targets;

    Vector3 destination;   
    public float speed;

    Transform myTransform;

    private void Start()
    {
        myTransform = transform;
        SetDestination(targets[0]);      
    }

    void Update()
    {      
        float step = speed * Time.deltaTime;

        myTransform.position = Vector3.MoveTowards(myTransform.position, destination, step);

        MoveToPoints();           
    }

    void MoveToPoints()
    {   
        for(int i = 0; i < targets.Count; i++)
        {
            if(myTransform.position == targets[i])
            {
                if(i == targets.Count - 1)
                {
                    SetDestination(targets[0]);
                }
                else
                {
                    SetDestination(targets[i + 1]);
                }
            }
        }
    }
    
    //Cambia el destino
    void SetDestination(Vector3 dest)
    {
        destination = dest;        
    }  
    
}
