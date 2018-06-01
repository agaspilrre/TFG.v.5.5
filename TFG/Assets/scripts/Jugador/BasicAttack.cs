using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour {

    [SerializeField]
    float lifeSeconds;

    public bool isAttacking { get; set; }
    public bool isCharging { get; set; }

    [SerializeField]
    [Range(0, 1)]
    float decreaseSpeed;

    float timer;

    [SerializeField]
    float cargaAtaque;

    [SerializeField]
    GameObject basicAttack;

    public GameObject rotacionDerecho;
    public GameObject rotacionIzquierdo;

    GameObject prueba;

    [SerializeField]
    float bulletSpeed;

    /// <summary>
    /// posicion del player
    /// </summary>
    Transform playerTransform;
    /// <summary>
    /// referencia al jugadir
    /// </summary>
    Player player;

    /// <summary>
    /// referencia a los input
    /// </summary>
    PlayerInput playerInput;

    /// <summary>
    /// referencia a los poderes
    /// </summary>
    Poderes poderes;

    /// <summary>
    /// flecha de apuntado
    /// </summary>
    [SerializeField]
    GameObject directionObject;

    /// <summary>
    /// direccion del disparo
    /// </summary>
    public Vector3 direction { get; set; }

	void Start ()
    {
        playerTransform = GameObject.Find("Personaje").transform;
        playerInput = GameObject.Find("Personaje").GetComponent<PlayerInput>();
        poderes = GameObject.Find("Personaje").GetComponent<Poderes>();
        player = playerTransform.gameObject.GetComponent<Player>();

        timer = 0;
    }

    void Update()
    {
        
        if (isCharging)
        {
            timer += Time.deltaTime;

            float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            directionObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            if(rot_z >= 90)
            {
                rot_z = -180 + rot_z;
            }

            rotacionDerecho.transform.rotation = Quaternion.Euler(0f, 0f,rot_z);
            rotacionIzquierdo.transform.rotation = Quaternion.Euler(0f, 0f,rot_z);
        }
    }

    void LateUpdate()
    {
        if (prueba)
        {
            if (prueba.GetComponent<ParticleSystem>().particleCount == 0)
            {
                playerInput.PlayClipShotHit();
                isAttacking = false;
                Destroy(prueba);
                StopAllCoroutines();
            }
        }
    }

    /// <summary>
    /// cancela la carga y dispara
    /// </summary>
    public void StopCharging()
    {       
        if (!isAttacking && !playerInput.getIsJumping() && poderes.dashUse && isCharging && !player.wallSliding)
        {
            isCharging = false;
            directionObject.SetActive(false);
            playerInput.AttackAnimations(false);
            player.speedAttacking = 1;
            Attack();
        }
    }

    /// <summary>
    /// carga el ataque
    /// </summary>
    public void Charge()
    {
        if (!isAttacking && !playerInput.getIsJumping() && poderes.dashUse && !player.wallSliding)
        {
            isCharging = true;
            player.speedAttacking = decreaseSpeed;
            directionObject.SetActive(true);
            playerInput.AttackAnimations(true);
        }
    }
   
    /// <summary>
    /// dispara la bala
    /// </summary>
    public void Attack()
    {
        if(!isAttacking)
        {
            playerInput.PlayClipShoot();
            prueba = Instantiate(basicAttack, playerTransform.position, Quaternion.identity);
            prueba.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            Invoke("StopAttack", lifeSeconds);
            isAttacking = true;
        }
    }

    /// <summary>
    /// cancela la carga y para las corrutinas
    /// </summary>
    public void CancelAttack()
    {
        StopAllCoroutines();
        StopAttack();
    }

    /// <summary>
    /// finaliza el ataque y destruye la bala
    /// </summary>
    void StopAttack()
    {
        isAttacking = false;
        
        if (prueba != null)
            Destroy(prueba);
    }
}
