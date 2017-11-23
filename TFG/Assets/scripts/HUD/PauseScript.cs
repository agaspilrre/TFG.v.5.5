using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    GameObject PauseMenu;
    bool pausa;
    bool muted;
    [SerializeField]
    Text muteText;
    GameManager gameManager;
    public GameObject cameraMap;


	// Use this for initialization
	void Start () {

        pausa = false;
        PauseMenu = GameObject.Find("PauseMenu");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraMap.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (!gameManager.getGameOverState())
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("PS4_Options"))
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

    public void Mute()
    {
        muted = !muted;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
