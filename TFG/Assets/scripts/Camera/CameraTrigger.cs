using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

    CameraTarget target;
    Transform child;

    [SerializeField][Range(0,1)]
    float percent = 0.5f;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.Find("PlayerTarget").GetComponent<CameraTarget>();
        child = this.gameObject.transform.GetChild(0);
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Personaje")
        {
            Setters();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Personaje")
        {
            target.numberOfTriggers--;

            if (target.numberOfTriggers == 0)
            {
                target.SetIsTrigger(false);
            }
        }
    }

    public void Setters()
    {
        target.SetPercent(percent);
        target.SetFocusPosition(child.position);
        target.SetIsTrigger(true);
        target.numberOfTriggers++;
    }
}
