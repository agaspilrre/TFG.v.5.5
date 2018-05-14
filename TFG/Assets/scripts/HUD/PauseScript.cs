using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    GameObject PauseMenu;
    bool pausa;    
    GameManager gameManager;
    public GameObject cameraMap;

    private void Awake()
    {
        PauseMenu = GameObject.Find("PauseMenu");
    }


    // Use this for initialization
    void Start () {

        pausa = false;
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraMap.SetActive(false);
	}
	
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
                cameraMap.SetActive(true);
            }
            else if (!pausa)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1;
                cameraMap.SetActive(false);
            }
        }        

        /*if (muted)
        {
            AudioListener.volume = 0;
            muteText.text = "Unmute";
        }

        if (!muted)
        {
            AudioListener.volume = 1;
            muteText.text = "Mute";
        }*/
    }

    public void Resume()
    {
        pausa = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Portada");
    }


    public void Quit()
    {
        Application.Quit();
    }
}
