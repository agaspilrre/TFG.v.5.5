using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOver;
    public int timeGameOver;
    int countTime;

	// Use this for initialization
	void Start () {

        gameOver.SetActive(false);
        countTime = 0;

	}
	
	// Update is called once per frame
	void Update () {

        if (gameOver.activeSelf == true)
        {
            countTime++;
            if (countTime > timeGameOver)
            {
                //quitar game over

                //poner fade
                //poner al personaje en la posicion del checkpoint
                //rellenar la vida del personaje de nuevo
            }
        }

	}

    public void loadGameOver()
    {
        //activar canvas y congelar juego

        gameOver.SetActive(true);

    }
}
