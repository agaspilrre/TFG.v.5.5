﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO, VELOCIDAD Y DIRECCION DE LA BALA DISPARADA POR EL SMALL ENEMY2
/// </summary>
public class bulletSE2 : MonoBehaviour {

    private Rigidbody2D rb;
    public float speed;
    public int damage;
    public bool makeDamage;
    public bool makeSlow;
    public float speedSlow;
    public float timeSlow;
    public bool UpShoot;
    public bool DownShoot;
    public bool RightShoot;
    public bool LeftShoot;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip clip;

    bool dontPlay;

    // Use this for initialization
    //obtenemos el Rigidbody de la bala
    void Awake () {

        rb = GetComponent<Rigidbody2D>();
        dontPlay = false;
        
    }
	
	// Update is called once per frame
    //asigna velocidad y direccion de la bala dependiendo de las variables
	void Update () {

        if (UpShoot)
        {
            rb.velocity = new Vector2(0, 1 * speed);
        }

        else if (DownShoot)
        {
            rb.velocity = new Vector2(0, -1 * speed);
        }

        else if (RightShoot)
        {
            rb.velocity = new Vector2(1 * speed, 0);
        }

        else if (LeftShoot)
        {
            rb.velocity = new Vector2(-1 * speed, 0);
        }
        

    }

    /// <summary>
    /// Metodo que cambia la variable UpShoot y resetea las demas variables de direccion a false
    /// </summary>
    /// <param name="_value"></param>
    public void setUpShoot(bool _value)
    {
        UpShoot = _value;

        
        DownShoot = false;
        RightShoot = false;
        LeftShoot = false;



    }

    /// <summary>
    /// Metodo que cambia la variable DownShoot y resetea las demas variables de direccion a false
    /// </summary>
    /// <param name="_value"></param>
    public void setDownShoot(bool _value)
    {
        DownShoot = _value;
        UpShoot = false;
       
        RightShoot = false;
        LeftShoot = false;
    }

    /// <summary>
    /// Metodo que cambia la variable RightShoot y resetea las demas variables de direccion a false
    /// </summary>
    /// <param name="_value"></param>
    public void setRightShoot(bool _value)
    {
        RightShoot = _value;
        UpShoot = false;
        DownShoot = false;
        
        LeftShoot = false;
    }

    /// <summary>
    /// Metodo que cambia la variable LeftShoot y resetea las demas variables de direccion a false
    /// </summary>
    /// <param name="_value"></param>
    public void setLeftShoot(bool _value)
    {
        LeftShoot = _value;
        UpShoot = false;
        DownShoot = false;
        RightShoot = false;
        
    }

    /// <summary>
    /// Metodo que establece la velocidad de la bala
    /// </summary>
    /// <param name="_speed"></param>
    public void setSpeed(float _speed)
    {
        speed = _speed;
    }

    /// <summary>
    /// Metodo que establece el daño que causa la vale al jugador
    /// </summary>
    /// <param name="_damage"></param>
    public void setDamage(int _damage)
    {
        damage = _damage;
    }

    /// <summary>
    /// Metodo que se encarga de indicar si este disparo es dañino
    /// </summary>
    /// <param name="_makeDamage"></param>
    public void setMakeDamage(bool _makeDamage)
    {
        makeDamage = _makeDamage;
    }

    /// <summary>
    /// Metodo que indica si esta bala realentiza el movimiento del jugador
    /// </summary>
    /// <param name="_makeSlow"></param>
    public void setMakeSlow(bool _makeSlow)
    {
        makeSlow = _makeSlow;
    }

    /// <summary>
    ///Metodo que asigna la velocidad a la que  el jugador es realentizado por el contacto con esta bala 
    /// </summary>
    /// <param name="_slowSpeed"></param>
    public void setSlowSpeed(float _slowSpeed)
    {
        speedSlow = _slowSpeed;
    }

    /// <summary>
    /// Metodo que asigna el tiempo en el que el jugador permance realentizado por el contacto de esta bala
    /// </summary>
    /// <param name="_timer"></param>
    public void setSlowTimer(float _timer)
    {
        timeSlow = _timer;
    }

    /*
    void OnCollisionEnter2D(Collision2D coll)
    {
        
            if (coll.gameObject.tag == "Player")
            {
                //call die function
                if(makeDamage)
                    coll.gameObject.GetComponent<lifeScript>().makeDamage(damage);

                //hacer realentizacion tb
                if (makeSlow)
                    coll.gameObject.GetComponent<Player>().setMakeSlow(true, timeSlow, speedSlow);
            }

            Destroy(gameObject);

        



    }*/


    //Gestiona la colision de esta bala con el player y demas elementos del escenario
    private void OnTriggerEnter2D(Collider2D coll)
    {
      
        if (coll.gameObject.tag == "Player")
        {
            //call die function
            if (makeDamage)
                coll.gameObject.GetComponent<lifeScript>().makeDamage(damage);

            //hacer realentizacion tb
            if (makeSlow)
                coll.gameObject.GetComponent<Player>().setMakeSlow(true, timeSlow, speedSlow);
        }

        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Pared" || coll.gameObject.tag == "Suelo" || coll.gameObject.tag == "techo" || coll.gameObject.tag == "Platform")
        {          

            Destroy(gameObject, 0.15f);            
        }

        if(coll.gameObject.tag == "Player")
        {
            if (!dontPlay)
            {
                dontPlay = true;
                source.clip = clip;
                source.Play();
            }
        }

        if (coll.gameObject.tag == "Pared")
        {
            if (!dontPlay)
            {
                dontPlay = true;
                source.clip = clip;
                source.Play();
            }
        }

        if (coll.gameObject.tag == "Suelo")
        {
            if (!dontPlay)
            {
                dontPlay = true;
                source.clip = clip;
                source.Play();
            }
        }

        if (coll.gameObject.tag == "techo")
        {
            if (!dontPlay)
            {
                dontPlay = true;
                source.clip = clip;
                source.Play();
            }
        }

        if (coll.gameObject.tag == "Platform")
        {
            if (!dontPlay)
            {
                dontPlay = true;
                source.clip = clip;
                source.Play();
            }
        }

    }

}
