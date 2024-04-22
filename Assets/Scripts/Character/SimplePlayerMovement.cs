using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; // Character's horizontal movement speed
    [SerializeField] private float jumpForce = 10f; // Force applied for jumping
    [SerializeField] private float groundCheckDistance = 0.1f; // Distance for ground check
    [SerializeField] private LayerMask groundLayer; // Layer considered ground

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get horizontal input from keyboard (A/D or left/right arrow keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Check if character is grounded
        isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for ground collision to update grounded state
        if (collision.gameObject.layer == groundLayer.value)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check for leaving ground collision to update grounded state
        if (collision.gameObject.layer == groundLayer.value)
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        // Apply jump force if character is grounded
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}