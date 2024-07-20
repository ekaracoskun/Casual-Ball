using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagerB4 : MonoBehaviour
{
    public GameObject losePanel;
    public TextMeshProUGUI timerText;
    public float timeLimit = 60f;
    private float timeRemaining;
    public int totalOtherBalls;
    private bool blackBallPocketed = false;
    private GameObject blackBall;
    private bool playerLost = false;

    void Start()
    {
        losePanel.SetActive(false);
        timeRemaining = timeLimit;
        blackBall = GameObject.FindWithTag("BlackBall");
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else if (!playerLost)
        {
            ShowLosePanel();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ShowLosePanel()
    {
        Time.timeScale = 0;
        losePanel.SetActive(true);
        playerLost = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BlackBallPocketed()
    {
        // If the black ball is pocketed before all other balls, player loses
        if (totalOtherBalls > 0)
        {
            ShowLosePanel();
        }
        else
        {
            blackBallPocketed = true;
            Destroy(blackBall);
            CheckWinCondition();
        }
    }

    public void OtherBallPocketed(GameObject otherBall)
    {
        // If player's ball is pocketed, player loses
        if (otherBall.CompareTag("PlayerBall"))
        {
            ShowLosePanel();
        }
        else
        {
            Destroy(otherBall);
            totalOtherBalls--;

            if (totalOtherBalls <= 0 && blackBallPocketed)
            {
                LoadNextLevel();
            }
        }
    }

    public void CheckWinCondition()
    {
        // Check if all other balls are pocketed and black ball is pocketed
        if (totalOtherBalls <= 0 && blackBallPocketed)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        // Load the specific next level
        string nextSceneName = "Level8";
        SceneManager.LoadScene(nextSceneName);
    }
}
