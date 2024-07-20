using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBall"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Bir sonraki bölüme geç
        }
    }
}
