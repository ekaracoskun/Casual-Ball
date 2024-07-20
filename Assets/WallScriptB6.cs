using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Duvara �arpma durumu
            Debug.Log("Duvara �arpt�n! Oyun yeniden ba�l�yor...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Mevcut b�l�m� yeniden y�kle
        }
    }
}
