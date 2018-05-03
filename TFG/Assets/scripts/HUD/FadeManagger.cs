using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// CLASE ENCARGADA DE REINICIAR LA ESCENA O CAMBIAR ESCENA DESPUES DE QUE EL TIEMPO DEL FADE HAYA TRANSCURRIDO
/// </summary>
public class FadeManagger : MonoBehaviour {

    public float fadeDuration;

    void Start()
    {

        StartCoroutine("goTo");

    }

    IEnumerator goTo()
    {
        yield return new WaitForSeconds(fadeDuration);


        SceneManager.LoadScene("scenne_1");
    }



}
