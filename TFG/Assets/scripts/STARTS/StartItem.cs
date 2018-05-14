using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASSE ENCARGADA DE COMPROBAR SI EL JUGADOR A COLISIONADO CON ESTE OBJETO ESTRELLA
/// </summary>
public class StartItem : MonoBehaviour {

    public bool haveThisStart;

    [SerializeField]
    AudioSource source;

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
