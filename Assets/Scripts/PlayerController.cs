using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 500f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int extraJump = 1;
    public Vector2 movement;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    private float coyoteTime = 0.2f;
    
    
    // Update is called once per frame
    void Update()
    {
        
        // set movement fomr input manager
        movement.Set(InputManager.movement.x, InputManager.movement.y);

        JumpLogic();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new  Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
    private bool IsGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            Debug.Log("On ground");
            return true;
            
        }
        else
        {
            Debug.Log("not on ground");
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void JumpLogic()
    {
        if (IsGrounded())
        {
            extraJump = 1;
        }

        if (InputManager.jump && extraJump > 0) 
        {
            extraJump--;
            Jump();
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
    
    
    
}
