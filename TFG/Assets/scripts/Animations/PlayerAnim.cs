using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR LAS TRANSICIONES DEL ANIMATOR DEL PLAYER
/// </summary>
public class PlayerAnim : MonoBehaviour {

    Animator animator;
    float initialSpeedAnimator;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        initialSpeedAnimator = animator.speed;
    }
	
	
    public void setAnimatorSpeed(float _speed)
    {
        animator.speed = _speed;
    }

    //metodos encargados de todas las transiciones 

    //Si el player esta parado y corre
    public void IdlToRun()
    {
        animator.SetBool("idlToRun", true);

        
    }


   
   

  

    //si esta quieto y salta
    public void idlToJump()
    {
        setFalseAllAnimations();
        animator.SetBool("idlToJump", true);
        
    }

    //transicion de salto a idl
    public void JumpToIdl()
    {
        setFalseAllAnimations();
        animator.SetBool("jumpToIdl", true);
    }

    //si esta corriendo y salta
    public void runToJump()
    {
        setFalseAllAnimations();
        animator.SetBool("runToJump", true);
    }

    //transicion de salto a correr
    public void jumpToRun()
    {
        setFalseAllAnimations();
        animator.SetBool("jumpToRun", true);
    }

    //DASH
    //si esta parado y hace dash
    public void idlToDash()
    {
        setFalseAllAnimations();
        animator.SetBool("idlToDash", true);
    }

    public void DashToIdl()
    {
        setFalseAllAnimations();
        animator.SetBool("dashToIdl", true);
    }

    public void runToDash()
    {
        setFalseAllAnimations();
        animator.SetBool("runToDash", true);
    }

    public void dashToRun()
    {
        setFalseAllAnimations();
        animator.SetBool("dashToRun", true);
    }


    //PASAR A FALSO


    public void RunToIdl()
    {
        animator.SetBool("idlToRun", false);


    }

    //pone todas las variables del animator a false para que no haya transiciones no deseadas
    public void  setFalseAllAnimations()
    {
        animator.SetBool("idlToDash", false);
        animator.SetBool("dashToIdl", false);
        animator.SetBool("idlToJump", false);
        animator.SetBool("jumpToIdl", false);
        animator.SetBool("runToJump", false);
        animator.SetBool("jumpToRun", false);
        animator.SetBool("runToDash", false);
        animator.SetBool("dashToRun", false);

    }

    



    




}
