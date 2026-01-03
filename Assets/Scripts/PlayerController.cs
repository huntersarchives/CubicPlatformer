using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int extraJump = 1;

    public Vector2 movement;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    private float coyoteTime = 0.25f;
    private float coyoteTimeCounter;
    
    
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
            coyoteTimeCounter = coyoteTime;
            extraJump = 1;
        } 
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (InputManager.jump)
        {
            if (coyoteTimeCounter > 0)
            {
                Jump();
                coyoteTimeCounter = 0;
            }
            else if (extraJump > 0)
            {
                Jump();
                extraJump--;
            }
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
    
    
    
}
