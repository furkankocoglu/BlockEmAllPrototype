using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    Vector2 firstTouchPosition;
    [SerializeField]
    float force;    
    Rigidbody characterRigidbody;
    Animator characterAnimator;
    public static Collider[] ragdollCapsuleColliders;
    public static bool firsTouch = false;
    ArrayList points = new ArrayList();
    void Start()
    {
        ragdollCapsuleColliders = GetComponentsInChildren<Collider>();       //Getting ragdoll capsule colliders to check collission
        characterRigidbody = transform.GetChild(5).GetComponent<Rigidbody>();       // center rigidbody 
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
                firsTouch = true; // to stop repeat disable animator and work camera follow
            }
            Touch isTouch = Input.GetTouch(0);
            if (isTouch.phase == TouchPhase.Began) //when first touch screen that works
            {
                firstTouchPosition = Input.GetTouch(0).position;
                UIComponents.instance.hand.gameObject.SetActive(true);
                UIComponents.instance.hand.transform.position = firstTouchPosition;

            }
            else if (isTouch.phase==TouchPhase.Moved)//works while moving finger
            {
                Vector2 touchPos= Input.GetTouch(0).position;
                UIComponents.instance.hand.transform.position = touchPos;//change hand position to touch position
                DestroyPoints();
                CreatePoint(touchPos);
                
            }
            else if (isTouch.phase == TouchPhase.Ended) //when touch to screen end that works
            {
                returnVector = Input.GetTouch(0).position-firstTouchPosition; // returning finger rotation
                UIComponents.instance.hand.gameObject.SetActive(false);
                DestroyPoints();
            }

        }
        return returnVector;
    }
    // Creating red points to finger position;
    void CreatePoint(Vector2 touchPos)
    {
        if (Vector2.Distance(firstTouchPosition, touchPos) > 75)
        {
            Vector2 pointPos = firstTouchPosition;
            Vector2 pointRot = (touchPos - firstTouchPosition) / Vector2.Distance(touchPos, firstTouchPosition);
            for (int i = 0; i < Vector2.Distance(firstTouchPosition, touchPos) / 75; i++)
            {
                GameObject redPoint =
                Instantiate(UIComponents.instance.redPoint.gameObject, UIComponents.instance.pointParent.transform);
                points.Add(redPoint);
                redPoint.GetComponent<Image>().rectTransform.position = pointPos;
                pointPos += pointRot * 75;
            }

        }
    }
    // Destroing red points
    void DestroyPoints()
    {
        foreach (GameObject item in points)
        {
            Destroy(item);
        }
        points.Clear();
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
