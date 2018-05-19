using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

/// <summary>
/// CLASE ENCARGADA DE CONTROLAR LA VIDA QUE TIENE EL JUGADOR
/// </summary>
public class lifeScript : MonoBehaviour {

    public GameObject[] life = new GameObject[4];
    int lifeCount;
    int numberLifes;

    public int invulnerableTime;

    CameraShake cameraShake;

    CameraController cameraController;

    SpriteRenderer spriteRenderer;

    GameManager gameManager;

    Player playerScript;

    PlayerInput inputScript;

    bool shake;
    float timer;
    float timerStop;

    [SerializeField]
    float timeVibration;

    [SerializeField]
    float quantityVibration;

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

    Rigidbody2D rb;
    [SerializeField]
    float damageDisForceX;
    [SerializeField]
    float damageDisForceY;

    [SerializeField]
    float damageDisInstantForceX;
    [SerializeField]
    float damageDisInstantForceY;

    [SerializeField]
    float decrementImpulse;

    PlayerAnim playerAnim;

    [SerializeField]
    GameObject particles1;

    [SerializeField]
    GameObject particles2;

    [SerializeField]
    GameObject deathParticles;

    public float timeExpire;

    public float timeToGameOver;

    public float timeToStopGravity;

    public float timeStopAllActions;

    bool hurting;
    bool showDead;
    // Use this for initialization
    void Start () {

        invulnerable = false;
        invulnerableCount = 0;
        shake = false;
        hurting = false;
        showDead = false;

        if(GameObject.Find("GameManager") != null)
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        cameraShake = Camera.main.GetComponent<CameraShake>();
        cameraController = Camera.main.GetComponent<CameraController>();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        savedColor = spriteRenderer.color;

        lifeCount = life.Length - 1;
        numberLifes = life.Length - 1;

        rb = GetComponent<Rigidbody2D>();

        playerScript = GetComponent<Player>();
        inputScript = GetComponent<PlayerInput>();

        playerAnim = GetComponent<PlayerAnim>();
    }
	
	// Update is called once per frame
	void Update () {      

        if (rb.velocity.y <= decrementImpulse && lifeCount >= 0)
        {
            playerScript.enabled = true;
            inputScript.enabled = true;
        }       
        
        if (shake)
        {
            timer += Time.deltaTime;
            GamePad.SetVibration(0, quantityVibration, quantityVibration);            
        }

        if (hurting && lifeCount >= 0)
        {
            timerStop += Time.deltaTime;
            //playerScript.enabled = false;
            inputScript.enabled = false;
        }

        if(timerStop >= timeStopAllActions && lifeCount >= 0)
        {
            timerStop = 0;
            hurting = false;
            //playerScript.enabled = true;
            inputScript.enabled = true;
            playerAnim.Hurt(false);
        }

        if (timer >= timeVibration)
        {
            timer = 0;
            shake = false;
            GamePad.SetVibration(0, 0, 0);
        }
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
    Función que controla la cantidad de vida que queremos restar al jugador 
 */

    /// <summary>
    /// Función que controla la cantidad de vida que queremos restar al jugador 
    /// </summary>
    public void ResetBlur()
    {
        //life[lifeCount].SetActive(false);
        //lifeCount--;
        makeDamage(1);
    }
    
    /// <summary>
    /// Funcion que se encarga de restar vida y desactivar los corazones del HUD en funcion del parametro recibido
    /// esto se aplicara cuando el personaje no este en estado invulnerable
    /// tambien aplica una fuerza en la direccion contraria de donde el personaje recibio el daño
    /// comprueba si la vida llega a cero y toma todas las acciones necesarios para realizar el gameover.
    /// </summary>
    /// <param name="damage"></param>
    public void makeDamage(int damage)
    {
        if (damage == 4 || damage == 5)
        {
            if (playerScript.getDireccion() == 1)
                rb.AddForce(new Vector2(-damageDisInstantForceX, damageDisInstantForceY), ForceMode2D.Impulse);

            if (playerScript.getDireccion() == -1)
                rb.AddForce(new Vector2(damageDisInstantForceX * 3, damageDisInstantForceY), ForceMode2D.Impulse);

            playerScript.setPermitido(false);
            inputScript.enabled = false;
        }

        //solo hacemos daño si no estamos en estado invulnerable
        if (!invulnerable)
        {            
            hurting = true;
            shake = true;

            if (playerScript.getDireccion() == 1 && lifeCount >= 0 && damage != 4 ||damage != 5)
            {
                //playerScript.enabled = false;
                inputScript.enabled = false;
                rb.AddForce(new Vector2(-damageDisForceX, damageDisForceY), ForceMode2D.Impulse);
            }

            else if (playerScript.getDireccion() == -1 && lifeCount >= 0 && damage != 4 || damage != 5)
            {
                //playerScript.enabled = false;
                inputScript.enabled = false;
                rb.AddForce(new Vector2(damageDisForceX, damageDisForceY), ForceMode2D.Impulse);
            }          

            playerAnim.RunToIdl();
            playerAnim.Hurt(true);            

            for (int i = 0; i < damage && lifeCount >= 0; i++)
            {
                life[lifeCount].SetActive(false);
                lifeCount--;
                StartCoroutine("InvulnerableColor");
                cameraShake.Shake();
                inputScript.PlayClipHurt();
            }

            invulnerable = true;
        }
       
        if (lifeCount < 0)
        {
            if(!showDead)
            {
                GameObject gb = Instantiate(deathParticles, transform.position, transform.rotation);
                Destroy(gb, 1);
                showDead = true;
            }

            //congelar camara
            cameraController.SetCameraState("Camera/BlockBoth");

            playerAnim.setFalseAllAnimations();
            playerAnim.GameOver(true);

            //cargar gameover o lo que proceda 
            Invoke("StopMovement", timeToStopGravity);
            Invoke("ExecuteDeath", timeExpire);
            Invoke("DoGameOver", timeToGameOver);
            //gameManager.loadGameOver();
            rb.velocity = Vector3.zero;
        }
    }

    void ExecuteDeath()
    {      
        particles1.SetActive(false);
        particles2.SetActive(false);
        
        playerAnim.death(true);
        Invoke("deathtofalse", 0.1f);
    }

    void deathtofalse()
    {
        playerAnim.death(false);
    }

    void StopMovement()
    {        
        playerScript.enabled = false;
        inputScript.enabled = false;
    }

    void DoGameOver()
    {        
        gameManager.loadGameOver();
        showDead = false;

        cameraController.RestartCamera();
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


    /// <summary>
    /// funcion que añade vida en funcion del parametro recibido
    /// </summary>
    /// <param name="cure"></param>
    public void cureLife(int cure)
    {
        playerAnim.death(false);
        //si la vida esta incompleta entonces curamos
        if (lifeCount < numberLifes)
        {
            int count = 0;
            for(int i = lifeCount; count < cure; i++)
            {
                lifeCount++;
                count++;
                life[lifeCount].SetActive(true);
            }
        }

    }

    /// <summary>
    /// Funcion que indica si el jugador esta en estado invulnerable
    /// </summary>
    /// <returns></returns>
    public bool getInvulnerable()
    {
        return invulnerable;
    }

    public void setInvulnerable(bool value)
    {
        invulnerable = value;
    }

    /// <summary>
    /// Funcion que indica el numero de vidas que le quedan al jugador
    /// </summary>
    /// <returns></returns>
    public int getLifeCount()
    {
        return lifeCount;
    }
}
