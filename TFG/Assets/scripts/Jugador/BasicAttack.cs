using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour {

    [SerializeField]
    float lifeSeconds;

    public bool isAttacking { get; set; }

    [SerializeField]
    float cargaAtaque;

    [SerializeField]
    GameObject basicAttack;

    GameObject prueba;

    [SerializeField]
    float bulletSpeed;

    Transform playerTransform;
    Player player;

	void Start ()
    {
        playerTransform = GameObject.Find("Personaje").transform;
        player = playerTransform.gameObject.GetComponent<Player>();
    }
	
    public void Attack(Vector3 direction)
    {
        if(!isAttacking)
        {
            prueba = Instantiate(basicAttack, playerTransform.position, Quaternion.identity);
            prueba.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            Invoke("StopAttack", lifeSeconds);
            player.Shoot(cargaAtaque);
            isAttacking = true;
        }
    }

    public void CancelAttack()
    {
        StopAllCoroutines();
        StopAttack();
    }

    void StopAttack()
    {
        isAttacking = false;

        if(prueba != null)
            Destroy(prueba);
    }
}
