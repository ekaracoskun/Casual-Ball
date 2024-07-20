using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeObjectCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Oyun kaybetme durumu
            Debug.Log("Oyun Kaybedildi!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükleyin
        }
    }
}
