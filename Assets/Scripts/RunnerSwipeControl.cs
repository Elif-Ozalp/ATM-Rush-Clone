using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerSwipeControl : MonoBehaviour
{
    
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance;
    
    
    Vector3 lastPosition = Vector3.zero;

  /*  private void FixedUpdate()
    {
        Vector3 parentPos = transform.position;
        
        transform.parent.position = new Vector3(
            parentPos.x,
            parentPos.y,
            parentPos.z + forwardSpeed * Time.deltaTime);
    }*/

    void Update()
    {
        Vector3 curPos = transform.position;
        
        if (Input.GetMouseButtonDown(0))
            lastPosition = Input.mousePosition;
    
        if (Input.GetMouseButton(0))
        {
            var currentPosition = Input.mousePosition;
            var deltaPosition = currentPosition-lastPosition;

            if (deltaPosition.x!=0)
            {
                if (Mathf.Abs(transform.position.x + deltaPosition.x * moveSpeed * Time.deltaTime) < 3.5f)
                {
                    transform.position = new Vector3(
                        transform.position.x + deltaPosition.x * moveSpeed * Time.deltaTime,
                        transform.position.y,
                        transform.position.z);
                
                }

                curPos = transform.position;
                if (curPos.x > stopDistance)
                {
                    curPos.x = stopDistance;
                    transform.position = curPos;
                }
                else if (curPos.x < -stopDistance)
                {
                    curPos.x = -stopDistance;
                    transform.position = curPos;
                }
            }

            lastPosition = currentPosition;
			
			if (Input.GetMouseButtonUp(0))
				deltaPosition = Vector3.zero;
            //Quaternion newRotation = Quaternion.Euler(0,touch.deltaPosition.x*rotationSpeed*Time.deltaTime,0);   
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, slerpEase);
        }
        else
        {
            //Quaternion newRotation = Quaternion.Euler(0,0,0);   
            //transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, slerpEase);
        }
            
        
    }
}