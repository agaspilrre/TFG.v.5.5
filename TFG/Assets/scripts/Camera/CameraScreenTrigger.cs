using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenTrigger : MonoBehaviour {

    [SerializeField]
    byte nextScreen;

    [SerializeField]
    Vector3 cameraPosition;

    Transform player;

    [SerializeField]
    bool QUIERES_QUE_SE_TELETRANSPORTE_JOSE = false;

    [SerializeField]
    Vector3 playerPosition;

    CameraController mainCamera;
    ScreensManager screensManager;

    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraController>();
        screensManager = GameObject.Find("GameManager").GetComponent<ScreensManager>();
        player = GameObject.Find("Personaje").transform;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            mainCamera.ChangeGameScreen(cameraPosition);

            if(QUIERES_QUE_SE_TELETRANSPORTE_JOSE)player.position = playerPosition;

            screensManager.Index = nextScreen;
        }
    }
}
