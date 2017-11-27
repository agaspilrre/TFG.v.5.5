using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartItem : MonoBehaviour {

    public bool haveThisStart;

	// Use this for initialization
	void Start () {

        if (haveThisStart)
        {
            Destroy(this.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //incrementar variable estatica
            fixedVar.totalStarts ++;
            //incrementar variable start manager
            //GameObject.Find("GameManager").GetComponent<StartsManager>().incrementNumberStarts();
            //poner variable a true de que ya tengo este objeto.
            haveThisStart = true;
            //destruir el objeto
            Destroy(this.gameObject);

        }
    }
}
