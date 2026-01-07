using TMPro;
using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    [SerializeField] public ParticleSystem ps;
    public TextMeshProUGUI bonusJumpText;
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Gives the player a bonus jump
            // **TODO** particle system when picked up and outline sprite when character has bonusjump available
            
            player.bonusJump += 1;
            ps.Play();
            Destroy(gameObject);
        }
    }
}
