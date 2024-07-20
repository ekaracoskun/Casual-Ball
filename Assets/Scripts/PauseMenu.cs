using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Duraklatma menüsü UI'si
    public Button pauseButton; // Duraklatma butonu
    public Button resumeButton; // Devam et butonu
    public Button levelSelectButton; // Seviye seçimi butonu
    public Button mainMenuButton; // Ana menü butonu
    public Button musicToggleButton; // Müzik açma/kapama butonu

    private bool isPaused = false;

    private AudioManager audioManager;

    void Start()
    {
        // Butonlara týklama olaylarýný baðlayýn
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(Resume);
        levelSelectButton.onClick.AddListener(LoadLevelSelect);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        musicToggleButton.onClick.AddListener(ToggleMusic); // Müzik butonunu ekleyin

        pauseMenuUI.SetActive(false); // Oyunun baþýnda duraklatma menüsünü gizli tut

        // AudioManager'ý bulun
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
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesinin adý
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
            musicToggleButton.GetComponentInChildren<Text>().text = "Unmute"; // Butonun text'ini deðiþtir
        }
        else
        {
            musicToggleButton.GetComponentInChildren<Text>().text = "Mute"; // Butonun text'ini deðiþtir
        }
    }
}
