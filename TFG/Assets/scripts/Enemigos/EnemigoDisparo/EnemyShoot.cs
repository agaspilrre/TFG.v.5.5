using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public bool haveMovement;
    public float rangeMovement;
    public Transform shootVerticalPoint;
    public Transform shootDiagonalRPoint;
    public Transform shootDiagonalLPoint;

    public GameObject verticalBullet;
    public GameObject diagonalRBullet;
    public GameObject diagonalLBullet;
    GameObject bullet1;
    GameObject bullet2;
    GameObject bullet3;

    public float speedMove;
    public float speedBullet;
    float directionMove = 1;
    public int timeBetwenShoot;
    int countTimer=0;
    Rigidbody2D rbEnemy;
    float initialPositionX;
    float initialPositionY;

  


	// Use this for initialization
	void Awake () {

        rbEnemy=GetComponent<Rigidbody2D>();
        initialPositionX = this.transform.position.x;
        initialPositionY = this.transform.position.y;

        

    }
	
	// Update is called once per frame
	void Update () {




        if (haveMovement)
        {
            //look rotation object enemy for make movement
            //horizontal move
            if((this.transform.eulerAngles.z>=0 && this.transform.eulerAngles.z<=89)||
               ( this.transform.eulerAngles.z > 170 && this.transform.eulerAngles.z <= 260) )
            {
                rbEnemy.constraints= RigidbodyConstraints2D.None;
                rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionY;
                rbEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;

                if (this.transform.position.x>=initialPositionX+rangeMovement ||
                    this.transform.position.x <= initialPositionX- rangeMovement)
                {
                    directionMove *= -1;
                }
                rbEnemy.velocity = new Vector2(directionMove * speedMove, 0);

            }

            //vertical move
            else if ((this.transform.eulerAngles.z >= 89 && this.transform.eulerAngles.z <= 169) ||
              (this.transform.eulerAngles.z > 260 && this.transform.eulerAngles.z <= 360))
            {

                rbEnemy.constraints = RigidbodyConstraints2D.None;
                rbEnemy.constraints = RigidbodyConstraints2D.FreezePositionX;
                rbEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;

                if (this.transform.position.y >= initialPositionY + rangeMovement ||
                    this.transform.position.y <= initialPositionY - rangeMovement)
                {
                    directionMove *= -1;
                }
                rbEnemy.velocity = new Vector2(0, directionMove * speedMove);

            }




        }

        //timer instantiate bullets
        countTimer++;
        if (countTimer > timeBetwenShoot)
        {
            InstantiateBullets();
            countTimer = 0;
        }


		
	}

    //function to instantiate bullets
    public void InstantiateBullets()
    {
        verticalBullet.GetComponent<Bullet>().setEnemy(this.gameObject);
        diagonalLBullet.GetComponent<Bullet>().setEnemy(this.gameObject);
        diagonalRBullet.GetComponent<Bullet>().setEnemy(this.gameObject);

        verticalBullet.GetComponent<Bullet>().setSpeedBullet(speedBullet);
        diagonalLBullet.GetComponent<Bullet>().setSpeedBullet(speedBullet);
        diagonalRBullet.GetComponent<Bullet>().setSpeedBullet(speedBullet);


        bullet1 = (GameObject)Instantiate(verticalBullet, shootVerticalPoint.position, shootVerticalPoint.rotation);
        bullet2 = (GameObject)Instantiate(diagonalLBullet, shootDiagonalLPoint.position, shootDiagonalLPoint.rotation);
        bullet3 = (GameObject)Instantiate(diagonalRBullet, shootDiagonalRPoint.position, shootDiagonalRPoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //pendiente de implementar
        /*
        if (coll.gameObject.tag == "NonStatic")
        {
            Destroy(gameObject);
        }*/

    }
}
