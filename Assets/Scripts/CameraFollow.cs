using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera will follow this object
    [SerializeField] private Transform Target;
    [SerializeField] private float SmoothTime = 1f;
    private Transform camTransform;
    // offset between camera and target
    private Vector3 Offset;
    // change this value to get desired smoothness
    //private float SmoothTime = 0.25f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        camTransform = Camera.main.transform;
        Offset = camTransform.position - Target.position;
    }

    private void Update()
    {
        // update position
        Vector3 targetPosition = Target.position + Offset;
        //targetPosition.x = 0f;
        Vector3 currPos = camTransform.position;
        currPos.z = targetPosition.z;
        camTransform.position = currPos;
        camTransform.position = Vector3.Lerp(transform.position, targetPosition, SmoothTime * Time.deltaTime);

        //camTransform.position = targetPosition;
    }
}
