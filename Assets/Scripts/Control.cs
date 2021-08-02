using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Vector2 firstTouchPosition;
    [SerializeField]
    float force;    
    Rigidbody characterRigidbody;
    Animator characterAnimator;
    public static CapsuleCollider[] ragdollCapsuleColliders;
    public static bool firsTouch = false;    
    void Start()
    {
        ragdollCapsuleColliders = GetComponentsInChildren<CapsuleCollider>(); // getting all ragdoll collider to check collision
        characterRigidbody = transform.GetChild(5).GetComponent<Rigidbody>();       // center rigidbody 
        characterAnimator = GetComponent<Animator>();        
    }
   
    void Update()
    {
        ForceToCharacter();
    }
    //Checking touch to get finger rotation.
    Vector2 FingerRotation()
    {
        Vector2 returnVector=Vector2.zero;
        if (Input.touchCount > 0) // touched screen
        {
            if (!firsTouch)
            {
                characterAnimator.enabled = false;//disabled animator to use ragdoll.
                firsTouch = true; // to stop repeat disable animator and work camera follow
            }
            Touch isTouch = Input.GetTouch(0);
            if (isTouch.phase == TouchPhase.Began) //when first touch screen that works
            {
                firstTouchPosition = Input.GetTouch(0).position;
            }            
            else if (isTouch.phase == TouchPhase.Ended) //when touch to screen end that works
            {
                returnVector = Input.GetTouch(0).position-firstTouchPosition; // returning finger rotation
            }

        }
        return returnVector;
    }
    // add force to target rotation for move character
    void ForceToCharacter()
    {
        Vector2 fingerRotation = FingerRotation();
        if (fingerRotation != Vector2.zero)
        {     
            characterRigidbody.velocity = Vector3.zero;
            characterRigidbody.AddForce(fingerRotation* force);
        }
    }
}
