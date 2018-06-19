using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// CLASE QUE SE ENCARGA DE GESTIONAR EL GAMEOVER Y DE RESETEAR LOS PARAMETROS DEL PLAYER PARA QUE PUEDA VOLVER A JUGAR
/// </summary>
public class GameManager : MonoBehaviour {

    /// <summary>
    /// Referencia a la pantalla de gameover
    /// </summary>
    public GameObject gameOver;

    /// <summary>
    /// Tiempo de gameover
    /// </summary>
    public int timeGameOver;

    /// <summary>
    /// Referencia al transform de la camara
    /// </summary>
    Transform camera;

    /// <summary>
    /// Contador para quitar el gameover
    /// </summary>
    int countTime;

    /// <summary>
    /// Referencia al lifescript del player
    /// </summary>
    lifeScript lifePlayer;

    /// <summary>
    /// Referencia al player anim del player
    /// </summary>
    PlayerAnim playerAnim;

    /// <summary>
    /// Rerefencia al checkpoint manager
    /// </summary>
    CheckPointManager CPmanager;

    /// <summary>
    /// Referencia al gameobject del player
    /// </summary>
    GameObject player;

    /// <summary>
    /// Referencia a la imagen de fade
    /// </summary>
    RawImage fadeImage;

    /// <summary>
    /// Tiempo de fade
    /// </summary>
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
                    BlurController.instance.ResetBlur();

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

    /// <summary>
    /// Funcion que controla que el game over solo se cargue una vez por muerte
    /// </summary>
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

    /// <summary>
    /// Funcion que resetea el contador de carga de game over a 0
    /// </summary>
    public void resetCount()
    {
        entryCount = 0;
    }

    /// <summary>
    /// Metodo que devuelve si la referencia al gameOver esta activo o no
    /// </summary>
    /// <returns></returns>
    public bool getGameOverState()
    {
        return gameOver.activeSelf;
    }
}
