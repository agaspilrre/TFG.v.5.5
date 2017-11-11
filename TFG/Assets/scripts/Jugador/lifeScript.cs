using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeScript : MonoBehaviour {

    public GameObject[] life = new GameObject[4];
    int lifeCount = 3;

    public int invulnerableTime;

    CameraShake cameraShake;

    SpriteRenderer spriteRenderer;

    GameManager gameManager;

    [SerializeField]
    float timeForEachColor;
    [SerializeField]
    float numberOfChanges;
    float auxNumberOfChanges;

    Color savedColor;
    [SerializeField]
    Color damageColor;

    [SerializeField]
    bool invulnerable;

    int invulnerableCount;

    // Use this for initialization
    void Start () {

        invulnerable = false;
        invulnerableCount = 0;

        if(GameObject.Find("GameManager") != null)
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        cameraShake = Camera.main.GetComponent<CameraShake>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        savedColor = spriteRenderer.color;
    }
	
	// Update is called once per frame
	void Update () {

        //cuando es dañado tenemos un tiempo de invulnerabilidad
        if (invulnerable)
        {
            invulnerableCount++;
            //cuando pasa el tiempo de invulnerabilidad reseteamos variables para que pueda volver a suceder
            if (invulnerableCount >= invulnerableTime)
            {
                invulnerable = false;
                invulnerableCount = 0;
            }
        }
	}

    /*
 *   Función que controla la cantidad de vida que queremos restar al jugador 
 */
    public void makeDamage(int damage)
    {
        //solo hacemos daño si no estamos en estado invulnerable
        if (!invulnerable)
        {
            for (int i = 0; i < damage && lifeCount >= 0; i++)
            {
                life[lifeCount].SetActive(false);
                lifeCount--;
                StartCoroutine("InvulnerableColor");
                cameraShake.Shake();
            }
            invulnerable = true;
        }
       
        if (lifeCount < 0)
        {
            //cargar gameover o lo que proceda
            gameManager.loadGameOver();
            
        }
    }

    IEnumerator InvulnerableColor()
    {
        auxNumberOfChanges = 0;

        while (auxNumberOfChanges < numberOfChanges)
        {
            if (spriteRenderer.color.a == 0)
            {
                spriteRenderer.color = savedColor;
                auxNumberOfChanges++;
            }
            else
                spriteRenderer.color = damageColor;

            yield return new WaitForSeconds(timeForEachColor);

        }
    }

    //funcion que añade vida

    public void cureLife(int cure)
    {
        if (lifeCount < 3)
        {
            for(int i = lifeCount; lifeCount < cure; i++)
            {
                lifeCount++;
                life[lifeCount].SetActive(true);
            }
        }

    }

    public bool getInvulnerable()
    {
        return invulnerable;
    }
}
