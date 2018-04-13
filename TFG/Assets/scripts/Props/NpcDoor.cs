using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	void Update () {
		

        if(isOpen)
        {
            scale -= 0.1f;
            transform.localScale=new Vector2(transform.localScale.x,scale);
            if (scale < 0)
                Destroy(this.gameObject);
        }
	}


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

   
}
