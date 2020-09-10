using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject movingObj;
    void Start()
    {
        StartCoroutine(MoveMap());
        StartCoroutine(SetTree());
    }

    IEnumerator SetTree()
    {
        while(true)
        {
            Vector3 pos = new Vector3(11, Random.Range(3f, -1.5f), 0);
            GameObject tree = Instantiate(treePrefab, pos, transform.rotation) as GameObject;
            tree.transform.parent = movingObj.transform;
            yield return new WaitForSeconds(2.5f);
        }
    }

    IEnumerator MoveMap()
    {
        while (true)
        {
            Vector3 pos = movingObj.transform.position;
            pos.x -= 4 * Time.deltaTime;
            movingObj.transform.position = pos;
            yield return 0;
        }
    }
    void Update()
    {
        
    }
}
