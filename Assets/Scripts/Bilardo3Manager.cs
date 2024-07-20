using UnityEngine;
using TMPro; // TextMeshPro kütüphanesini ekleyin
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartPanel;
    public GameObject ball1; // Top 1 referansý
    public GameObject ball2; // Top 2 referansý

    private bool gameEnded = false;
    private Vector2 ball1StartPos;
    private Vector2 ball2StartPos;

    void Start()
    {
        restartPanel.SetActive(false);
        Time.timeScale = 1; // Oyunun normal hýzda çalýþmasýný saðla

        // Toplarýn baþlangýç pozisyonlarýný kaydet
        ball1StartPos = ball1.transform.position;
        ball2StartPos = ball2.transform.position;
    }

    void Update()
    {
        if (gameEnded)
            return;
    }

    void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0; // Oyunu durdur
        restartPanel.SetActive(true); // Restart panelini göster
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Oyunu yeniden baþlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1; // Oyunu yeniden baþlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CheckWinCondition(bool top1In, bool top2In)
    {
        if (top1In && top2In)
        {
            NextLevel();
        }
    }

    public void ResetBalls()
    {
        ball1.transform.position = ball1StartPos;
        ball2.transform.position = ball2StartPos;
        ball1.SetActive(true);
        ball2.SetActive(true);
        ball1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ball2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
