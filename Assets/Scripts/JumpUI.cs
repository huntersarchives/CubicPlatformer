using TMPro;
using UnityEngine;

public class JumpUI : MonoBehaviour
{
    public PlayerController player;
    public TextMeshProUGUI bonusJumpText;

    // Update is called once per fram
    // bonusjump
    void Update()
    {
        if (player.bonusJump > 0)
        {
            bonusJumpText.text = "Bonus Jump Available";
        }
        if (player.bonusJump == 0)
        {
            bonusJumpText.text = "No Bonus Jump Available!";
        }

    }
}

