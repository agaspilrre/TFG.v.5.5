using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour {

    [SerializeField]
    float size;
    [SerializeField]
    float resizeSpeed;

    Camera mainCamera;
    [SerializeField] Camera secondCamera;

    public
    float savedSize;//saves the start size
    public
    float auxSize;

    enum State
    {
        changing, waiting
    }
    State myState;

    public
    bool increasing;

	void Start ()
    {
        mainCamera = Camera.main;
        savedSize = mainCamera.orthographicSize;

        auxSize = size;

        myState = State.waiting;

        increasing = size < savedSize ? true : false;//if start size is higher 
	}

	void Update ()
    {
        if(myState == State.changing)
        {
            if (increasing)
            {
                mainCamera.orthographicSize += Time.deltaTime * resizeSpeed;
                secondCamera.orthographicSize += Time.deltaTime * resizeSpeed;

                if (mainCamera.orthographicSize >= size && mainCamera.orthographicSize >= savedSize)
                    myState = State.waiting;
            }
            else
            {
                mainCamera.orthographicSize -= Time.deltaTime * resizeSpeed;
                secondCamera.orthographicSize -= Time.deltaTime * resizeSpeed;

                if (mainCamera.orthographicSize <= size && mainCamera.orthographicSize <= savedSize)
                    myState = State.waiting;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            increasing = !increasing;
            myState = State.changing;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            increasing = !increasing;
            myState = State.changing;
        }
    }
}
