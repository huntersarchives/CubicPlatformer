using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.bonusJump += 1;
            Destroy(gameObject);
        }
    }
}
