using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    /// <summary>
    /// referencias al jugador y al objetivo de la camara
    /// </summary>
    Transform player;
    Transform target;
    /// <summary>
    /// numero de triggers en los que se encuentra
    /// </summary>
    public int numberOfTriggers { get; set; }

    /// <summary>
    /// velocidad de reajuste
    /// </summary>
    [SerializeField]
    float speed = 10;

    /// <summary>
    /// posicion del objetivos en el trigger
    /// </summary>
    Vector3 focusPosition;

    /// <summary>
    /// porcentaje de desvio
    /// </summary>
    float percent;

    /// <summary>
    /// estado si la camara esta en un trigger
    /// </summary>
    enum State
    {
        triggered,
        noTriggered
    }

    /// <summary>
    /// estado de la camara
    /// </summary>
    State state;

    void Start()
    {
        state = State.noTriggered;

        numberOfTriggers = 0;

        player = GameObject.Find("Personaje").GetComponent<Transform>();
        target =this.GetComponent<Transform>();
    }

    void Update()
    {
        if (state == State.triggered)
            UpdatePosition();
        else
            NotTriggered();
    }

    /// <summary>
    /// resettarget position
    /// </summary>
    void NotTriggered()
    {
        target.position = player.position;
    }

    /// <summary>
    /// move target to new position
    /// </summary>
    public void UpdatePosition()
    {
        target.position = Vector3.MoveTowards(target.position,Vector3.Lerp(player.position, focusPosition, percent), speed * Time.deltaTime);
    }

    /// <summary>
    /// set focus point
    /// </summary>
    /// <param name="focus"></param>
    public void SetFocusPosition(Vector3 focus)
    {
        focusPosition = focus;
    }  

    /// <summary>
    /// cambia estado 
    /// </summary>
    /// <param name="aux"></param>
    public void SetIsTrigger(bool aux)
    {
        if (aux)
            state = State.triggered;
        else
            state = State.noTriggered;
    }

    /// <summary>
    /// actualiza el porcentaje del trigger
    /// </summary>
    /// <param name="aux"></param>
    public void SetPercent(float aux)
    {
        percent = aux;
    }
}
