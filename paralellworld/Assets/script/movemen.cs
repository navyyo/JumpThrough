using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class movemen : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.81f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    Vector3 velocity;
    bool isGrounded;
    private float jumpMultiplier;
    public CharacterController controller;
   

    // Start is called before the first frame update

    void Jump()
    {
        if ((Input.GetButtonDown("jump")) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * jumpMultiplier);
            jumpMultiplier = 1f;
        }

    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            speed = 6f;
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed *Time.deltaTime);
        Jump();


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);






    }
}