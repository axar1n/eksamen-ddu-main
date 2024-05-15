using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Camera baneCamera;
    public Transform groundCheck;
    public Transform barrierCheck; // Declare barrierCheck variable
    public LayerMask groundMask;
    public LayerMask barrierMask; // Declare barrierMask variable

    public PlayerMovement pm;

    public bool is3D;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingBarrier; // Variable to track if player is touching a barrier
    // Variable to control whether movement is restricted to left/right or not

    private void findIs3D(){
        is3D = pm.is3D;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        findIs3D();
    }

    // Update is called once per frame
    void Update()
    {
        findIs3D();
        if (baneCamera.enabled){
            
            
            // Check if player is grounded
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);
            // Check if player is touching a barrier
            isTouchingBarrier = Physics2D.OverlapCircle(barrierCheck.position, 0.5f, barrierMask);

            // Apply gravity if not grounded and not allowed to move up/down

            if (!isGrounded && !is3D)
            {
                rb.velocity += Vector2.down/10; // Apply gravity by adding a downward velocity
            }
            }
            if (isGrounded && is3D)
            {
            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f); // Set vertical velocity to 0
                
            }
        }
    }
}
