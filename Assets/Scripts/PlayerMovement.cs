using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float yaw;
    public float yawSpeed = 100.0f;
    public int pitchAngle = 45;
    public int rollAngle = 30;

    // New field for dynamic roll movement
    public float dynamicRollAmplitude = 1.5f;  // Amplitude of dynamic roll when moving forward
    public float dynamicFrequency = 0.5f;      // Speed of the oscillation

    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Forward movement
        Vector3 movement = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // Basic Yaw and Pitch based on player input
        yaw += horizontalInput * yawSpeed * Time.deltaTime;
        float pitch = Mathf.Lerp(0, pitchAngle, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);

        // Basic Roll based on player input
        float roll = Mathf.Lerp(0, rollAngle, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

        // Adding subtle dynamic roll motion when not turning
        if (horizontalInput == 0)
        {
            float dynamicRoll = Mathf.Sin(Time.time * dynamicFrequency) * dynamicRollAmplitude;
            roll += dynamicRoll;
        }

        // Apply final rotation
        transform.rotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.GetComponent<GoalController>().Spawn();
        }
    }
}
