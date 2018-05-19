using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour {
    CameraController mainCamera;

    public int numberOfBlok;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraController>();
        numberOfBlok = 0;
    }

    #region triggers
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "CameraDistorsion")
            BlurController.instance.SetActiveBlur(true);
        else if (other.name == "CameraEndPoint")
            mainCamera.SetCameraState("inactive");
        else if (other.name == "CameraStartPoint")
            mainCamera.SetCameraState("active");
        else if (other.name == "CameraBlockPoint")
        {
            numberOfBlok++;
            mainCamera.SetCameraState(other.tag);
        }
        else if (other.name == "PrefabPantalla")
        {
            mainCamera.SetCameraState(other.tag);
        }
        else if (other.tag == "EndScene")
        {
            if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "stars") < fixedVar.totalStarts)
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "stars", fixedVar.totalStarts);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);//1 es que te lo pasas y 0 que no 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.name == "CameraBlockPoint" || other.name == "PrefabPantalla") && numberOfBlok <= 1)
        {
            mainCamera.SetCameraState("active");
            numberOfBlok--;
        }
        else if(other.name == "CameraBlockPoint")
        {
            numberOfBlok--;
        }
    }
    #endregion
}
