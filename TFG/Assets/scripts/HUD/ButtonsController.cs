using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO DE LOS BOTONES DEL MENU PRINCIPAL
/// </summary>
public class ButtonsController : MonoBehaviour {

    /// <summary>
    /// Referencia al rect transform del boton
    /// </summary>
    RectTransform rectTransform;

    /// <summary>
    /// Vector3 para indicar el tamaño que va a tener el boton cuando se seleccione
    /// </summary>
    public Vector3 buttonSizeOnSelect;

    /// <summary>
    /// Referencia a la blur image
    /// </summary>
    public GameObject blurImage;

    /// <summary>
    /// Referencia a la imagen
    /// </summary>
    public GameObject auxImage;

    /// <summary>
    /// Referencia al menu de nueva partida
    /// </summary>
    public GameObject newGameMenu;

    /// <summary>
    /// Referencia al menu de quitar 
    /// </summary>
    public GameObject quitGameMenu;

    /// <summary>
    /// Referencia al menu de ajustes
    /// </summary>
    public GameObject settingsMenu;

    /// <summary>
    /// Referencia al event system
    /// </summary>
    public EventSystem eventSyst;

    /// <summary>
    /// Referencia al boton de si
    /// </summary>
    public GameObject yesButton;

    /// <summary>
    /// Referencia al menu
    /// </summary>
    public GameObject menu;

    /// <summary>
    /// Referencia al boton de start
    /// </summary>
    public GameObject startButton;

   

	// Use this for initialization
	void Start () {

        rectTransform = GetComponent<RectTransform>();	
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}   

    /// <summary>
    /// Metodo para hacer el boton mas grande
    /// </summary>
    public void seeChange()
    {
       Invoke("makeBigger", 0.00005f);
    }

    public void makeBigger()
    {
        rectTransform.localScale = buttonSizeOnSelect;
    }

    /// <summary>
    /// Metodo para devolver a su tamaño original
    /// </summary>
    public void reduceNormal()
    {
        rectTransform.localScale = new Vector3(1, 1, 1);
    }

    /// <summary>
    /// Metodo para mostrar el newGameMenu
    /// </summary>
    public void showNewGameMenu()
    {
        blurImage.SetActive(true);
        auxImage.SetActive(true);
        newGameMenu.SetActive(true);
        menu.SetActive(false);
        eventSyst.firstSelectedGameObject = yesButton;
        eventSyst.SetSelectedGameObject(yesButton);
    }

    public void loadGame()
    {

    }

    /// <summary>
    /// Metodo para mostrar el menu de opciones
    /// </summary>
    public void showOptions()
    {
        blurImage.SetActive(true);
        auxImage.SetActive(true);
        settingsMenu.SetActive(true);
        menu.SetActive(false);
    }

    /// <summary>
    /// Metodo para quitar el gameMenu
    /// </summary>
    public void showQuitGameMenu()
    {
        blurImage.SetActive(true);
        auxImage.SetActive(true);
        quitGameMenu.SetActive(true);
        menu.SetActive(false);
        eventSyst.firstSelectedGameObject = yesButton;
        eventSyst.SetSelectedGameObject(yesButton);
    }

    /// <summary>
    /// Metodo para cargar la escena de juego
    /// </summary>
    public void yesNewGameButton()
    {
        SceneManager.LoadScene("TheDoubt");
    }

    /// <summary>
    /// Metodo para el boton de no del newGame
    /// </summary>
    public void noNewGameButton()
    {
        blurImage.SetActive(false);
        auxImage.SetActive(false);
        newGameMenu.SetActive(false);
        menu.SetActive(true);
        eventSyst.firstSelectedGameObject = startButton;
        eventSyst.SetSelectedGameObject(startButton);
    }

    /// <summary>
    /// Metodo para quitar la aplicacion
    /// </summary>
    public void yesQuitButton()
    {
        Application.Quit();
    }

    /// <summary>
    /// Metodo para el boton del quitGame
    /// </summary>
    public void noQuitButton()
    {
        blurImage.SetActive(false);
        auxImage.SetActive(false);
        newGameMenu.SetActive(false);
        menu.SetActive(true);
        eventSyst.firstSelectedGameObject = startButton;
        eventSyst.SetSelectedGameObject(startButton);
    }
}
