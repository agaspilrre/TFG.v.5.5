using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// clase controla el prefab cameratrigger centra la camara en otro objeto
/// </summary>
public class CameraTrigger : MonoBehaviour {

    /// <summary>
    /// referencia al target de la camara
    /// </summary>
    CameraTarget target;

    /// <summary>
    /// objetivo centrar el trigger
    /// </summary>
    Transform child;

    /// <summary>
    /// porcentaje de desvio
    /// </summary>
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

    /// <summary>
    /// setea las variables de los target al entrar en triggers
    /// </summary>
    public void Setters()
    {
        target.SetPercent(percent);
        target.SetFocusPosition(child.position);
        target.SetIsTrigger(true);
        target.numberOfTriggers++;
    }
}
