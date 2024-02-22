using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Speed of camera movement

    private Vector3 offset; // Offset between the camera and the player

    private void Start()
    {
        // Calculate initial offset between camera and player
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}