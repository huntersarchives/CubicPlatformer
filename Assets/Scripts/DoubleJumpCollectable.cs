using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    public extraJump extraJump;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Entered");
        }
    }
}
