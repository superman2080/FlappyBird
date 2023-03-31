using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallCtrl : MonoBehaviour
{
    [Range(0f, 0.1f)]
    public float speed;
    private Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        moveDir = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("DESPAWNER"))
        {
            Debug.Log("디스포너 충돌");
            gameObject.SetActive(false);
        }
    }

}
