using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    // Reference to the AudioSource component attached to the button GameObject
    public AudioSource buttonAudio;

    // Reference to the AudioClip that will be played
    public AudioClip gunshot;

    
    public void ButtonClick()
    {
       
       
        
        buttonAudio.PlayOneShot(gunshot);

    
        // delay between sound and new scene
        Invoke("LoadMainGameScene", 0.5f);
    }

    // Function to load the main game scene
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}

