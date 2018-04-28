using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilityBar : MonoBehaviour {

    [SerializeField]
    List<GameObject> energySquares;

    bool activeRecover;
    public float cooldownTime;
    float initCooldown;
    public float generalTimeCooldown;

    bool start;
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

        if (energySquares[0].activeSelf && energySquares[1].activeSelf && energySquares[2].activeSelf && energySquares[3].activeSelf)
        {
            start = false;
        }
    }

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
