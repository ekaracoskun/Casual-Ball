using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Oyunu kaybetme durumu
            Debug.Log("Oyun Kaybedildi!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Sahneyi yeniden yükleyin
        }
        else if (collision.gameObject.CompareTag("SafeObject"))
        {
            // SafeObject'e PlayerCollision scriptini ekleyin
            collision.gameObject.AddComponent<SafeObjectCollision>();
        }
    }
}
