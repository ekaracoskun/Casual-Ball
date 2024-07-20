using UnityEngine;

public class Hole : MonoBehaviour
{
    public float pullStrength = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null && other.CompareTag("Ball"))
        {
            Vector2 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * pullStrength * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
            // Oyunu kaybetme koþulu burada kontrol edilecek.
            FindObjectOfType<GameManagerB5>().GameOver();
        }
    }
}
