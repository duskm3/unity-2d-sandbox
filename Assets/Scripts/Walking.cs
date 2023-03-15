using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float speed;
    private float move;
    public Vector2 startingPosition;
    public float rotateSpeed; // New variable for controlling the rotation speed
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y); 
    
        // Check if the player has fallen off the map
        if (transform.position.y < -10f)
        {
            // Return the player to the starting position
            transform.position = startingPosition;
        }
        
        // Check if the Q key is pressed and rotate the cube left
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        
        // Check if the E key is pressed and rotate the cube right
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }
    }
}
