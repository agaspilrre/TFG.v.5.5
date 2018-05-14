using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR LAS TRANSICIONES DEL ANIMATOR DEL PLAYER
/// </summary>
public class PlayerAnim : MonoBehaviour {

    Animator animator;
    float initialSpeedAnimator;

    [SerializeField]
    Animator fronArm;
    [SerializeField]
    Animator backArm;

	// Use this for initialization
	void Start () {

        animator = GetComponent<Animator>();
        initialSpeedAnimator = animator.speed;
    }
	
	public Animator GetAnimator()
    {
        return animator;
    }

    /// <summary>
    /// Funcion que establece la velocidad del animator
    /// </summary>
    /// <param name="_speed"></param>
    public void setAnimatorSpeed(float _speed)
    {
        animator.speed = _speed;
    }

    //metodos encargados de todas las transiciones 

    //Si el player esta parado y corre
    /// <summary>
    /// Metodo que activa la transicion de la animacion de idl hacia la de correr.
    /// </summary>
    public void IdlToRun()
    {
        animator.SetBool("idlToRun", true);        
    } 

    //si esta quieto y salta
    /// <summary>
    /// Metodo que activa la transicion de la animacion de idl a salto.
    /// </summary>
    public void idlToJump()
    {
        setFalseAllAnimations();
        animator.SetBool("idlToJump", true);
        
    }

    //transicion de salto a idl
    /// <summary>
    /// Metodo que activa la transicion de de salto a idl
    /// </summary>
    public void JumpToIdl()
    {
        setFalseAllAnimations();
        animator.SetBool("jumpToIdl", true);
    }

    //si esta corriendo y salta
    /// <summary>
    /// Metodo que activa la transicion de correr a saltar
    /// </summary>
    public void runToJump()
    {
        setFalseAllAnimations();
        animator.SetBool("runToJump", true);
    }

    public void runToJumpFalse()
    {
        animator.SetBool("runToJump", false);
    }

    //transicion de salto a correr
    /// <summary>
    /// Metodo que activa la transicion de salto a correr
    /// </summary>
    public void jumpToRun()
    {
        setFalseAllAnimations();

        animator.SetBool("jumpToRun", true);
    }

    /// <summary>
    /// Metodo que activa la transicion de salto a dash
    /// </summary>
    public void jumpToDash()
    {
        setFalseAllAnimations();
        animator.SetBool("jumpToDash", true);
    }

    //DASH
    //si esta parado y hace dash
    /// <summary>
    /// Metodo que activa la transicion de Idl a dash
    /// </summary>
    public void idlToDash()
    {
        setFalseAllAnimations();
        animator.SetBool("idlToDash", true);
    }

    /// <summary>
    /// Metodo que activa la transicion de dash a idl
    /// </summary>
    public void DashToIdl()
    {
        setFalseAllAnimations();
        animator.SetBool("dashToIdl", true);
    }

    /// <summary>
    /// Metodo que activa la transicion de correr a dash
    /// </summary>
    public void runToDash()
    {
        setFalseAllAnimations();
        animator.SetBool("runToDash", true);
    }
    /// <summary>
    /// Metodo que activa la transicion de dash a correr
    /// </summary>
    public void dashToRun()
    {
        setFalseAllAnimations();
        animator.SetBool("dashToRun", true);
    }

    /// <summary>
    /// Metodo que activa la animacion de muerte del personaje
    /// </summary>
    public void death(bool _value)
    {
        setFalseAllAnimations();
        animator.SetBool("death", _value);
    }

    /// <summary>
    /// Metodo que activa la animacion de doble salto
    /// </summary>
    public void DoubleJump()
    {
        setFalseAllAnimations();
        animator.SetBool("doubleJump", true);
    }

    public void DoubleJumpFalse()
    {
        animator.SetBool("doubleJump", false);
    }

    public void ForceWallJump()
    {
        animator.SetBool("wallJump", true);
        animator.Play("wallJump");
    }

    //PASAR A FALSO

    /// <summary>
    /// Metodo que desactiva la transicion de idl a correr
    /// </summary>
    public void RunToIdl()
    {
        animator.SetBool("idlToRun", false);
    }

    /// <summary>
    /// Metodo que activa o desactiva la animacion de wallJump
    /// </summary>
    public void WallJump(bool boolean)
    {
        if (boolean)
        {
            animator.SetBool("jumpToRun", false);
            animator.SetBool("jumpToIdl", false);            
        }
       

        animator.SetBool("wallJump", boolean);
    }

    /// <summary>
    /// Metodo que activa o desactiva la animacion de atacar
    /// </summary>
    public void Attack(bool boolean)
    {
        animator.SetBool("Attacking", boolean);
    }

    /// <summary>
    /// Metodo que activa o desactiva la transicion de walljump a correr
    /// </summary>
    public void WallToRun(bool boolean)
    {
        animator.SetBool("walToRun", boolean);
    }

    /// <summary>
    /// Metodo que activa o desactiva la animacion de caida
    /// </summary>
    public void Fall(bool boolean)
    {
        animator.SetBool("Fall", boolean);
    }

    /// <summary>
    /// Metodo que activa o desactiva la animacion de daño del personaje
    /// </summary>
    public void Hurt(bool boolean)
    {        
        animator.SetBool("Hurt", boolean);
    }

    public void GameOver(bool boolean)
    {
        setFalseAllAnimations();
        animator.SetBool("gameOver", boolean);
    }

    public void RightArm(bool boolean)
    {
        fronArm.SetBool("Attacking", boolean);
    }

    public void LeftArm(bool boolean)
    {
        backArm.SetBool("Attacking", boolean);
    }

    //pone todas las variables del animator a false para que no haya transiciones no deseadas
    /// <summary>
    /// Metodo que resetea todas las transiciones y animaciones a falso.
    /// </summary>
    public void  setFalseAllAnimations()
    {
        animator.SetBool("idlToDash", false);
        animator.SetBool("dashToIdl", false);
        animator.SetBool("idlToJump", false);
        animator.SetBool("jumpToIdl", false);
        animator.SetBool("jumpToDash", false);
        animator.SetBool("runToJump", false);
        animator.SetBool("jumpToRun", false);
        animator.SetBool("runToDash", false);
        animator.SetBool("dashToRun", false);
        animator.SetBool("doubleJump", false);
        animator.SetBool("wallJump", false);
        Fall(false);
        //Hurt(false);
        //GameOver(false);
    }

    



    




}
