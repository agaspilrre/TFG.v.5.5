using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAbsorb : MonoBehaviour {

    /*ESTAS VARIABLES  Y EL CODIGO COMENTADO SON PARA HACER QUE EL OBJETO FLOTE, PERO NO HE CONSEGUIDO MOVERLO CON EL OBJETO LEVITANDO, POR ESO EL OBJETO ES ESTATICO*/
    //public float verticalSpeed;
    //public float amplitude;
    //private Vector3 tempPosition;

    private new Transform transform;
    private new Collider2D collider;    
    public Absorb objeto;
    public Player player;
    public Rigidbody2D playerRb;
    public Transform playerTrf;
    private float escala = 0.5f;

    public float speed = 0.05f;   

    // Use this for initialization
    void Start() {

        transform = GetComponent<Transform>();
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;       

        //tempPosition = transform.position;
    }

    /*private void FixedUpdate()
    {        
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude -3f;
        transform.position = tempPosition;
    }*/

    void Update() {         

        if (objeto.canAbsorb)
        {
            if (Input.GetKey(KeyCode.C))
            {
                collider.isTrigger = false;
                player.permitido = false;

                if (player.getDireccion() == 1)
                {                     
                   escala = escala + (-speed * Time.deltaTime);
                   transform.localScale = new Vector3(escala, escala, escala);

                   if (escala < 0.1)                       
                       escala = 0.1f;                           
                       
                   //le doy movimiento, la velocidad se controla con el deltaTime
                   transform.Translate(-speed * 2 * Time.deltaTime, 0, 0);            
                }

                else if (player.getDireccion() == -1)
                {
                    escala = escala - (speed * Time.deltaTime);
                    transform.localScale = new Vector3(escala, escala, escala);

                    if (escala < 0.1)
                        escala = 0.1f;

                    //le doy movimiento, la velocidad se controla con el deltaTime
                    transform.Translate(speed * 2 * Time.deltaTime, 0, 0);
                }
            }
        }
    }   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
                Destroy(this.gameObject);
                player.permitido = true;
        }
    }
    /*IEnumerator Coroutine(float waitTime)
    {
        while(true)
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(waitTime);
    }*/
}    


