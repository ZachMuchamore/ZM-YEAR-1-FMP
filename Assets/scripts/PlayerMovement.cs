using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 100f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 6f;

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    float currentAngle;
    float rotationSmoothTime = 1;
    float currentAngleVelocity;

    public GameObject cam;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {


        MovePlayer();
        PlayerJump();
        GroundCheck();


    }


    void MovePlayer()
    {
        float hMov = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(hMov, 0, Input.GetAxisRaw("Vertical")).normalized;

        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            Vector3 rotatedMovement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward * 0.2f;
            controller.Move(rotatedMovement * speed * Time.deltaTime);
        }

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {

        }
        else
        {

        }
        lastPosition = gameObject.transform.position;
    }


    void PlayerJump()
    {
        // Check is the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Actually jumping
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Falling down
        velocity.y += gravity * Time.deltaTime;

        // Exectuting the jump
        controller.Move(velocity * Time.deltaTime);
    }


    void GroundCheck()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Resetting the default velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }

}








