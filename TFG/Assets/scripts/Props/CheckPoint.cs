using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CLASE ENCARGADA DE GESTIONAR EL COMPORTAMIENTO DEL CHECKPOINT
/// </summary>
public class CheckPoint : MonoBehaviour {

   /// <summary>
   /// Variable que guarda el animator de este objeto
   /// </summary>
    Animator anim;

    /// <summary>
    /// Variable que guarda el contador de tiempo del time manager
    /// </summary>
    TimerManager tmanager;

    /// <summary>
    /// Variable para guardar valor de tiempo con la que el personaje pasa por el checkpoint
    /// </summary>
    public int timeValue;

   /// <summary>
   /// Variable que guarda el id del checpoint para referenciarlo en el player prefab
   /// </summary>
    public int id;

    /// <summary>
    /// Variable que guarda el ID de la pantalla donde esta el checkpoint, para referenciarla en los player prefabs
    /// </summary>
    public byte pantallaID;
   

	// Use this for initialization
    /// <summary>
    /// Obtiene los componentes Animator y TimerManager
    /// </summary>
	void Start () {
        
        anim = GetComponent<Animator>();
        tmanager = GameObject.Find("GameManager").GetComponent<TimerManager>();

    }
	


    /// <summary>
    /// Metodo que comprueba si el player ha atravesado el checkpoint
    /// si es asi activa la animacion del objeto checkpoint
    /// guarda el valor de tiempo con el que el jugador ha llegado al checkpoint
    /// añade tiempo al contador del jugador en el momento actual
    /// Guarda el id del checkpoint que acaba de atravesar
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            anim.SetBool("encender", true);
            //comunicar la posicion del personaje para que se quede guardada
            tmanager.addTime(timeValue);
            PlayerPrefs.SetFloat("timeLoad", tmanager.getTime());
            PlayerPrefs.SetInt("CheckPoint",id);

        }
    }

   
}
