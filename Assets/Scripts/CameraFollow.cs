using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 2.5f;
    public Vector3 DistanceToPlayer;
    private Vector2 movement;

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + DistanceToPlayer;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed*Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        //UP
        /*if (movement.x == 0 && movement.y > 0)
            desiredPosition = target.position + DistanceToPlayer + new Vector3(5f * Time.deltaTime, 0, 5f * Time.deltaTime);
        //RIGHT
        else if (movement.x > 0 && movement.y == 0)
            desiredPosition = target.position + DistanceToPlayer + new Vector3(-5f * Time.deltaTime, 0, -5f * Time.deltaTime);
        //DOWN
        else if (movement.x == 0 && movement.y < 0)
            firePoint.transform.position = transform.position + new Vector3(0f, -0.8f);
        //LEFT
        else if (movement.x < 0 && movement.y == 0)
            firePoint.transform.position = transform.position + new Vector3(-0.7f, -0.3f);
        */
    }

}
