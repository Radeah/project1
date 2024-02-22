using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the character
    public Transform groundCheck; // Reference to a GameObject used for checking if the character is grounded
    public LayerMask groundLayer; // Layer mask to determine what is considered ground

    private Rigidbody2D rb; // Reference to the Rigidbody component
    private bool isGrounded; // Flag to indicate if the character is grounded

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // Handle touch inputs
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the character left or right based on touch position
            if (touch.position.x < Screen.width / 2)
            {
                // Move left
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else
            {
                // Move right
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
        else
        {
            // Stop movement if no touch input
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}   

