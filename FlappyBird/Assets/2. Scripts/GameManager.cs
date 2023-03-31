using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStart;

    private void Awake()
    {
        if (instance != null)
            return;

        instance = this;

        Screen.SetResolution(1080, 1920, false);
        if (!PlayerPrefs.HasKey("Max"))
        {
            PlayerPrefs.SetInt("Max", 0);
        }
    }

    private void Update()
    {
        StartGame();
    }

    void StartGame() => Time.timeScale = isStart ? 1 : 0;

}
