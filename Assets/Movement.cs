using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float rightSide = 2f;
public float leftSide = -2f;
public float middle = 0f;
public float moveSpeed = 3f;
public float jumpForce = 5f;
public float jumpForwardForce = 5f;
public float gravity = -9.81f;
public LayerMask groundMask;
public Animator animator;

private Rigidbody rb;
//[SerializeField] private bool isGrounded;

void Start()
{
    rb = GetComponent<Rigidbody>();
}

void FixedUpdate()
{
    // Move the player forward
    rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);

    // Move the player left or right
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        if (transform.position.x == rightSide)
        {
            transform.position = new Vector3(middle, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == middle)
        {
            transform.position = new Vector3(leftSide, transform.position.y, transform.position.z);
        }
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        if (transform.position.x == leftSide)
        {
            transform.position = new Vector3(middle, transform.position.y, transform.position.z);
        }
        else if (transform.position.x == middle)
        {
            transform.position = new Vector3(rightSide, transform.position.y, transform.position.z);
        }
    }

    // Jump
    if (Input.GetKeyDown(KeyCode.Space))
    {
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce + transform.forward * jumpForwardForce, ForceMode.Impulse);
    }

    // Apply gravity
    rb.AddForce(Vector3.up * gravity, ForceMode.Acceleration);

    // Check if the player is on the ground
    //isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 20f, 0), 0.2f, groundMask);
}

}
