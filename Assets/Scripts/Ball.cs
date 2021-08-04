using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{        
    //float currentLerpTime;
    //[SerializeField]
    //float lerpTime;
    //bool lerpOver = false;
    Rigidbody ballRigidbody;
    bool canCount = true;
    private void Start()
    {        
        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.velocity = new Vector3(
            (BallCreator.ballTargetPosition.x - transform.position.x)*0.5f,
            (BallCreator.ballTargetPosition.y - transform.position.y)*(3f/2f) + Mathf.Sqrt(Physics.gravity.y*-1*ballRigidbody.mass),
            0);        
    }
    //private void Update()
    //{

        //BallToTarget();

    //}
    //Throw Ball To Target Position with sootherstep effect.
    //void BallToTarget()
    //{
    //    if (!lerpOver)
    //    {

    //        currentLerpTime += Time.deltaTime;
    //        if (currentLerpTime > lerpTime)
    //        {
    //            currentLerpTime = lerpTime;
    //        }
    //        float t = currentLerpTime / lerpTime;
    //        //t=t*t*t * (t * (6f * t - 15f) + 10f) smootherstep function
    //        t = t * t * t * (t * (6f * t - 15f) + 10f);
    //        transform.position = Vector3.Lerp(transform.position, BallCreator.ballTargetPosition, t);
    //        if (Vector2.Distance(transform.position, BallCreator.ballTargetPosition) <= 1)
    //        {
    //            lerpOver = true;
    //        }
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Counter" && canCount)
        {
            LevelManager.instance.CountBall();
            canCount = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //checking whole colliders in character, if collission anyone increase current ball count.
        if (canCount)
        {
            foreach (Collider item in Control.ragdollCapsuleColliders)
            {
                Debug.Log(item.gameObject.name);
            }
            foreach (Collider item in Control.ragdollCapsuleColliders)
            {
                if (collision.collider == item)
                {
                    LevelManager.instance.IncreaseBall();
                    canCount = false;
                    Debug.Log("sayac="+LevelManager.instance.ballCount);
                    break;
                }
            }
        }
        
    }
}
