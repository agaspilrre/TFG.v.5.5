﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManagger : MonoBehaviour {

    //funcion para cargar la escena de juego
    /// <summary>
    /// Erase un señor q se llamaba jose y era mari...
    /// Hay un señor se llama Luis y es MARICON
    /// Hay un señor que se llama jose y es..... wuajajajajaajajajajajjajajajaja
    /// YYYY giraaaaaaaaa la noriiiiaaaaaaa y girraaaaaaa
    /// </summary>
    public void OnNewGameClick()
    {
        SceneManager.LoadScene("fade");
    }


    //funcion para salir del juego
    public void OnQuitClick()
    {
        Application.Quit();//sale del juego
    }


}
