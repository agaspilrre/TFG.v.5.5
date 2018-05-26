using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// CLASE ENCARGADA DE ADMINISTRAR LA BARRA DE STAMINA DEL PERSONAJE
/// </summary>
public class HabilityBar : MonoBehaviour {

    /// <summary>
    /// Lista de barras de stamina que tiene el personaje
    /// </summary>
    [SerializeField]
    List<GameObject> energySquares;

    bool activeRecover;

    /// <summary>
    /// Tiempo de cooldown de recuperacion
    /// </summary>
    public float cooldownTime;

    /// <summary>
    /// Tiempo de recuperacion de cooldown para una barra
    /// </summary>
    float initCooldown;

    /// <summary>
    /// Tiempo de recuperacion de cooldown para todas las barras
    /// </summary>
    public float generalTimeCooldown;

    /// <summary>
    /// Booleano para controlar el comienzo de recuperacion
    /// </summary>
    bool start;

    /// <summary>
    /// Timer auxiliar para la recuperacion 
    /// </summary>
    float timer;

    private void Start()
    {
        start = false;
        initCooldown = cooldownTime;
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    loseSquare();

        //Si hay que recuperar alguno o todos
        if (!energySquares[0].activeSelf && !energySquares[1].activeSelf && !energySquares[2].activeSelf && !energySquares[3].activeSelf)
        {
            cooldownTime = generalTimeCooldown;            
        }
        else
            cooldownTime = initCooldown;       
        
        if(start)
            timer += Time.deltaTime;

        if (timer >= cooldownTime)
        {
            recoverSquare();
            timer = 0;           
        }

        //Todos recuperados
        if (energySquares[0].activeSelf && energySquares[1].activeSelf && energySquares[2].activeSelf && energySquares[3].activeSelf)
        {
            start = false;
        }
    }

    /// <summary>
    /// Metodo para perder una barra
    /// </summary>
    public void loseSquare()
    {
        for (int i = 0; i < energySquares.Count; i++)
        {
            //Si se usa la primera se desactiva y tras el cooldownTime se vuelve a activar
            if (energySquares[i].activeSelf)
            {
                energySquares[i].SetActive(false);
                start = true;             
                return;                
            }          

        }
    }

    /// <summary>
    /// Metodo para recuperar una barra
    /// </summary>
    public void recoverSquare()
    {
        for (int i = energySquares.Count -1; i >= 0; i--)
        {
            if (!energySquares[i].activeSelf)
            {
                energySquares[i].SetActive(true);
                return;
            }           
        }
    }   

    /// <summary>
    /// Metodo para determinar si la barra general esta vacia
    /// </summary>
    /// <returns></returns>
    public bool isBarEmpty()
    {
        if (!energySquares[0].activeSelf && !energySquares[1].activeSelf && !energySquares[2].activeSelf && !energySquares[3].activeSelf)
        {
            return true;
        }
        else
            return false;
    }    
}
