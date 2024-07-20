using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -5f;
    public float maxY = 5f;
    public float bounceForce = 5f; // S�n�ra �arp�nca uygulanacak geri tepme kuvveti

    void Update()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;

        // S�n�rlara �arpma kontrol�
        if (pos.x <= minX || pos.x >= maxX || pos.y <= minY || pos.y >= maxY)
        {
            // S�n�ra �arpma tepkisi
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // X ekseni i�in tepki
                if (pos.x <= minX || pos.x >= maxX)
                {
                    rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y); // X ekseni i�in ters y�nde h�z�n� de�i�tir
                    rb.AddForce(new Vector2(Mathf.Sign(pos.x - (minX + maxX) / 2) * bounceForce, 0), ForceMode2D.Impulse); // Orta noktaya g�re y�n belirle
                }

                // Y ekseni i�in tepki
                if (pos.y <= minY || pos.y >= maxY)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y); // Y ekseni i�in ters y�nde h�z�n� de�i�tir
                    rb.AddForce(new Vector2(0, Mathf.Sign(pos.y - (minY + maxY) / 2) * bounceForce), ForceMode2D.Impulse); // Orta noktaya g�re y�n belirle
                }
            }
            // ��lem tamamland�ktan sonra istedi�iniz di�er tepkileri buraya ekleyebilirsiniz
        }
    }
}
