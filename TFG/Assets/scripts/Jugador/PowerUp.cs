using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public GameObject power;
    public GameObject allPowerUp;
    public bool isBoxBroken = false;
    public float speed = 5;
    public float speedGoToPlayer = 10;
    GameObject clone;
    Transform playerTr;
    lifeScript lifeScript;
    float timer;
    public GameObject dashIcon;
    public float timeAscendParticle = 3;
    public float timeSuspensionParticle = 2;
    public Transform spawner;

	// Use this for initialization
	void Start () {
        
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<lifeScript>();        
    }
	
	// Update is called once per frame
	void Update () {

        int lifes = lifeScript.getLifeCount();

        if (isBoxBroken)
        {
            clone.transform.Translate(Vector3.up * Time.deltaTime * speed);
            timer += Time.deltaTime;
        }            

        if (timer >= timeAscendParticle)
        {
            isBoxBroken = false;
            Invoke("MoveToPlayer", timeSuspensionParticle);
        }                
        
        if(lifes < 0)
        {
            Destroy(gameObject);
        }
    }  

    public void PowerUpInstantiate()
    {
        if (isBoxBroken)
        {
            clone = Instantiate(power, spawner.position, spawner.rotation);          
        }
    }
    
    public void MoveToPlayer()
    {
        if(clone != null)
        {
            float step = speedGoToPlayer * Time.deltaTime;
            clone.transform.position = Vector3.MoveTowards(clone.transform.position, playerTr.position, step);

            if (clone.transform.position == playerTr.position)
            {
                CancelInvoke();
                Destroy(clone);
                Destroy(allPowerUp);
                dashIcon.SetActive(true);

            }
        }        
    }

    public void setBoxBroken(bool value)
    {
        isBoxBroken = value;
    }
}
