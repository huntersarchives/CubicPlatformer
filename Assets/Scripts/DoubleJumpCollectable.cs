using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Gives the player a bonus jump
            // **TODO** particle system when picked up and outline sprite when character has bonusjump available
            PlayerController player = collision.GetComponent<PlayerController>();
            player.bonusJump += 1;
            Destroy(gameObject);
        }
    }
}
