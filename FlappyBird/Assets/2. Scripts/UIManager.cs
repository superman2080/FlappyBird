using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] score = new Image[3];
    public Sprite[] numbers= new Sprite[10];

    private PlayerCtrl player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("PLAYER").GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
