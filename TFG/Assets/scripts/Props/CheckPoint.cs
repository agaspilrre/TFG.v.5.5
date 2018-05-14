using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    SpriteRenderer sr;
    Animator anim;
    TimerManager tmanager;
    public int timeValue;
    //public Sprite stoneOn;
    public int id;

    public byte pantallaID;
    //public Sprite stoneOff;

	// Use this for initialization
	void Start () {


        //sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        tmanager = GameObject.Find("GameManager").GetComponent<TimerManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //sr.sprite = stoneOn;
            //sr.color = Color.blue;
            anim.SetBool("encender", true);
            //comunicar la posicion del personaje para que se quede guardada
            tmanager.addTime(timeValue);
            PlayerPrefs.SetFloat("timeLoad", tmanager.getTime());
            PlayerPrefs.SetInt("CheckPoint",id);

        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    if (other.gameObject.tag == "Player")
    //    {
    //        sr.sprite = stoneOff;
    //        //sr.color = Color.red;
    //    }
    //}
}
