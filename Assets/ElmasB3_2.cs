using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondCollision : MonoBehaviour
{
    public GameObject ball1;
    public GameObject ball2;
    private bool ball1Reached = false;
    private bool ball2Reached = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == ball1)
        {
            ball1Reached = true;
            ball1.SetActive(false);  // Topu gizler (yok eder)
        }
        else if (other.gameObject == ball2)
        {
            ball2Reached = true;
            ball2.SetActive(false);  // Topu gizler (yok eder)
        }

        // Ýki top da elmasa ulaþtýysa, sonraki bölüme geç
        if (ball1Reached && ball2Reached)
        {
            NextLevel();
        }
    }

    void NextLevel()
    {
        // Bir sonraki bölüme geçiþ yapýlýr
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Tebrikler! Tüm bölümleri bitirdiniz.");
        }
    }
}
