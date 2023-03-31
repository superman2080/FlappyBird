using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public int score;
    [Range(1f, 10f)]
    public float jumpPow;
    public Rigidbody2D rb2d;
    [Header("Associate about rotation")]
    [Range(0f, 1f)]
    public float rotSpeed;
    public float initialRot;
    private float zRot;
    public bool isDied;

    public GameObject origin;
    public GameObject moveTo;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDied && GameManager.instance.isStart)
        {
            transform.eulerAngles = new Vector3 (0f, 0f, zRot);
            zRot -= rotSpeed;
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                zRot = initialRot;
                rb2d.velocity = Vector3.zero;
                rb2d.AddForce(Vector2.up * jumpPow, ForceMode2D.Impulse);
            }
        }
    }

    public void OnStartGame()
    {
        StartCoroutine(MovePlayerCor(0.5f));
    }

    IEnumerator MovePlayerCor(float time)
    {
        float t = 0;
        while (true)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(origin.transform.position, moveTo.transform.position, t / time);
            rb2d.velocity = Vector2.zero;
            if (t > time)
                break;
            yield return null;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WALL"))
        {
            isDied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SCORE"))
        {
            if (!isDied)
                score++;
        }
    }
}
