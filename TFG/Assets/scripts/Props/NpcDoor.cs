using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE QUE COMPRUEBA SI TODOS LOS INTERRUPTORES QUE PERTENECEN HA UNA PUERTA HAN SIDO PULSADOS Y DE GESTIONAR SU COMPORTAMIENTO
/// </summary>
public class NpcDoor : MonoBehaviour {

    public List<GameObject> activatorObjects = new List<GameObject>();
    //public List<bool>
    bool isOpen;
    int count;
    float scale;
	// Use this for initialization
	void Start () {

        scale = transform.localScale.y;
	}
	
	// Update is called once per frame
    //Si la puerta ha sido abierta reduce la escala en y hasta el minimo y detruye los objetos puerta he interruptores
	void Update () {
		

        if(isOpen)
        {
            this.GetComponent<Animator>().SetBool("Disappear", true);
            /*scale -= 0.1f;
            transform.localScale=new Vector2(transform.localScale.x,scale);*/
            Invoke("destroyDoor", 2.01f);
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

    void destroyDoor()
    {
        Destroy(this.gameObject);

    }


}
