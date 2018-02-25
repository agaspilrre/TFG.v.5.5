using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaNPC : MonoBehaviour
{
    [SerializeField]
    float minIntensity;
    [SerializeField]
    float maxIntensity;

    Light myLight;

    HabilityBar habilityBar;

	void Start ()
    {
        myLight = gameObject.GetComponent<Light>();
        habilityBar = GameObject.Find("Personaje").GetComponent<HabilityBar>();
    }
	

	void Update ()
    {
        UpdateMana();
	}

    void UpdateMana()
    {
        //float auxVar = habilityBar.GetStamina();

        //auxVar = ((auxVar / 100) * (maxIntensity - minIntensity)) + minIntensity;

        //myLight.intensity = auxVar;
    }
}
