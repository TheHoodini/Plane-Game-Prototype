using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    // Start is called before the first frame update
    public float high = 0.5f;
    public float speed = 2.0f;

    private Vector3 currentPosition;

    void Start()
    {
        Spawn();
        currentPosition = transform.position;
    }

    public Transform player;
    void Update()
    {
        // Move up and down
        float newY = currentPosition.y + Mathf.Sin(Time.time * speed) * high;
        transform.position = new Vector3(currentPosition.x, newY, currentPosition.z);

        // Rotate to look at the player
        Vector3 direction = player.position - transform.position;
        direction.y = 0; 
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

    public void Spawn(){
        float x = Random.Range(-100, 100);
        float z = Random.Range(-100, 100);
        float y = Random.Range(-20, 20);
        transform.position = new Vector3(x, y, z);
        currentPosition = transform.position;
    }
}
