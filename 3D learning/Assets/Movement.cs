using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float groundDistance;
    public float jumpHeight;
    public LayerMask Ground;

    public Transform groundCheck;
    
    private bool isGrounded;
    private Vector3 velocity;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, Ground);

        if (isGrounded && velocity.y < 0) 
            velocity.y = 0;

        //moves character
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * speed * Time.deltaTime);

        //steers character and camera
        if (move != Vector3.zero)
            transform.forward = move;

        //gravity
        velocity.y -= gravity * Time.deltaTime;

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y += Mathf.Sqrt(jumpHeight * 2f * gravity);


        controller.Move(velocity * Time.deltaTime);        


    }
}
