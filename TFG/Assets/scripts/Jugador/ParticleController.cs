using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    float timer;
    public float speed = 5;
    public float timeAscendParticle = 3;
    public float timeSuspensionParticle = 2;
    public float speedGoToPlayer = 10;
    PowerUp controlPU;
    Transform playerTr;

    // Use this for initialization
    void Start () {

        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controlPU = GameObject.FindGameObjectWithTag("ControlPowerUp").GetComponent<PowerUp>();
    }
	
	// Update is called once per frame
	void Update () {

        if (controlPU.isBoxBroken)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            timer += Time.deltaTime;
        }

        if (timer >= timeAscendParticle)
        {
            controlPU.isBoxBroken = false;
            Invoke("MoveToPlayer", timeSuspensionParticle);
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
            Destroy(controlPU.powerController);
        }
    }
}
