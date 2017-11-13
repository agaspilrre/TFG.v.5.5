using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManagger : MonoBehaviour {

    public GameObject bocadillo;
    public List<GameObject> Emojis = new List<GameObject>();
    lifeScript life;
    GameObject player;
    bool activateEmojis;
    bool lifeEmoji;
    public float durationEmoji;
    public float secondsStopPlayer;
    float time = 0;

    // Use this for initialization
    void Awake () {
        activateEmojis = true;

        player = GameObject.FindGameObjectWithTag("Player");

        DesactivateEmojis();

	}
	
	// Update is called once per frame
	void Update () {

        if (activateEmojis)
        {
            EmojiOnePointLife();
            EmojiPlayerStop();

        }

        else
        {
            time += Time.deltaTime;
            if (time >= durationEmoji)
            {
                DesactivateEmojis();
                time = 0;
                activateEmojis = true;
            }
        }
		
	}

    // Que el jugador cambie de personalidad x veces----> Emoji 1


    //Que la prota 1 haya recibido x veces daño---> Emoji 2


    //Que no haya podido pasar el nivel x veces.---> Emoji 3


    //Que el jugador se quede quieto X segundos ---> Emoji 4
    void EmojiPlayerStop()
    {
        if (player.GetComponent<PlayerInput>().getStopTime() >= secondsStopPlayer)
        {
            bocadillo.SetActive(true);
            Emojis[0].SetActive(true);
            
            //activateEmojis = false;
        }

        //cuidado con esto puede dar conflicto en un futuro si usamos el mismo emoji para otra funcion
        else
        {
            bocadillo.SetActive(false);
            Emojis[0].SetActive(false);
        }
    }

    //Que se acabe la stamina ---> Emoji 5



    //Que el jugador solo tenga 1 de vida ---> Emoji 6

    void EmojiOnePointLife()
    {

        if (player.GetComponent<lifeScript>().getLifeCount() == 0 && !lifeEmoji)
        {
            bocadillo.SetActive(true);
            Emojis[3].SetActive(true);
            lifeEmoji = true;//para que no se repita el estado
            activateEmojis = false;
        }
    }

    

    public void DesactivateEmojis()
    {
        for (int i = 0; i < Emojis.Count; i++)
        {
            Emojis[i].SetActive(false);
        }

        bocadillo.SetActive(false);
    }

}
