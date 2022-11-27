using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_CameraMovement : MonoBehaviour
{
    [Header("What To Follow")]
    public Transform target;
    
    [Header("Follow Speed")]
    [Tooltip("The lower this is the faster it goes")]
    public float smoothSpeed = 0.125f;
    
    [Header("Camera Location")]
    [Tooltip("The position from the target it wants to look at")]
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}