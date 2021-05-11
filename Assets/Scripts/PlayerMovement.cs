using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 1f;
    private Vector2 movement; 
    private bool hasWheelbarrow = false;

    public Rigidbody2D rb;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            hasWheelbarrow = !hasWheelbarrow;
            animator.SetBool("hasWheelbarrow", hasWheelbarrow);
        }

        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
