using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour {

    RectTransform rectTransform;
    public Vector3 buttonSizeOnSelect;

    public GameObject blurImage;
    public GameObject auxImage;
    public GameObject newGameMenu;
    public GameObject quitGameMenu;
    public GameObject settingsMenu;

    public EventSystem eventSyst;

    public GameObject yesButton;
    public GameObject menu;
    public GameObject startButton;

   

	// Use this for initialization
	void Start () {

        rectTransform = GetComponent<RectTransform>();	
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}   

    public void seeChange()
    {
       Invoke("makeBigger", 0.00005f);
    }

    public void makeBigger()
    {
        rectTransform.localScale = buttonSizeOnSelect;
    }

    public void reduceNormal()
    {
        rectTransform.localScale = new Vector3(1, 1, 1);
    }

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

    public void showOptions()
    {
        blurImage.SetActive(true);
        auxImage.SetActive(true);
        settingsMenu.SetActive(true);
        menu.SetActive(false);
    }

    public void showQuitGameMenu()
    {
        blurImage.SetActive(true);
        auxImage.SetActive(true);
        quitGameMenu.SetActive(true);
        menu.SetActive(false);
        eventSyst.firstSelectedGameObject = yesButton;
        eventSyst.SetSelectedGameObject(yesButton);
    }

    public void yesNewGameButton()
    {
        SceneManager.LoadScene("FreshStart");
    }

    public void noNewGameButton()
    {
        blurImage.SetActive(false);
        auxImage.SetActive(false);
        newGameMenu.SetActive(false);
        menu.SetActive(true);
        eventSyst.firstSelectedGameObject = startButton;
        eventSyst.SetSelectedGameObject(startButton);
    }

    public void yesQuitButton()
    {
        Application.Quit();
    }

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
