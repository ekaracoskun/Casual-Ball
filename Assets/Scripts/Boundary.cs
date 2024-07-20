using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;
    public float bounceForce = 5f; // Sýnýra çarpýnca uygulanacak geri tepme kuvveti

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        // Sýnýrlara çarpma kontrolü
        if (pos.x <= minX || pos.x >= maxX || pos.y <= minY || pos.y >= maxY)
        {
            // Sýnýra çarpma tepkisi
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // X ekseni için tepki
                if (pos.x <= minX || pos.x >= maxX)
                {
                    rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y); // X ekseni için ters yönde hýzýný deðiþtir
                    rb.AddForce(new Vector2(Mathf.Sign(pos.x - (minX + maxX) / 2) * bounceForce, 0), ForceMode2D.Impulse); // Orta noktaya göre yön belirle
                }

                // Y ekseni için tepki
                if (pos.y <= minY || pos.y >= maxY)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y); // Y ekseni için ters yönde hýzýný deðiþtir
                    rb.AddForce(new Vector2(0, Mathf.Sign(pos.y - (minY + maxY) / 2) * bounceForce), ForceMode2D.Impulse); // Orta noktaya göre yön belirle
                }
            }
            // Ýþlem tamamlandýktan sonra istediðiniz diðer tepkileri buraya ekleyebilirsiniz
        }
    }
}
