using UnityEngine;

public class NewtonCradle : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Momentum ve hız aktarımı hesaplaması
            Vector2 velocityAfterCollision = CalculateVelocityAfterCollision(rb, otherRb);

            rb.velocity = velocityAfterCollision;
        }
    }

    private Vector2 CalculateVelocityAfterCollision(Rigidbody2D rb1, Rigidbody2D rb2)
    {
        // İki topun hızlarını al
        Vector2 v1 = rb1.velocity;
        Vector2 v2 = rb2.velocity;

        // Kütleleri al
        float m1 = rb1.mass;
        float m2 = rb2.mass;

        // Momentum ve enerji korunumu prensiplerine göre yeni hızları hesapla
        Vector2 newV1 = ((m1 - m2) / (m1 + m2)) * v1 + ((2 * m2) / (m1 + m2)) * v2;

        return newV1;
    }
}
