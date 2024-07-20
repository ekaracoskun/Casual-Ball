using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Duraklatma men�s� UI'si
    public Button pauseButton; // Duraklatma butonu
    public Button resumeButton; // Devam et butonu
    public Button levelSelectButton; // Seviye se�imi butonu
    public Button mainMenuButton; // Ana men� butonu
    public Button musicToggleButton; // M�zik a�ma/kapama butonu

    private bool isPaused = false;

    private AudioManager audioManager;

    void Start()
    {
        // Butonlara t�klama olaylar�n� ba�lay�n
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(Resume);
        levelSelectButton.onClick.AddListener(LoadLevelSelect);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        musicToggleButton.onClick.AddListener(ToggleMusic); // M�zik butonunu ekleyin

        pauseMenuUI.SetActive(false); // Oyunun ba��nda duraklatma men�s�n� gizli tut

        // AudioManager'� bulun
        audioManager = FindObjectOfType<AudioManager>();
    }

    void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Ana men� sahnesinin ad�
    }

    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

    void ToggleMusic()
    {
        audioManager.ToggleMute();
        if (audioManager.isMuted)
        {
            musicToggleButton.GetComponentInChildren<Text>().text = "Unmute"; // Butonun text'ini de�i�tir
        }
        else
        {
            musicToggleButton.GetComponentInChildren<Text>().text = "Mute"; // Butonun text'ini de�i�tir
        }
    }
}
