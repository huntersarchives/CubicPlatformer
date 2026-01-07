using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenButtons : MonoBehaviour
{

    public Button playButton;

    public Button quitButton;

    void Start()
    {
        playButton.onClick.AddListener(OnClickPlay);
        playButton.onClick.AddListener(OnClickQuit);
    }

    void OnClickPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnClickQuit()
    {
        Application.Quit();
    }
}
