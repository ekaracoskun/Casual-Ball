using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Duvara çarpma durumu
            Debug.Log("Duvara çarptýn! Oyun yeniden baþlýyor...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Mevcut bölümü yeniden yükle
        }
    }
}
