using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject power;
    public GameObject powerController;
    public bool isBoxBroken = false;
    public Transform spawner;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void PowerUpInstantiate()
    {
        if (isBoxBroken)
        {
            Instantiate(power, spawner.transform.position, Quaternion.identity);
        }
    }

    public void setBoxBroken(bool value)
    {
        isBoxBroken = value;
    }
}
