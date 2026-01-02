using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private Rigidbody2D rb;
    public Vector2 movement;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    
    // Update is called once per frame
    void Update()
    {
        movement.Set(InputManager.movement.x, InputManager.movement.y);


        if (InputManager.jump && IsGrounded())
        {
            Jump();
        }
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new  Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
    
    
    
}
