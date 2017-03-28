using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

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
