using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public ParticleSystem power;
    GameObject powerUpBox;
    public bool isBoxBroken = false;
    float speed = 5;
    public float speedGoToPlayer = 10;
    ParticleSystem clone;
    Transform playerTr;
    lifeScript lifeScript;
    float timer;
    public GameObject dashIcon;
    public float timeAscendParticle = 3;
	// Use this for initialization
	void Start () {

        powerUpBox = GameObject.FindGameObjectWithTag("PowerUp").GetComponent<GameObject>();
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<lifeScript>();
        
    }
	
	// Update is called once per frame
	void Update () {

        int lifes = lifeScript.getLifeCount();

        if (isBoxBroken)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            timer += Time.deltaTime;
        }            

        if (timer >= timeAscendParticle)
        {
            isBoxBroken = false;
            Invoke("MoveToPlayer", 2);
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
            clone = Instantiate(power, transform.position, transform.rotation) as ParticleSystem;
            clone.transform.SetParent(gameObject.transform);            
        }
    }
    
    public void MoveToPlayer()
    {
        float step = speedGoToPlayer * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTr.position, step);

        if (transform.position == playerTr.position)
        {           
            CancelInvoke();
            Destroy(gameObject);
            dashIcon.SetActive(true);
        }
    }

    public void setBoxBroken(bool value)
    {
        isBoxBroken = value;
    }
}
