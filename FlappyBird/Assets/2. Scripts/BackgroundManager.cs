using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] background = new GameObject[2];
    [Range(0f, 0.1f)]
    public float speed;
    private int idx;
    private Vector2 interval = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        idx = 0;
        interval.x = background[0].GetComponent<Renderer>().bounds.size.x - 0.001f;
        background[0].transform.position = Vector2.zero;
        background[1].transform.position = interval;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var bg in background)
        {
            bg.transform.Translate(new Vector2(-speed, 0));
        }
        if (background[idx].transform.position.x <= 0)
        {
            if(idx == 0) idx = 1;
            else idx = 0;


            background[idx].transform.position = interval;
        }
    }
}
