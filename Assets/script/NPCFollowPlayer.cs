using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public float jumpForce = 5f; // Force applied when jumping
    public float jumpInterval = 5f; // Time interval between jumps
    private float jumpTimer = 0f; // Timer to track jump interval

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Increment jump timer
        jumpTimer += Time.deltaTime;

        // Check if it's time to jump
        if (jumpTimer >= jumpInterval)
        {
            Jump();
            jumpTimer = 0f; // Reset jump timer
        }
    }

    // Method to make the NPC jump
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    // Method to allow the NPC to jump
    public void AllowJump()
    {
        // Uncomment the line below if you want the NPC to jump immediately
        // Jump();
        enabled = true; // Enable the script
    }

    // Method to prevent the NPC from jumping
    public void PreventJump()
    {
        enabled = false; // Disable the script
    }
}

