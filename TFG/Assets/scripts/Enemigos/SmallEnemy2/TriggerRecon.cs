using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE DETECTAR SI EL PLAYER ENTRA EN EL RANGO DE RECONOCMIENTO DEL ENEMIGO Y DE ACTIVAR SU ESTADO DE ATAQUE
/// </summary>
public class TriggerRecon : MonoBehaviour {

    Animator animator;
    public bool isIn;

    public static TriggerRecon instance;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isIn = true;
            animator.SetBool("idle", false);
            animator.SetBool("attack", true);
        }   
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = true;
            animator.SetBool("idle", false);
            animator.SetBool("attack", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = false;
            animator.SetBool("idle", true);
            animator.SetBool("attack", false);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
