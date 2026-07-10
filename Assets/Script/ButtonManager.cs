using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [Header("Play")]
    public string gameSceneName = "GameScenes";

    [Header("Sound")]
    public Button soundButton;
    public Text soundButtonText; // Legacy UI Text

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