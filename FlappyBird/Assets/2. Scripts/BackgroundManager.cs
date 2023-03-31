using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] background = new GameObject[2];
    [Range(0f, 0.1f)]
    public float speed;
    private int idx;
    private Vector3 interval = new Vector3(0, 0, 10);

    // Start is called before the first frame update
    void Start()
    {
        idx = 0;
        background[0].transform.localPosition = new Vector3(0, 0, 10);
        interval.x = background[0].GetComponent<Renderer>().bounds.size.x - 0.001f;
        background[1].transform.localPosition = interval;
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
