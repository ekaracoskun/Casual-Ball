using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerB5 : MonoBehaviour
{
    public Text shotsRemainingText;

    public void UpdateShotsRemaining(int shotsRemaining)
    {
        shotsRemainingText.text = "Shots Remaining: " + shotsRemaining;
    }

    public void GameOver()
    {
        // Oyun kaybetme ekran�n� g�ster.
        SceneManager.LoadScene("GameOverScene"); // Oyun kaybetme sahnesine y�nlendirme.
    }

    public void Win()
    {
        // Oyun kazanma ekran�n� g�ster.
        SceneManager.LoadScene("WinScene"); // Oyun kazanma sahnesine y�nlendirme.
    }
}
