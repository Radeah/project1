using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for jump input (space key, UI button click, or touch)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump") || IsTouchingJumpButton())
        {
            Jump();
        }
    }

    bool IsTouchingJumpButton()
    {
        // Check if there is a touch on the UI jump button
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Convert touch position to UI space
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D hit = Physics2D.Raycast(touchPos, Vector2.zero);

                // Check if the UI button is touched
                if (hit.collider != null && hit.collider.CompareTag("JumpButton"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    void Jump()
    {
        if (isGrounded)
        {
            // Apply an upward force to make the player jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Set to false since the player is now in the air
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with a ground object
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set to true when the player lands on the ground
        }
    }
}