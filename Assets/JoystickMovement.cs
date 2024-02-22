using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controls // Assuming this script is in the "Controls" namespace
{
    public class JoystickMovement : MonoBehaviour
    {
        // Method to get the direction of joystick input
        public Vector2 GetJoystickDirection()
        {
            // Get horizontal and vertical input from virtual joystick
            float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input
            float verticalInput = Input.GetAxis("Vertical"); // Get vertical input

            // Create a Vector2 with horizontal and vertical input
            Vector2 joystickDirection = new Vector2(horizontalInput, verticalInput);

            // Return the joystick direction
            return joystickDirection;
        }
    }
}
