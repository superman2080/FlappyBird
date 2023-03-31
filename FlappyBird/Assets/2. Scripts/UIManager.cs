using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //public Image[] score = new Image[3];
    //public Sprite[] numbers= new Sprite[10];
    public GameObject endUI;

    public GameObject startUI;
    public TextMeshProUGUI score;
    public TextMeshProUGUI max;

    private PlayerCtrl player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
        startUI.SetActive(true);
        endUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDied == true)
        {
            endUI.SetActive(true);
            score.text = player.score.ToString();
            if (PlayerPrefs.GetInt("Max") < player.score)
            {
                PlayerPrefs.SetInt("Max", player.score);
            }
            max.text = PlayerPrefs.GetInt("Max").ToString();
        }
    }
    public void StartButton()
    {
        GameManager.instance.isStart = true;
        startUI.SetActive(false);
        player.OnStartGame();
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("InGame");
    }
}
