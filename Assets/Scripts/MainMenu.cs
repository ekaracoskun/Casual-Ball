using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Burada Level1, oyununuzun 1. seviyesinin sahne ad�d�r.
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
