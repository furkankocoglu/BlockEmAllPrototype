using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{        
    float currentLerpTime;
    [SerializeField]
    float lerpTime;
    bool lerpOver = false;
    private void Start()
    {        
        //calculating force to reach target, not working atm.
        //Vector3 calculatedForce = new Vector3((BallCreator.ballTargetPosition.x-transform.position.x)*lerpTime+lerpTime*Physics.gravity.y*5f
        //    ,(BallCreator.ballTargetPosition.y-transform.position.x) * lerpTime+lerpTime*Physics.gravity.y*5f,0);
        //Debug.Log(calculatedForce);
        //ballRigidbody.AddForce(calculatedForce,ForceMode.Impulse);
    }
    private void Update()
    {

        BallToTarget();

    }
    //Throw Ball To Target Position with sootherstep effect.
    void BallToTarget()
    {
        if (!lerpOver)
        {

            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }
            float t = currentLerpTime / lerpTime;
            //t=t*t*t * (t * (6f * t - 15f) + 10f) smootherstep function
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(transform.position, BallCreator.ballTargetPosition, t);
            if (Vector2.Distance(transform.position, BallCreator.ballTargetPosition) <= 1)
            {
                lerpOver = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //checking whole colliders in character, if collission anyone stop lerp.
        foreach (CapsuleCollider item in Control.ragdollCapsuleColliders)
        {
            if (collision.collider==item)
            {
                lerpOver = true;
            }
        }       
    }
}
