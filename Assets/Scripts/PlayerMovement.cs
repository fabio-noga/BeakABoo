using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    private Vector3 movement;

    public float speed = 6f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    void Update()
    {
        float time = Time.deltaTime;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.z);
        movement = movement.normalized;

        animator.SetFloat("Speed", movement.sqrMagnitude);

        Vector3 move = transform.right * movement.x + transform.forward * movement.z;

        controller.Move(move * speed * time);

        velocity.y += gravity * time;

        controller.Move(velocity * Time.deltaTime);


        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            Debug.Log("yes");
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
