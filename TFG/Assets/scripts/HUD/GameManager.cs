using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOver;
    public int timeGameOver;
    int countTime;
    lifeScript lifePlayer;
    CheckPointManager CPmanager;
    GameObject player;

	// Use this for initialization
	void Start () {

        gameOver.SetActive(false);
        countTime = 0;
        lifePlayer = GameObject.Find("Personaje").GetComponent<lifeScript>();
        CPmanager = this.gameObject.GetComponent<CheckPointManager>();
        player = GameObject.Find("Personaje");
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
                countTime = 0;
                lifePlayer.cureLife(3);
                gameOver.SetActive(false);
                player.transform.position = CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position;//position of the checkpoint
                Time.timeScale = 1;
            }
        }

	}

    public void loadGameOver()
    {
        //activar canvas y congelar juego

        gameOver.SetActive(true);
        Time.timeScale = 0;

    }

    public bool getGameOverState()
    {
        return gameOver.activeSelf;
    }
}
