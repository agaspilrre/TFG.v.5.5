using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CLASE ENCARGADA DE GUARDAR TODOS LOS CHECKPOINT DEL NIVEL
/// </summary>
public class CheckPointManager : MonoBehaviour {

    // Use this for initialization
    /// <summary>
    /// Array de transform que guarda los transform de todos los checkpoints del nivel
    /// Hay que asignarselos en el inspector
    /// </summary>
    public Transform[] CheckPoints;

	
	
	
    /// <summary>
    /// Devuelve el transform del checkpoint indicado como parametro
    /// </summary>
    /// <param name="CheckPoint"></param>
    /// <returns></returns>
    public Transform GetCheckPoint(int CheckPoint)
    {
        return CheckPoints[CheckPoint];
    }
}
