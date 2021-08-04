using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    float timer = 0;
    public static Vector3 ballTargetPosition;    
    void Start()
    {
        ballTargetPosition = GameObject.Find("BallTarget").transform.position;//getting ball target position after start game.
    }
        
    void Update()
    {
        CreateBall();
    }
    //Creating one ball per 3 seconds and destroying 10 seconds later.
    void CreateBall()
    {
        timer += Time.deltaTime;
        if (timer>=3f)
        {
            Destroy(Instantiate(ballPrefab, transform.position, Quaternion.identity),10f);
            timer = 0;
        }
    }
}
