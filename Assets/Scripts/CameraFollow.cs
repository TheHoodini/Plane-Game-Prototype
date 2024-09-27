using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Plane variables
    public Transform player; 
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Offset from the player 
    public float followSpeed = 10.0f; 
    public float rotationSpeed = 5.0f; 
    public Vector3 lookAtPosition;

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position + player.TransformDirection(offset);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        lookAtPosition = player.position + new Vector3(0f, 2f, 0f); 
        Quaternion targetRotation = Quaternion.LookRotation(lookAtPosition - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
