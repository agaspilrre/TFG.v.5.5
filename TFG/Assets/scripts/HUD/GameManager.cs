using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// CLASE QUE SE ENCARGA DE GESTIONAR EL GAMEOVER Y DE RESETEAR LOS PARAMETROS DEL PLAYER PARA QUE PUEDA VOLVER A JUGAR
/// </summary>
public class GameManager : MonoBehaviour {

    public GameObject gameOver;
    public int timeGameOver;
    Transform camera;
    int countTime;
    lifeScript lifePlayer;
    CheckPointManager CPmanager;
    GameObject player;
    RawImage fadeImage;
    public float fadeTime;

    bool finishedFade;

	// Use this for initialization
	void Start () {

        gameOver.SetActive(false);
        countTime = 0;
        lifePlayer = GameObject.Find("Personaje").GetComponent<lifeScript>();
        CPmanager = this.gameObject.GetComponent<CheckPointManager>();
        player = GameObject.Find("Personaje");
        camera = Camera.main.transform;
        fadeImage = GameObject.Find("FadeInGameOver").GetComponent<RawImage>();
        finishedFade = false;
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
                if (fadeImage.color.a <= 1)
                {
                    Color color = fadeImage.color;
                    color.a += fadeTime;
                    fadeImage.color = color;                   
                }

                if(fadeImage.color.a >= 1)
                {
                    //poner al personaje en la posicion del checkpoint
                    //rellenar la vida del personaje de nuevo                    
                    countTime = 0;
                    lifePlayer.cureLife(3);
                    gameOver.SetActive(false);
                    //player.transform.position = CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position;//position of the checkpoint
                    //camera.position = CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position;
                    //camera.position = new Vector3(camera.position.x, camera.position.y, -10);
                    //Time.timeScale = 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                
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
