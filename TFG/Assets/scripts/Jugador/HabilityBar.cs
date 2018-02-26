using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilityBar : MonoBehaviour {

    [SerializeField]
    List<GameObject> energySquares;

    bool activeRecover;
    public float cooldownTime;
    public float generalTimeCooldown;

    bool isPaused;
    float timer;

    private void Start()
    {
        isPaused = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            loseSquare();


        if (!energySquares[0].activeSelf && !energySquares[1].activeSelf && !energySquares[2].activeSelf && !energySquares[3].activeSelf)
        {
            CancelInvoke("recoverSquare");
            Invoke("recoverAllSquares", generalTimeCooldown);
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

                //if(!isPaused)
                Invoke("recoverSquare", cooldownTime);
                return;
            }

            //else if(energySquares[i].activeSelf)
            //{
            //    energySquares[i].SetActive(false);
            //    Invoke("recoverSquare", cooldownTime * i * 2);
            //    return;
            //}
        }
    }

    public void recoverSquare()
    {
        for (int i = 3; i >= 0; i--)
        {
            if (!energySquares[i].activeSelf)
            {
                energySquares[i].SetActive(true);
                return;
            }
            //else if (!energySquares[i-1].activeSelf)
            //{
            //    StartCoroutine(activeSquare(i-1));
            //    return;
            //}

            //if (!energySquares[0].activeSelf)
            //{
            //    energySquares[0].SetActive(true);
            //    return;
            //}
            //else if(!energySquares[i].activeSelf)
            //{
            //    if (energySquares[i - 1].activeSelf)
            //    {
            //        energySquares[i].SetActive(true);
            //        return;
            //    }
            //}
        }
    }

    public void recoverAllSquares()
    {
        for (int i = 3; i >= 0; i--)
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

    public void activeSquare(float value)
    {

    }
}
