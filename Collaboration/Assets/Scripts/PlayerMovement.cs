using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    [Space]

    [Header("Player")]
    public float movementSpeedForward = 12f;
    public float movementSpeedSideways = 12f;
    public float jumpHeight = 3f;
    public float jumpFallSpeed = 2f;
    public float jumpMovementModifier = 1.25f;

    [Space]

    [Header("Environment")]
    public float gravity = -9.81f;

    [Space]

    [Header("Check if Grounded")]
    public Transform groundCheck;
    public Vector3 groundCheckRadius = new Vector3(.2f, .1f, .2f);
    public LayerMask groundMask;

    // Private

    Vector3 velocity;

    [Space][Space]

    [Header("Debug - Do Not Modify")]
    [SerializeField] bool isGrounded;
    [SerializeField] bool isJumping;
    [SerializeField] GameObject equippedItem;
    [SerializeField] Vector3 move;



    // Update is called once per frame
    void Update()
    {
        equippedItem = WeaponSwap.equippedItem;
        float itemMovementSpeedModifier = equippedItem.GetComponent<ItemStats>().movementSpeedModifier;

        isGrounded = Physics.CheckBox(groundCheck.position, groundCheckRadius, Quaternion.identity, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            isJumping = false;
        }
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (isJumping)
        {
            move = (transform.right * x * movementSpeedSideways) + (transform.forward * z * movementSpeedForward);
            controller.Move(move * itemMovementSpeedModifier * jumpMovementModifier * Time.deltaTime);

            velocity.y += gravity * jumpFallSpeed * Time.deltaTime;
        }
        else
        {
            move = (transform.right * x * movementSpeedSideways) + (transform.forward * z * movementSpeedForward);
            controller.Move(move * itemMovementSpeedModifier * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);


        if (isGrounded && Input.GetButton("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }
    }

}
