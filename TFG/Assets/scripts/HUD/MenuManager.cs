using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL MENU PRINCIPAL DEL JUEGO
/// </summary>
public class MenuManager : MonoBehaviour {
   
    /// <summary>
    /// Tiempo para que el fade se realice poco a poco (incrementando o decrementando)
    /// </summary>
    public float fadeTime = 0.025f;

    /// <summary>
    /// Referencia a la imagen de fade
    /// </summary>
    public RawImage fadeBlack;

    /// <summary>
    /// Referencia a la imagen principal del fondo
    /// </summary>
    public GameObject staticImage;

    /// <summary>
    /// Referencia al resto de imagenes que hay en el fondo
    /// </summary>
    public RawImage[] concepts;

   
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Sequence();       
    }

    /// <summary>
    /// Metodo para realizar el fadeOut
    /// </summary>
    /// <param name="image"></param>
    void FadeOut(RawImage image)
    {        
        Color color = image.color;
        color.a -= fadeTime;
        image.color = color;       
    }

    /// <summary>
    /// Metodo para resetear el alpha de la imagen
    /// </summary>
    /// <param name="image"></param>
    void ResetAlpha(RawImage image)
    {
        Color color = image.color;
        color.a = 255;
        image.color = color;
                
    }

    /// <summary>
    /// Metodo para la sucesion de imagenes del fondo mediante fades
    /// </summary>
    void Sequence()
    {
        if (fadeBlack.color.a >= 0)
            FadeOut(fadeBlack);

        if (fadeBlack.color.a <= 0)
            FadeOut(concepts[0]);

        //FADE OUT

        if (concepts[0].color.a <= 0)
        {
            staticImage.SetActive(true);
            FadeOut(concepts[1]);
        }

        if (concepts[1].color.a <= 0)
            FadeOut(concepts[2]);

        if (concepts[2].color.a <= 0)
            FadeOut(concepts[3]);

        if (concepts[3].color.a <= 0)
            FadeOut(concepts[4]);

        if (concepts[4].color.a <= 0)
        {
            Reset();
        }
    }  

    /// <summary>
    /// Metodo para resetear el alpha de todas las imagenes
    /// </summary>
    void Reset()
    {
        for(int i = 0; i < concepts.Length; i++)
        {
            ResetAlpha(concepts[i]);
        }
        
        staticImage.SetActive(false);

        
    }
}
