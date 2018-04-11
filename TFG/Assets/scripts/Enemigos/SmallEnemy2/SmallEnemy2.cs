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
    public float timeStun;
    bool stuned;
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
    Animator animator;

    public int Damage;

    // Use this for initialization
    void Start () {

        StartCoroutine(StartCount());
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if(!stuned)
        {
            if (startCountTime)
            {
                timer += Time.deltaTime;
                //ponemos la animacion de atacar
                if (timer >= timeBetwenShoot - 1.8f)
                {
                    animator.SetBool("attack", true);
                }

                if (timer >= timeBetwenShoot)
                {
                    InstantiateBullet();
                    timer = 0;
                }
            }
        }

        else
        {
            timer += Time.deltaTime;
            if(timer>=timeStun)
            {
                timer = 0;
                stuned = false;
                animator.SetBool("stun", false);
                animator.SetBool("attack", true);
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

        animator.SetBool("idle", true);
        animator.SetBool("attack", false);

       
    }

    public void EnemyMakeDamage(int _damage)
    {
        life -= _damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    


    public void OnParticleCollision(GameObject collision)
    {

        print("JODER");
        animator.SetBool("idle", false);
        animator.SetBool("attack", false);
        animator.SetBool("stun", true);
        stuned = true;
            
        

    }
}
