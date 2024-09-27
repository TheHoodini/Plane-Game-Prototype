using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public float arrowSpeed = 10.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the arrow to look at the target based on the player
        transform.rotation = Quaternion.Slerp(transform.rotation, 
        Quaternion.LookRotation(target.position - player.position), arrowSpeed * Time.deltaTime);
    }
}
