using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE REINICIAR LA ESCENA O CAMBIAR ESCENA DESPUES DE QUE EL TIEMPO DEL FADE HAYA TRANSCURRIDO
/// </summary>
public class FadeManagger : MonoBehaviour {

    /// <summary>
    /// Duracion del fade
    /// </summary>
    public float fadeDuration;

    void Start()
    {
        StartCoroutine("goTo");
    }

    /// <summary>
    /// Corrutina que permite cargar la escena al cabo de los segundos del fadeDuration
    /// </summary>
    /// <returns></returns>
    IEnumerator goTo()
    {
        yield return new WaitForSeconds(fadeDuration);


        SceneManager.LoadScene("scenne_1");
    }



}
