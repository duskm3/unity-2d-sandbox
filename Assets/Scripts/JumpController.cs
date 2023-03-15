using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 10f;   // The force applied to the player when jumping
    public float groundCheckRadius = 0.2f;   // The radius of the circle used for checking if the player is grounded
    public LayerMask groundLayer;   // The layer(s) on which the player is considered grounded
    public int jumpsAllowed = 2;

    private Rigidbody2D rb;   // The Rigidbody2D component of the player
    private bool isGrounded = false;   // Whether the player is currently grounded
    //private bool wasGrounded = false;
    private int remainingJumps;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Handle determining if the user is currently grounded and updating state variables appropriately
    /// </summary>
    void HandleGround() {
        
        //Make sure we know if the player was already on the ground
        bool wasGrounded = isGrounded;

        //Set the player to grounded if the hitbox overla[s]
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        
        //If the player is now grounded, and they weren't before...update things.
        if (isGrounded && !wasGrounded) {
            remainingJumps = jumpsAllowed;
            Debug.Log("GROUNDED! - Jumps Reset! - Jumps Remaining: " + remainingJumps);
        }
    }

    /// <summary>
    ///  Handle the player jumping, and update state variables appropriately
    /// </summary>
    void HandleJump() {
        if (Input.GetKeyDown(KeyCode.Space) && remainingJumps > 0) 
        {
            remainingJumps--;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("JUMPED! - Grounded? " + isGrounded + " | Jumps Remaining: " + remainingJumps);
        }
    }

    void Update()
    {
       HandleGround();
       HandleJump();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
