using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    Transform player;
    Transform target;

    [SerializeField]
    float speed = 10;

    Vector3 focusPosition;
    float percent;

    enum State{
        triggered,
        noTriggered
    }

    State state;

    void Start()
    {
        state = State.noTriggered;

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

    void NotTriggered()
    {
        target.position = player.position;
    }

    public void UpdatePosition()
    {
        target.position = Vector3.MoveTowards(target.position,Vector3.Lerp(player.position, focusPosition, percent), speed * Time.deltaTime);
    }

    public void SetFocusPosition(Vector3 focus)
    {
        focusPosition = focus;
    }

    public void SetIsTrigger(bool aux)
    {
        if (aux)
            state = State.triggered;
        else
            state = State.noTriggered;
    }

    public void SetPercent(float aux)
    {
        percent = aux;
    }
}
