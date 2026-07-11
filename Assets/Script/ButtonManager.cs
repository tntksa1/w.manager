using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro; // Required for TextMeshPro

public class ButtonManager : MonoBehaviour
{
    [Header("Play")]
    public string gameSceneName = "GameScenes";

    [Header("Sound")]
    public Button soundButton;
    public TMP_Text soundButtonText; // TextMeshPro UI text

    private bool soundOn = true;

    private void Start()
    {
        // Load saved sound setting
        soundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        AudioListener.volume = soundOn ? 1f : 0f;

        UpdateSoundButton();
    }

    // Called by the Play button
    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // Called by the Play Again button (e.g. on Game Over screen)
    public void PlayAgain()
    {
        // Reloads the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Called by the Sound button
    public void ToggleSound()
    {
        soundOn = !soundOn;

        AudioListener.volume = soundOn ? 1f : 0f;

        PlayerPrefs.SetInt("Sound", soundOn ? 1 : 0);
        PlayerPrefs.Save();

        UpdateSoundButton();
    }

    private void UpdateSoundButton()
    {
        if (soundButtonText != null)
        {
            soundButtonText.text = soundOn ? "Sound: ON" : "Sound: OFF";
        }
    }
}