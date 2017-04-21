using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    SpriteRenderer sr;
    public Sprite stoneOn;
    public int id;
    public Sprite stoneOff;

	// Use this for initialization
	void Start () {


        sr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            sr.sprite = stoneOn;
            //sr.color = Color.blue;
            //comunicar la posicion del personaje para que se quede guardada
            PlayerPrefs.SetInt("CheckPoint",id);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            sr.sprite = stoneOff;
            //sr.color = Color.red;
        }
    }
}
