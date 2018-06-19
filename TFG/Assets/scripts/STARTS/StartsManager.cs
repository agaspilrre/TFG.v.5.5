using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// CLASE ENCARGADA DE MOSTRAR POR PANTALLA EL NUMERO DE ESTRELLAS RECOGIDAS Y EL NUMERO DE ESTRELLAS TOTAL DEL NIVEL
/// </summary>
public class StartsManager : MonoBehaviour {

    /// <summary>
    /// Numero de estrellas del nivel
    /// </summary>
    public int numberStartsLevel;

    /// <summary>
    /// Texto donde se muestran el numero de estrellas
    /// </summary>
    public Text startsText;
    public TextMeshPro tx;

    
    //public int starts;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        startsText.text = fixedVar.totalStarts + "  /  " + numberStartsLevel;
        //tx.text = fixedVar.totalStarts + "  /  " + numberStartsLevel;
        tx.text= fixedVar.totalStarts + "  /  " + numberStartsLevel; 


    }

    /*
    public void incrementNumberStarts()
    {
        starts++;
    }*/
}
