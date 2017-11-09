using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour {

    public GameObject instructions;
    public string ruta;
    GameObject player;
    SpriteRenderer spriteRenderer;

    LoadXml loader;
    
	// Use this for initialization
	void Start () {

        instructions.SetActive(false);
       
        loader = GameObject.Find("Loader").GetComponent<LoadXml>();
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.transform.position.x < transform.position.x)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
	}


     void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            //mostrar instrucciones y activar boll para que se pueda ejercer conversacion
            instructions.SetActive(true);
            //enviar el path para que cargue otro xml
            loader.cambiarXml(ruta);
            loader.OnStart();
            loader.setAllowTalk(true);
        }
    }

    
     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //mostrar instrucciones y activar boll para que se pueda ejercer conversacion
            loader.ExitConversation();
            instructions.SetActive(false);
            
            
            loader.setAllowTalk(false);
        }
    }
    
}
