using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCamera : MonoBehaviour
{
    public Transform arrow; 
    public Transform player; 
    public float distance = 5.0f; // Distance from the arrow
    public float height = 2.0f; // Height above the arrow
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerRotation = player.eulerAngles;

        // Calculate the desired position
        Quaternion rotation = Quaternion.Euler(0, playerRotation.y, 0);
        Vector3 position = arrow.position - rotation * Vector3.forward * distance + Vector3.up * height;

        // Update camera position and look at the arrow
        transform.position = position;
        transform.LookAt(arrow.position);
    }
}
