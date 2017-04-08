using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {   

    void Update()
    {       
        if (Input.GetKey(KeyCode.U) && lanzar)
        {
            transform.Translate(Vector3.right* speed * Time.deltaTime);
            Unparent(playerGO, this.gameObject);
        }        
    }

    public Rigidbody2D playerRb;
    public Transform playerTrf;
    public GameObject playerGO;
    public float speed = 10f;
    public bool lanzar = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Parent(playerGO, this.gameObject);
            playerRb.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void Parent(GameObject parentOb, GameObject childOb)
    {
        childOb.transform.parent = parentOb.transform;
        lanzar = true;
    }

    private void Unparent(GameObject parentOb, GameObject childOb)
    {
        childOb.transform.parent = null;
    }

}
