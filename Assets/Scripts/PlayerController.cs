using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public int extraJump;

    public int bonusJump = 0;
    public int extraJumpCount = 1;
    public Vector2 movement;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    
    
    // Update is called once per frame
    void Update()
    {
        
        // set movement from input manager
        movement.Set(InputManager.movement.x, InputManager.movement.y);
        JumpLogic();

        //Debug.Log(extraJump);
    }

    void FixedUpdate()
    {
        //horizontal movement
        rb.linearVelocity = new  Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        //draws box to check for ground check area
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void JumpLogic()
    {
        if (IsGrounded())
        {
            // resets for coyotetime and extrajump
            coyoteTimeCounter = coyoteTime;
            extraJump = extraJumpCount;
        } 
        else
        {
            //starts coyote timer when leaves ground
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (InputManager.jump)
        {
            if (coyoteTimeCounter > 0)
            {
                // Coyote time logic
                Jump();
                coyoteTimeCounter = 0;
            }
            else if (extraJump > 0)
            {
                //extra jump logic
                Jump();
                extraJump--;
            }
            else if (bonusJump > 0)
            {
                Jump();
                bonusJump--;
            }
        }
    }
    private void Jump()
    {
        //jump logic
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
    
    
    
}
