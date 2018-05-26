using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE DETECTAR SI EL PLAYER ENTRA EN EL RANGO DE RECONOCMIENTO DEL ENEMIGO Y DE ACTIVAR SU ESTADO DE ATAQUE
/// </summary>
public class TriggerRecon : MonoBehaviour {

    /// <summary>
    /// Referencia al animator del enemigo
    /// </summary>
    Animator animator;

    /// <summary>
    /// Booleano para detectar si el enemigo entra dentro del trigger
    /// </summary>
    public bool isIn;

    /// <summary>
    /// Singleton del script TriggerRecon
    /// </summary>
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

    /// <summary>
    /// Si entra dentro del trigger activamos la animacion de ataque
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isIn = true;
            animator.SetBool("idle", false);
            animator.SetBool("attack", true);
        }   
        
    }

    /// <summary>
    /// Si se mantiene, mantenemos la animacion de atacar
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isIn = true;
            animator.SetBool("idle", false);
            animator.SetBool("attack", true);
        }

    }

    /// <summary>
    /// AL salir del trigger devolvemos al enemigo su estado de idle
    /// </summary>
    /// <param name="collision"></param>
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
