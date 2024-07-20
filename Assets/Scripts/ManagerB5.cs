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
        // Oyun kaybetme ekranýný göster.
        SceneManager.LoadScene("GameOverScene"); // Oyun kaybetme sahnesine yönlendirme.
    }

    public void Win()
    {
        // Oyun kazanma ekranýný göster.
        SceneManager.LoadScene("WinScene"); // Oyun kazanma sahnesine yönlendirme.
    }
}
