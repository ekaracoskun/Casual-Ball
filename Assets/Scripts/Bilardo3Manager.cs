using UnityEngine;
using TMPro; // TextMeshPro k�t�phanesini ekleyin
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartPanel;
    public GameObject ball1; // Top 1 referans�
    public GameObject ball2; // Top 2 referans�

    private bool gameEnded = false;
    private Vector2 ball1StartPos;
    private Vector2 ball2StartPos;

    void Start()
    {
        restartPanel.SetActive(false);
        Time.timeScale = 1; // Oyunun normal h�zda �al��mas�n� sa�la

        // Toplar�n ba�lang�� pozisyonlar�n� kaydet
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
        restartPanel.SetActive(true); // Restart panelini g�ster
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Oyunu yeniden ba�lat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1; // Oyunu yeniden ba�lat
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
