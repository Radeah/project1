using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true; // Assuming the player starts on the ground
    }

    private void FixedUpdate()
    {
        if (isGrounded)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, rb.velocity.y);

        // Lock vertical movement
        if (movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            rb.velocity = Vector2.zero; // Stop movement when leaving the ground
        }
    }
}
