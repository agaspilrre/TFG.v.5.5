using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy2 : MonoBehaviour {

    public float speedBullet;
    public bool UpShoot;
    public bool DownShoot;
    public bool RightShoot;
    public bool LeftShoot;
    
    public bool makeDamage;
    public bool makeSlow;
    public int damage;
    public float speedSlow;
    public float timeSlow;
    public Transform spawnBulletPointD;
    public Transform spawnBulletPointU;
    public Transform spawnBulletPointL;
    public Transform spawnBulletPointR;
    public GameObject bulletSmallEnemy2;
    private GameObject bullet;
    public float timeBetwenShoot;
    private float timer;
    public int life;

    bool startCountTime;
    public float TimeToStart;

    // Use this for initialization
    void Start () {

        StartCoroutine(StartCount());
    }
	
	// Update is called once per frame
	void Update () {

        if (startCountTime)
        {
            timer += Time.deltaTime;
            if (timer >= timeBetwenShoot)
            {
                InstantiateBullet();
                timer = 0;
            }
        }
       
		
	}

    IEnumerator StartCount()
    {
        
        yield return new WaitForSeconds(TimeToStart);
        startCountTime = true;
       
    }

    public void InstantiateBullet()
    {
        bulletSmallEnemy2.GetComponent<bulletSE2>().setSpeed(speedBullet);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setMakeDamage(makeDamage);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setMakeSlow(makeSlow);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setDamage(damage);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setSlowSpeed(speedSlow);
        bulletSmallEnemy2.GetComponent<bulletSE2>().setSlowTimer(timeSlow);

        if (UpShoot)
        {
            bulletSmallEnemy2.GetComponent<bulletSE2>().setUpShoot(true);
            bullet = (GameObject)Instantiate(bulletSmallEnemy2, spawnBulletPointU.position, spawnBulletPointU.rotation);
        }

        else if (DownShoot)
        {
            bulletSmallEnemy2.GetComponent<bulletSE2>().setDownShoot(true);
            bullet = (GameObject)Instantiate(bulletSmallEnemy2, spawnBulletPointD.position, spawnBulletPointD.rotation);
        }

        else if (RightShoot)
        {
            bulletSmallEnemy2.GetComponent<bulletSE2>().setRightShoot(true);
            bullet = (GameObject)Instantiate(bulletSmallEnemy2, spawnBulletPointR.position, spawnBulletPointR.rotation);
        }

        else if (LeftShoot)
        {
            bulletSmallEnemy2.GetComponent<bulletSE2>().setLeftShoot(true);
            bullet = (GameObject)Instantiate(bulletSmallEnemy2, spawnBulletPointL.position, spawnBulletPointL.rotation);
        }

        

       
    }

    public void EnemyMakeDamage(int _damage)
    {
        life -= _damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
