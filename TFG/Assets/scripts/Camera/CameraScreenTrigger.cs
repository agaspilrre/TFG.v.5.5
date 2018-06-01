using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenTrigger : MonoBehaviour {

    /// <summary>
    /// indice de las proximas caras
    /// </summary>
    [SerializeField]
    byte nextScreen;

    /// <summary>
    /// posicion de la camara
    /// </summary>
    [SerializeField]
    Vector3 cameraPosition;

    /// <summary>
    /// referencia al player
    /// </summary>
    Transform player;

    /// <summary>
    /// variable para trasladar la camara al comienzo
    /// </summary>
    [SerializeField]
    bool QUIERES_QUE_SE_TELETRANSPORTE_JOSE = false;

    /// <summary>
    /// posicion de jugador al comienzo
    /// </summary>
    [SerializeField]
    Vector3 playerPosition;

    /// <summary>
    /// referencia a camara
    /// </summary>
    CameraController mainCamera;
    /// <summary>
    /// referencia al screen manager
    /// </summary>
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
