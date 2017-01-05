using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAbsorb : MonoBehaviour {

    /*ESTAS VARIABLES  Y EL CODIGO COMENTADO SON PARA HACER QUE EL OBJETO FLOTE, PERO NO HE CONSEGUIDO MOVERLO CON EL OBJETO LEVITANDO, POR ESO EL OBJETO ES ESTATICO*/
    //public float verticalSpeed;
    //public float amplitude;
    //private Vector3 tempPosition;

    private Transform transform;
    private Collider2D collider;
    private bool canAbsorb;
    public personajeMOV player;

    public float speed = 1f;   

    // Use this for initialization
    void Start() {

        transform = GetComponent<Transform>();
        collider = GetComponent<Collider2D>();
        canAbsorb = false;

        //tempPosition = transform.position;
    }

    /*private void FixedUpdate()
    {        
        tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed) * amplitude -3f;
        transform.position = tempPosition;
    }*/

    void Update() {

        if (canAbsorb)
        {
            if (Input.GetKey(KeyCode.C))
            {

                //reescalo el objeto por primera vez
                transform.localScale = new Vector3(0.2f, 0.2f, 1);

                //le doy movimiento, la velocidad se controla con el deltaTime
                transform.Translate(-speed * Time.deltaTime / 4, 0, 0);

                //cuando llega a cierta posicion se vuelve a reescalar para hacerlo mas pequeño
                if (transform.localPosition.x < -29.5f)
                {
                    transform.localScale = new Vector3(0.1f, 0.1f, 1);
                }

                //cuando su x es negativa se destruye
                if (transform.localPosition.x < -33.5f)
                    Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            canAbsorb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            canAbsorb = false;
        }
    }

    /*IEnumerator Coroutine(float waitTime)
    {
        while(true)
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        yield return new WaitForSeconds(waitTime);
    }*/
}    


