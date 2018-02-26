﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour {
    CameraController mainCamera;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraController>();
    }

    #region triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CameraEndPoint")
            mainCamera.SetCameraState("inactive");
        else if (other.name == "CameraStartPoint")
            mainCamera.SetCameraState("active");
        else if (other.name == "CameraBlockPoint" || other.name == "PrefabPantalla")
            mainCamera.SetCameraState(other.tag);
        else if(other.tag=="EndScene")
        {
            if(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "stars") < fixedVar.totalStarts)
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "stars", fixedVar.totalStarts);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);//1 es que te lo pasas y 0 que no 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CameraBlockPoint" || other.name == "PrefabPantalla")
            mainCamera.SetCameraState("active");
    }
    #endregion
}
