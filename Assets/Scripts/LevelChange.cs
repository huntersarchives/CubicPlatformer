using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    private bool playerInside = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Entered");
            playerInside = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Left");
            playerInside = false;
        }
    }
    private void Update()
    {
        if (playerInside && InputManager.interact)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
        }
    }
}
