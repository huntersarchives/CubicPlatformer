using UnityEngine;

public class DoubleJumpCollectable : MonoBehaviour
{
    [SerializeField] public ParticleSystem ps;
    public SpriteRenderer sr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (collision.tag == "Player")
        {
            // Gives the player a bonus jump
            // **TODO** particle system when picked up and outline sprite when character has bonusjump availabl
            player.bonusJump += 1;
            ps.Play();
            Destroy(gameObject);
        }
    }
}
