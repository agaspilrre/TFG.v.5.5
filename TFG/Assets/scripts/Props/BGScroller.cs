using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    public float ScrollSpeed;

    private Vector3 startPosition;

    [SerializeField]
    private float tileSize;

    Transform roadPosition;

    void Start()
    {
        
        roadPosition = transform;
        startPosition = roadPosition.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * ScrollSpeed, tileSize);
        transform.position = startPosition - Vector3.right * newPosition;
    }
}
