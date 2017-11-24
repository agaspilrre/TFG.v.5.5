using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy2 : MonoBehaviour {

    public float speedBullet;
    
    public bool makeDamage;
    public bool makeSlow;
    public int damage;
    public float speedSlow;
    public float timeSlow;
    public Transform spawnBulletPoint;
    public GameObject bulletSmallEnemy2;
    private GameObject bullet;
    public float timeBetwenShoot;
    private float timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= timeBetwenShoot)
        {
            InstantiateBullet();
            timer = 0;
        }
		
	}


    public void InstantiateBullet()
    {
        bulletSmallEnemy2.GetComponent<bulletSE2>().setSpeed(speedBullet);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setMakeDamage(makeDamage);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setMakeSlow(makeSlow);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setDamage(damage);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setSlowSpeed(speedSlow);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setSlowTimer(timeSlow);

        bullet= (GameObject)Instantiate(bulletSmallEnemy2, spawnBulletPoint.position, spawnBulletPoint.rotation);

       
    }
}
