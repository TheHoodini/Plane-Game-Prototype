using System;
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
    
    private float horizontalInput;
    private float verticalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
        
        yaw += horizontalInput * yawSpeed * Time.deltaTime;
        float pitch = Mathf.Lerp(0, pitchAngle, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, rollAngle, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

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