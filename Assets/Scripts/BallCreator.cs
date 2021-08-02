using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    float timer = 0;
    public static Vector3 ballTargetPosition;
    // Start is called before the first frame update
    void Start()
    {
        ballTargetPosition = GameObject.Find("BallTarget").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CreateBall();
    }
    //Creating ball per 3 second.
    void CreateBall()
    {
        timer += Time.deltaTime;
        if (timer>=3f)
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
