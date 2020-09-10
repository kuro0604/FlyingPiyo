using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject movingObj;
    public float speed;
    //スコアの目標値
    public int targetScore;
    public int speedUpCount;
    public float addSpeed;
    public float waitTime;
    public ScoreScript scoreScript;
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
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator MoveMap()
    {
        while (true)
        {
            if(scoreScript.score == targetScore)
            {
                DownWaitTime();
            }
            Vector3 pos = movingObj.transform.position;
            pos.x -= speed * Time.deltaTime;
            movingObj.transform.position = pos;
            yield return 0;
        }
    }

    private void DownWaitTime()
    {
        waitTime -= 0.1f;
        speedUpCount++;
        targetScore = 10 * (speedUpCount + 1);
    }
    
    
}
