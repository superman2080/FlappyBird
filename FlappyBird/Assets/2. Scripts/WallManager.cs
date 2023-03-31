using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class WallManager : MonoBehaviour
{
    public GameObject wall;
    public float createInterval;
    public GameObject pool;
    public GameObject spawnPos;
    [Range(0, 3f)]
    public float spawnY;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WallCor(createInterval));
    }

    IEnumerator WallCor(float t)
    {
        while (true)
        {
            yield return new WaitForSeconds(t);
            CreateWall();
        }
    }

    void CreateWall()
    {
        //풀을 순회하면서 꺼진 오브젝트를 찾음
        for (int i = 0; i < pool.transform.childCount; i++)
        {
            if (pool.transform.GetChild(i).gameObject.activeSelf == false)
            {
                pool.transform.GetChild(i).gameObject.SetActive(true);
                pool.transform.GetChild(i).localPosition = new Vector2(spawnPos.transform.position.x, Random.Range(-spawnY, spawnY));
                return;
            }
        }
        //풀에 오브젝트가 없으면 생성
        GameObject temp = Instantiate(wall);
        temp.transform.parent = pool.transform;
        temp.transform.localPosition = new Vector2(spawnPos.transform.position.x, Random.Range(-spawnY, spawnY));
    }


}
