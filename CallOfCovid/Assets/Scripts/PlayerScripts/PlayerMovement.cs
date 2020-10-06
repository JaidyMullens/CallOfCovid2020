using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float resetSpeed = 10f;
    public float sprintSpeed = 20f;
    public float gravity = -9.81f;

   

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;

    bool isGrounded;

    bool isSprinting;

    bool movingForward;

    bool keyEnabled = true;

    Rect staminaRect;
    Texture2D staminaTexture;

    

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSprinting)
        {
            StaminaBar.instance.useStamina(1);
        }
        if (StaminaBar.instance.currentStamina == 0 /*&& StaminaBar.instance.currentStamina != StaminaBar.instance.maxStamina*/)
        {
            keyEnabled = false;
            
        }
        if (!isSprinting)
        {
            StaminaBar.instance.addStamina(1);
        }

        if (StaminaBar.instance.currentStamina > 1000 /*StaminaBar.instance.maxStamina*/)
        {
            keyEnabled = true;
        }
        

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isSprinting = Input.GetKey("r") && Input.GetKey("w");
        movingForward = Input.GetKey("w");

        if (isSprinting && movingForward && keyEnabled)
        {
            speed = sprintSpeed;
        }

        else
        {
            speed = resetSpeed;
        } 

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        Vector3 move = transform.right * X + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
