using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenTrigger : MonoBehaviour {

    [SerializeField]
    byte nextScreen;

    [SerializeField]
    Vector3 cameraPosition;

    CameraController mainCamera;
    ScreensManager screensManager;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraController>();
        screensManager = GameObject.Find("GameManager").GetComponent<ScreensManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mainCamera.ChangeGameScreen(cameraPosition);
            screensManager.Index = nextScreen;
        }
    }
}
