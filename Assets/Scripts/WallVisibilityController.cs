using UnityEngine;

public class WallVisibilityController : MonoBehaviour
{
    public GameObject[] walls;  // Duvarlar dizisi

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Oyuncu ile çarpýþma kontrolü
        {
            foreach (GameObject wall in walls)
            {
                Renderer wallRenderer = wall.GetComponent<Renderer>();
                if (wallRenderer != null)
                {
                    wallRenderer.enabled = false;  // Duvarý görünmez yap
                }
            }
        }
    }
}
