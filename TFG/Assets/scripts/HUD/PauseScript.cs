using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL MENU DE PAUSA DEL JUEGO
/// </summary>
public class PauseScript : MonoBehaviour {

    /// <summary>
    /// Referencia al menu de pausa
    /// </summary>
    GameObject PauseMenu;
    
    /// <summary>
    /// Booleano para comprobar si estamos en pausa
    /// </summary>
    bool pausa;    

    /// <summary>
    /// Referencia al gamemanager de juego
    /// </summary>
    GameManager gameManager;


    //public GameObject cameraMap;

    private void Awake()
    {
        PauseMenu = GameObject.Find("PauseMenu");
    }


    // Use this for initialization
    void Start () {

        pausa = false;
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        PauseMenu.SetActive(false);
        //cameraMap.SetActive(false);
	}
	
    //Si pulsamos la P activamos el menu y paramos el tiempo
	// Update is called once per frame
	void Update () {

        if (!gameManager.getGameOverState())
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButton"))
            {
                pausa = !pausa;
            }

            if (pausa)
            {

                PauseMenu.SetActive(true);
                Time.timeScale = 0;
                //cameraMap.SetActive(true);
            }
            else if (!pausa)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                //cameraMap.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Metodo para continuar jugando
    /// </summary>
    public void Resume()
    {
        pausa = false;
    }

    /// <summary>
    /// Metodo para volver al menu principal
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene("Portada");
    }

    /// <summary>
    /// Metodo para quitar la aplicacion
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
