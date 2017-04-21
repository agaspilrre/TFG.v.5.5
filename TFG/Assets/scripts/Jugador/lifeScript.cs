using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeScript : MonoBehaviour {

    public GameObject[] life = new GameObject[4];
    int lifeCount = 3;

    public int invulnerableTime;

    GameManager gameManager;

    [SerializeField]
    bool invulnerable;

    int invulnerableCount;

    // Use this for initialization
    void Start () {

        invulnerable = false;
        invulnerableCount = 0;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

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
            }
            invulnerable = true;
        }
       

        if (lifeCount < 0)
        {
            //cargar gameover o lo que proceda
            gameManager.loadGameOver();
            
        }
    }


    //funcion que añade vida

    public void cureLife(int cure)
    {
        if (lifeCount < 3)
        {
            for(int i=lifeCount;lifeCount<cure;i++)
            lifeCount++;
            life[lifeCount].SetActive(true);

        }

    }

    public bool getInvulnerable()
    {
        return invulnerable;
    }






}
