using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controlador de las pantallas del juego
/// </summary>
public class ScreensManager : MonoBehaviour {

    /// <summary>
    /// guardadas las pantallas
    /// </summary>
    [SerializeField]
    Screens[] screens;

    /// <summary>
    /// instancia
    /// </summary>
    public static ScreensManager instance;

    /// <summary>
    /// pantalla actual
    /// </summary>
    private byte index;

    private void Awake()
    {
        instance = this;
    }

    public byte Index
    {
        get
        {
            return index;
        }
        set
        {
            screens[Index].SetActive(false);
            index = value;
            screens[Index].SetActive(true);
        }
    }

    void Start()
    {
        Index = 0;

        //screens[Index].SetActive(true);
        for (int i = 1; i < screens.GetLength(0); i++)
            screens[i].SetActive(false);
    }
}
/// <summary>
/// clase con todas las pantallas
/// </summary>
[System.Serializable]
public class Screens
{
    [SerializeField]
    GameObject[] screensPrefabs;

    public void SetActive(bool active)
    {
        for(int i = 0; i < screensPrefabs.GetLength(0); i++)
        {
            screensPrefabs[i].SetActive(active);
        }
    }
}