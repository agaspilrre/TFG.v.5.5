using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

   
    public float fadeTime = 0.025f;
    public RawImage fadeBlack;
    public GameObject staticImage;
    public RawImage[] concepts;

    bool round;

    // Use this for initialization
    void Start () {

        round = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        Sequence();       
    }

    void FadeOut(RawImage image)
    {        
        Color color = image.color;
        color.a -= fadeTime;
        image.color = color;       
    }

    void ResetAlpha(RawImage image)
    {
        Color color = image.color;
        color.a = 255;
        image.color = color;
                
    }

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

  

    void Reset()
    {
        for(int i = 0; i < concepts.Length; i++)
        {
            ResetAlpha(concepts[i]);
        }
        
        staticImage.SetActive(false);

        
    }
}
