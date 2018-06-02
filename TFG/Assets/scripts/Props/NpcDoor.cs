using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE QUE COMPRUEBA SI TODOS LOS INTERRUPTORES QUE PERTENECEN HA UNA PUERTA HAN SIDO PULSADOS Y DE GESTIONAR SU COMPORTAMIENTO
/// </summary>
public class NpcDoor : MonoBehaviour {

    /// <summary>
    /// Lista que guarda los interruptores que contiene una puerta
    /// </summary>
    public List<GameObject> activatorObjects = new List<GameObject>();
    
    /// <summary>
    /// bool que indica si la puerta esta en estado abierta
    /// </summary>
    bool isOpen;

    /// <summary>
    /// variable que cuenta los objetos interruptores que han sido activados
    /// </summary>
    int count;

    /// <summary>
    /// Guarda la escala en Y de este objeto
    /// </summary>
    float scale;
	// Use this for initialization

    /// <summary>
    /// Obtiene la escala en Y del objeto puerta
    /// </summary>
	void Start () {

        scale = transform.localScale.y;
	}

    // Update is called once per frame
    /// <summary>
    /// Si la puerta ha sido abierta reduce la escala en y hasta el minimo y detruye los objetos puerta he interruptores
    /// </summary>
    void Update () {
		

        if(isOpen)
        {
            scale -= 0.1f;
            transform.localScale=new Vector2(transform.localScale.x,scale);
            if (scale < 0)
                Destroy(this.gameObject);
        }
	}

    /// <summary>
    /// Detecta si el player entra en el area de la puerta y comprueba si todos sus interruptores han sido abiertos
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        count = 0;
        if(collision.gameObject.tag=="Player")
        {
            for(int i=0;i<activatorObjects.Count;i++)
            {
                if (activatorObjects[i].GetComponent<DoorObjects>().getActivationObject())
                    count++;
                
            }

            if (count == activatorObjects.Count)
                isOpen = true;
            
        }
    }


    /// <summary>
    /// Detecta si el player esta dentro del area de la puerta y comprueba si sus interruptores han sido abiertos
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerStay2D(Collider2D collision)
    {

        count = 0;
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < activatorObjects.Count; i++)
            {
                if (activatorObjects[i].GetComponent<DoorObjects>().getActivationObject())
                    count++;

            }

            if (count == activatorObjects.Count)
                isOpen = true;

        }
    }

}
