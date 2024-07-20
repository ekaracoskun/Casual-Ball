using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Topun tag'inin "Player" oldu�undan emin olun
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // T�m seviyeler tamamland���nda yap�lacak i�lemler
            Debug.Log("T�m seviyeler tamamland�!");
        }
    }
}
