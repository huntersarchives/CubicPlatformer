using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    public int bonusJump = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.extraJump += bonusJump;
            Destroy(gameObject);
        }
    }
}
