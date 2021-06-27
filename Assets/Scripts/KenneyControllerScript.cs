using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KenneyControllerScript : MonoBehaviour
{
    private float movementSpeed = 1f;
    private Vector3 movement3d;
    private bool hasWheelbarrow = false;
    private AudioManager _audio;
    public Rigidbody rb;
    private Animator animator;

    void Start()
    {
        _audio = FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    void Update()
    {
        movement3d.x = Input.GetAxisRaw("Horizontal");
        movement3d.z = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement3d.x);
        animator.SetFloat("vertical", movement3d.z);

        animator.SetFloat("speed", movement3d.sqrMagnitude);

        if(movement3d.sqrMagnitude > 0)
        {
            _audio.Play("WalkingGrass");
        }

        if(movement3d.x > 0f) 
        {
            Debug.Log("Movement 3D > 0. it == " + movement3d.x.ToString());
        }
    }

    void FixedUpdate()
    {
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        rb.MovePosition(rb.position + m_Input * movementSpeed * Time.fixedDeltaTime);
    }
}
