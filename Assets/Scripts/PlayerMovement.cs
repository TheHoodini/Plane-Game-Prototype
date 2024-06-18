using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 1.0f; // Speed of turning
    public float maxRollAngle = 45.0f; // Maximum roll angle
    public float maxPitchAngle = 45.0f; // Maximum pitch angle
    public float rollSpeed = 2.0f; // Speed of rolling back to normal
    public float pitchSpeed = 2.0f; // Speed of pitching back to normal
    
    private float horizontalInput;
    private float forwardInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        // Get input values
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Handle movement
        Vector3 movement = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Handle rotation
        float targetRollAngle = -horizontalInput * maxRollAngle;
        float targetPitchAngle = verticalInput * maxPitchAngle;

        // Get the current local rotation angles
        float currentRollAngle = transform.localEulerAngles.z;
        if (currentRollAngle > 180) currentRollAngle -= 360;
        
        float currentPitchAngle = transform.localEulerAngles.x;
        if (currentPitchAngle > 180) currentPitchAngle -= 360;

        // Smoothly interpolate to the target angles
        float rollAngle = Mathf.Lerp(currentRollAngle, targetRollAngle, rollSpeed * Time.deltaTime);
        float pitchAngle = Mathf.Lerp(currentPitchAngle, targetPitchAngle, pitchSpeed * Time.deltaTime);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(pitchAngle, transform.localEulerAngles.y, rollAngle);

        // Handle turning
        float rotation = horizontalInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}