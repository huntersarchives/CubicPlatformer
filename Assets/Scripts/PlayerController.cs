using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 500f;

    public Vector2 movement;
    
    [SerializeField] private Rigidbody2D rb;
    
    // Update is called once per frame
    void Update()
    {
        movement.Set(InputManager.movement.x);


        if (InputManager.jump)
        {
            Jump();
            Debug.Log("jump");
        }
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }
    private void IsGrounded()
    {
        Debug.Log("help");
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
