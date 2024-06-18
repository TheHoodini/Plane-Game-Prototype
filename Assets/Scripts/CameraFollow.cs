using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Plane variables
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the player (adjust Y to be above)
    public float followSpeed = 10.0f; // Speed of the camera following the player
    public float rotationSpeed = 5.0f; // Speed of the camera rotation
    public Vector3 lookAtPosition;

    private void LateUpdate()
    {
        // Calculate the desired position based on the player's position and rotation
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        // Smoothly move the camera to the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Calculate the target rotation to look at the player slightly from above
        lookAtPosition = player.position + new Vector3(0f, 2f, 0f); // Player position offset slightly upwards
        Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);

        // Smoothly rotate the camera to look at the target position
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
