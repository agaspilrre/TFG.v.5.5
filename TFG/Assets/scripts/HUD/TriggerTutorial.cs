using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour {

    [SerializeField]
    GameObject image;

    bool visible;
	// Use this for initialization
	void Start () {

        visible = false;
        image.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!visible)
            {
                visible = true;
                image.SetActive(true);
            }           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            image.SetActive(false);
        }
    }
}
