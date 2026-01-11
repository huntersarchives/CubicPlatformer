using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Beginnning : MonoBehaviour
{
    public Button playButton;

    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(OnClickQuit);
        playButton.onClick.AddListener(OnClickPlay);
    }

    void OnClickQuit()
    {
        Application.Quit();
    }

    void OnClickPlay() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
