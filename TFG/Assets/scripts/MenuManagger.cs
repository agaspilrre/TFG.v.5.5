using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManagger : MonoBehaviour {

    //funcion para cargar la escena de juego
    public void OnNewGameClick()
    {
        SceneManager.LoadScene("scenne_1");
    }


    //funcion para salir del juego
    public void OnQuitClick()
    {
        Application.Quit();//sale del juego
    }


}
