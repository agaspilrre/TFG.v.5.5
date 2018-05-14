using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour {
    [SerializeField]
    Screens[] screens;

    public static ScreensManager instance;

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