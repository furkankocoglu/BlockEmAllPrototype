using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform characterTransform;
    Vector3 offset;
    [SerializeField]
    float followSpeed;
    void Start()
    {
        characterTransform = GameObject.Find("Character").transform.GetChild(5);// to follow center ragdoll object
        //offset from character to camera
        offset = new Vector3(transform.position.x-characterTransform.position.x,transform.position.y-characterTransform.position.y,transform.position.z-characterTransform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Control.firsTouch)
        {
            transform.position = Vector3.MoveTowards(transform.position, characterTransform.position + offset, followSpeed * Time.deltaTime);// smooth camera follow with first offset position.
        }        
    }
}
