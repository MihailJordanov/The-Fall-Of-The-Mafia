using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    //private bool sprinting;

    private bool crouching = false;
    private float crouchTimer = 1;
    private bool lerpCrouch = false;

    private float speed = 8f;

    //public float sprintingSpeed = 8f;
    public float crouchingSpeed = 2f;
    public float defSpeed = 8f;

    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        speed = defSpeed;
        controller = GetComponent<CharacterController>();

        //MINE (lock mouse)
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;  

        // Crouch
        if(lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;

            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 0, p);
                speed = crouchingSpeed;
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
                speed = defSpeed;
            }

            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }

        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        if (!isGrounded)
        {
            playerVelocity.y += gravity * Time.deltaTime;
            if(playerVelocity.y < -10f)
            {
                playerVelocity.y = -10f;
            }
        }

        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        crouching = false;
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0f;
        lerpCrouch = true;
    }

    //public void Sprint()
    //{
    //    sprinting = !sprinting;
    //    if (sprinting)
    //        speed = sprintingSpeed;
    //    else
    //        speed = defSpeed;
    //}
}
