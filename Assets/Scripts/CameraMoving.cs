using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed;
    public Vector3 offset; 
    private Vector3 velocity = Vector3.zero;  

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}