using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE DESTRUIR UN OBJETO AL CABO DE DOS SEGUNDOS
/// </summary>
public class DestroyByTime : MonoBehaviour {

    /// <summary>
    /// Tiempo que tarda en destruirse
    /// </summary>
    float time = 2;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
