
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    // Function called when the quit button is clicked
    public void Quit()
    {
        SceneManager.LoadScene("MainMenuScene"); // Replace "MainMenuScene" with the name of your main menu scene
    }
}

