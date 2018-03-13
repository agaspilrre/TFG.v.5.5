﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;



public class lifeScript : MonoBehaviour {

    public GameObject[] life = new GameObject[4];
    int lifeCount;
    int numberLifes;

    public int invulnerableTime;

    CameraShake cameraShake;

    SpriteRenderer spriteRenderer;

    GameManager gameManager;

    bool shake;
    float timer;

    [SerializeField]
    float timeVibration;

    [SerializeField]
    float timeForEachColor;
    [SerializeField]
    float numberOfChanges;
    float auxNumberOfChanges;

    Color savedColor;
    [SerializeField]
    Color damageColor;

    [SerializeField]
    bool invulnerable;

    int invulnerableCount;

    // Use this for initialization
    void Start () {

        invulnerable = false;
        invulnerableCount = 0;
        shake = false;

        if(GameObject.Find("GameManager") != null)
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        cameraShake = Camera.main.GetComponent<CameraShake>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        savedColor = spriteRenderer.color;

        lifeCount = life.Length - 1;
        numberLifes = life.Length - 1;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (shake)
        {
            timer++;
            GamePad.SetVibration(0, 0.5f, 0.5f);            
        }

        if (timer >= timeVibration)
        {
            timer = 0;
            shake = false;
            GamePad.SetVibration(0, 0, 0);
        }
        //cuando es dañado tenemos un tiempo de invulnerabilidad
        if (invulnerable)
        {
            invulnerableCount++;
            //cuando pasa el tiempo de invulnerabilidad reseteamos variables para que pueda volver a suceder
            if (invulnerableCount >= invulnerableTime)
            {
                invulnerable = false;
                invulnerableCount = 0;
            }
        }
	}

    /*
 *   Función que controla la cantidad de vida que queremos restar al jugador 
 */
    public void makeDamage(int damage)
    {
        //solo hacemos daño si no estamos en estado invulnerable
        if (!invulnerable)
        {
            for (int i = 0; i < damage && lifeCount >= 0; i++)
            {
                life[lifeCount].SetActive(false);
                lifeCount--;
                StartCoroutine("InvulnerableColor");
                cameraShake.Shake();
                shake = true;
            }
            invulnerable = true;
        }
       
        if (lifeCount < 0)
        {
            //cargar gameover o lo que proceda
            gameManager.loadGameOver();
            
        }
    }

   

    IEnumerator InvulnerableColor()
    {
        auxNumberOfChanges = 0;

        while (auxNumberOfChanges < numberOfChanges)
        {
            if (spriteRenderer.color.a == 0)
            {
                spriteRenderer.color = savedColor;
                auxNumberOfChanges++;
            }
            else
                spriteRenderer.color = damageColor;

            yield return new WaitForSeconds(timeForEachColor);

        }
    }

    //funcion que añade vida

    public void cureLife(int cure)
    {
        //si la vida esta incompleta entonces curamos
        if (lifeCount < numberLifes)
        {
            int count = 0;
            for(int i = lifeCount; count < cure; i++)
            {
                lifeCount++;
                count++;
                life[lifeCount].SetActive(true);
            }
        }

    }

    public bool getInvulnerable()
    {
        return invulnerable;
    }

    public int getLifeCount()
    {
        return lifeCount;
    }
}
