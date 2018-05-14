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
    PlayerAnim playerAnim;
    CheckPointManager CPmanager;
    GameObject player;
    RawImage fadeImage;
    public float fadeTime;

    bool finishedFade;
    int entryCount;
    

	// Use this for initialization
	void Start () {

        gameOver.SetActive(false);
        countTime = 0;
        lifePlayer = GameObject.Find("Personaje").GetComponent<lifeScript>();
        playerAnim = GameObject.Find("Personaje").GetComponent<PlayerAnim>();
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

                //if(fadeImage.color.a >= 1)
                else
                {
                    //poner al personaje en la posicion del checkpoint
                    //rellenar la vida del personaje de nuevo                    
                    countTime = 0;
                    lifePlayer.cureLife(4);
                    gameOver.SetActive(false);
                    Color color = fadeImage.color;
                    color.a = 0;
                    fadeImage.color = color;
                    //player.transform.position = CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position;//position of the checkpoint
                    player.transform.position = new Vector3(CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position.x, CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position.y, -3);
                    camera.position = CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).position;
                    camera.position = new Vector3(camera.position.x, camera.position.y, -10);
                   
                    ScreensManager.instance.Index = CPmanager.GetCheckPoint(PlayerPrefs.GetInt("CheckPoint")).GetComponent<CheckPoint>().pantallaID;
                    TimerManager.instance.setTime(PlayerPrefs.GetFloat("timeLoad"));
                    Time.timeScale = 1;
                    playerAnim.GameOver(false);
                    player.GetComponent<Player>().setPermitido(true);
                    
                    //entryCount = 0;
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                
            }
        }

	}

    public void loadGameOver()
    {
        //activar canvas y congelar juego
        if (entryCount <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            entryCount++;
            Invoke("resetCount", lifePlayer.timeToGameOver);
        }
    }

    public void resetCount()
    {
        entryCount = 0;
    }

    public bool getGameOverState()
    {
        return gameOver.activeSelf;
    }
}
