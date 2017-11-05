using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else if (other.name == "CameraBlockPoint")
            mainCamera.SetCameraState("blocked", other.tag);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "CameraBlockPoint")
            mainCamera.SetCameraState("active");
    }
    #endregion
}
