using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public float forwardSpeed;
    public float shift;
    public float nextShift;
    public bool stop;
    public float rotationAngle = 15f; // Угол поворота в зависимости от движения
    public float rotationSpeed = 5f;  // Скорость поворота
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (!stop)
        {
            var forwardDirection = transform.forward * forwardSpeed;
            var velocity = Vector3.forward * forwardSpeed;
            velocity.x = shift / Time.fixedDeltaTime;
            rigidbody.velocity = new Vector3(velocity.x, rigidbody.velocity.y, forwardDirection.z);

            // Плавный поворот в зависимости от смещения
            float targetRotationY = shift != 0 ? rotationAngle * Mathf.Sign(shift) : 0;
            Quaternion targetRotation = Quaternion.Euler(0, targetRotationY, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            shift = nextShift;
            nextShift = 0;
        }
        else
        {
            rigidbody.isKinematic = true;
        }
    }

    public void MoveDiag(float shift)
    {
        nextShift += shift;
    }
}