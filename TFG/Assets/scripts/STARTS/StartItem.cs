using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASSE ENCARGADA DE COMPROBAR SI EL JUGADOR HA COLISIONADO CON ESTE OBJETO ESTRELLA
/// </summary>
public class StartItem : MonoBehaviour {

    /// <summary>
    /// Booleano que comprueba si ya tenemos esta estrella
    /// </summary>
    public bool haveThisStart;

    /// <summary>
    /// Referencia al audiosource de la estrella
    /// </summary>
    [SerializeField]
    AudioSource source;

    /// <summary>
    /// Referencia al clip de sonido que va a emitir la estrella al ser recogida
    /// </summary>
    [SerializeField]
    AudioClip clip;

    // Use this for initialization
    void Start () {

        if (haveThisStart)
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Metodo encargado de comprobar si el jugador a colisionado con un objeto de tipo estrella
    /// Incrementa la cuenta de la clase estatica y destruye este objeto
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.clip = clip;
            source.Play();
            //incrementar variable estatica
            fixedVar.totalStarts ++;
            //incrementar variable start manager
            //GameObject.Find("GameManager").GetComponent<StartsManager>().incrementNumberStarts();
            //poner variable a true de que ya tengo este objeto.
            haveThisStart = true;
            //destruir el objeto
            Destroy(this.gameObject, 0.15f);

        }
    }
}
