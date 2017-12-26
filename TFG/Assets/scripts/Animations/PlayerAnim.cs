using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR LAS TRANSICIONES DEL ANIMATOR DEL PLAYER
/// </summary>
public class PlayerAnim : MonoBehaviour {

    Animator animator;
    
	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //metodos encargados de todas las transiciones 

    //Si el player esta parado y corre
    public void IdlToRun()
    {
        animator.SetBool("idlToRun", true);

        
    }

    //Si elplayer esta parado y cambiamos a estado sombra
    public void IdlToIdlS()
    {
        animator.SetBool("idlToIdlS", true);

      
    }

    //si esta corriendo y se detiene
    public void RunToIdl()
    {
        animator.SetBool("runToIdl", true);

       
    }


    //Si esta parado en estado sombra y corre
    public void IdlSToRunS()
    {
        animator.SetBool("idlSToRunS", true);

       
    }

    //si esta parado en estado sombra y cambio a estado electrico
    public void IdlSToIdl()
    {
        animator.SetBool("idlSToIdl", true);

       
    }

    //Si esta corriendo en estado sombra y se detiene
    public void RunSToIdlS()
    {
        animator.SetBool("runSToIdlS", true);

        
    }

    //si esta parado y hace dash
    public void idlToDash()
    {
        animator.SetBool("idlToDash", true);
    }

    //si esta corriendo y hace dash
    public void runToDash()
    {
        animator.SetBool("runToDash", true);
    }

    //si esta quieto y salta
    public void idlToJump()
    {
        animator.SetBool("idlToJump", true);
    }

    //si esta corriendo y salta
    public void runToJump()
    {
        animator.SetBool("runToJump", true);
    }



    //PASAR A FALSO


    //Si el player esta parado y corre
    public void IdlToRunFalse()
    {
        animator.SetBool("idlToRun", false);


    }

    //Si elplayer esta parado y cambiamos a estado sombra
    public void IdlToIdlSFalse()
    {
        animator.SetBool("idlToIdlS", false);


    }

    //si esta corriendo y se detiene
    public void RunToIdlFalse()
    {
        animator.SetBool("runToIdl", false);


    }

   

    //Si esta parado en estado sombra y corre
    public void IdlSToRunSFalse()
    {
        animator.SetBool("idlSToRunS", false);


    }

    //si esta parado en estado sombra y cambio a estado electrico
    public void IdlSToIdlFalse()
    {
        animator.SetBool("idlSToIdl", false);


    }

    //Si esta corriendo en estado sombra y se detiene
    public void RunSToIdlSFalse()
    {
        animator.SetBool("runSToIdlS", false);


    }

    //si hace dash y se tiene que detener
    public void idlToDashFalse()
    {
        animator.SetBool("idlToDash", false);
    }

    //si ha hecho dash y tiene que volver a correr
    public void runToDashFalse()
    {
        animator.SetBool("runToDash", false);
    }

    //si ha saltado y tiene que volver a estar quieto
    public void idlToJumpFalse()
    {
        animator.SetBool("idlToJump", false);
    }

    //si ha saltado y tiene que volver a correr
    public void runToJumpFalse()
    {
        animator.SetBool("runToJump", false);
    }
}
