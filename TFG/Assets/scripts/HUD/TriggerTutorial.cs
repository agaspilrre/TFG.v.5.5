using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL TRIGGER QUE VA A MOSTRAR LAS IMAGENES A MODO DE TUTORIAL
/// </summary>
public class TriggerTutorial : MonoBehaviour {

    /// <summary>
    /// Referencia a la imagen de tutorial que va a mostrar
    /// </summary>
    [SerializeField]
    GameObject image;

    /// <summary>
    /// Booleano para controlar si esta visible o no
    /// </summary>
    bool visible;
	// Use this for initialization
	void Start () {

        visible = false;
        image.SetActive(false);
	}

    /// <summary>
    /// Si colisiona con el trigger mostramos la imagen
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!visible)
            {
                visible = true;
                image.SetActive(true);
            }           
        }
    }

    /// <summary>
    /// Al salir del trigger desactivamos la imagen
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            image.SetActive(false);
        }
    }
}
