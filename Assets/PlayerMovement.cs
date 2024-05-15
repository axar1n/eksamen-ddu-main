using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityScale = 2f; // Adjust gravity scale for falling
    public Transform groundCheck;
    public Transform barrierCheck; // Declare barrierCheck variable
    public LayerMask groundMask;
    public LayerMask barrierMask; // Declare barrierMask variable

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isTouchingBarrier; // Variable to track if player is touching a barrier
    public bool is3D = false; // Variable to control whether movement is restricted to left/right or not
    public bool is3DToggle = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundMask);
        // Check if player is touching a barrier
        isTouchingBarrier = Physics2D.OverlapCircle(barrierCheck.position, 0.5f, barrierMask);

        // Check for right mouse button click
        if (Input.GetMouseButtonDown(1) && is3DToggle)
        {
            is3D = !is3D; // Toggle between allowing and restricting up/down movement
        }

        // Movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        float verticalMoveInput = is3D ? Input.GetAxisRaw("Vertical") : 0f; // Only allow vertical movement if is3D is true
        
        rb.velocity = new Vector2(moveInput * moveSpeed, verticalMoveInput * moveSpeed);

        // Apply gravity if not grounded and not allowed to move up/down
        
        if (!isGrounded && !is3D)
        {
            rb.velocity += Vector2.down * 8; // Apply gravity by adding a downward velocity
        }
            if (isGrounded && is3D)
            {
                if (rb.velocity.y < 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0f); // Set vertical velocity to 0

                }
            }

        

        CircleCollider2D playerCollider = GetComponent<CircleCollider2D>();

        /* Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        */
    }

}
