using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 1f;
    private Vector2 movement;
    private Vector3 movement3d;
    private bool hasWheelbarrow = false;
    private AudioManager _audio;

    //public Rigidbody2D rb;
    public Rigidbody rb;
    public Animator animator;

    void Start()
    {
        _audio = FindObjectOfType<AudioManager>();
    }

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

        //testing all 3d
        movement3d.x = Input.GetAxisRaw("Horizontal");
        movement3d.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        //testing all 3d
        animator.SetFloat("horizontal", movement3d.x);
        animator.SetFloat("vertical", movement3d.z);

        animator.SetFloat("speed", movement3d.sqrMagnitude);

        if(movement3d.sqrMagnitude > 0)
        {
            _audio.Play("WalkingGrass");
        }
    }

    void FixedUpdate()
    {
        //movement
        //rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        //Store user input as a movement vector
        
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

         rb.MovePosition(rb.position + m_Input * movementSpeed * Time.fixedDeltaTime);
    }
}
