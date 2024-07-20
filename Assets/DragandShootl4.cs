using UnityEngine;

public class DragAndShootL4 : MonoBehaviour
{
    public float maxPower = 20f; // Maksimum çekme gücü
    public float minPower = 5f; // Minimum çekme gücü
    public float maxDragDistance = 5f; // Maksimum çekme mesafesi
    public float drag = 2f; // Lineer sürtünme kuvveti
    public float angularDrag = 2f; // Açýsal sürtünme kuvveti
    [SerializeField] private Rigidbody2D rb; // Rigidbody2D bileþeninin atanmasý
    [SerializeField] private LineRenderer lineRenderer; // Çizgi görseli için LineRenderer bileþeni

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 direction;
    private bool isDragging = false;
    private bool isMoving = false;

    void Start()
    {
        // LineRenderer bileþeninin ayarlarý
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false; // Baþlangýçta gizli

        // Sürtünme kuvvetlerini ayarla
        rb.drag = drag;
        rb.angularDrag = angularDrag;
    }

    void Update()
    {
        // Topun hareket edip etmediðini kontrol et
        if (rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Top hareket halindeyken çekilemez
        if (isMoving)
        {
            isDragging = false;
            lineRenderer.enabled = false; // Çizgiyi gizle
            return; // Top hareketliyken geriye kalan kodu çalýþtýrma
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Dokunma baþlangýcý
                startPos = Camera.main.ScreenToWorldPoint(touch.position);
                isDragging = true;
                lineRenderer.enabled = true; // Çizgiyi görünür yap
            }

            if (touch.phase == TouchPhase.Ended && isDragging)
            {
                // Dokunma býrakýldý
                endPos = Camera.main.ScreenToWorldPoint(touch.position);
                direction = startPos - endPos;

                // Çekme mesafesini sýnýrla
                float magnitude = direction.magnitude;
                float clampedMagnitude = Mathf.Clamp(magnitude, 0f, maxDragDistance);

                // Güç hesaplama
                float powerFactor = clampedMagnitude / maxDragDistance;
                float power = Mathf.Lerp(minPower, maxPower, powerFactor);

                // Yönlendirilmiþ güç uygula
                rb.velocity = Vector2.zero; // Önceki hareketi durdur
                rb.AddForce(direction.normalized * power, ForceMode2D.Impulse);
                isDragging = false;
                lineRenderer.enabled = false; // Çizgiyi gizle
            }

            // Çizim ve görsel geribildirim için
            if (isDragging && touch.phase == TouchPhase.Moved)
            {
                Vector2 currentPos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 drawDirection = (startPos - currentPos).normalized * Mathf.Min((startPos - currentPos).magnitude, maxDragDistance);

                // Çizgi görselini güncelle
                lineRenderer.SetPosition(0, startPos);
                lineRenderer.SetPosition(1, startPos - drawDirection);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Momentum ve hýz aktarýmý hesaplamasý
            Vector2 velocityAfterCollision = CalculateVelocityAfterCollision(rb, otherRb);

            rb.velocity = velocityAfterCollision;
        }
    }

    private Vector2 CalculateVelocityAfterCollision(Rigidbody2D rb1, Rigidbody2D rb2)
    {
        // Ýki topun hýzlarýný al
        Vector2 v1 = rb1.velocity;
        Vector2 v2 = rb2.velocity;

        // Kütleleri al
        float m1 = rb1.mass;
        float m2 = rb2.mass;

        // Momentum ve enerji korunumu prensiplerine göre yeni hýzlarý hesapla
        Vector2 newV1 = ((m1 - m2) / (m1 + m2)) * v1 + ((2 * m2) / (m1 + m2)) * v2;

        return newV1;
    }

    // isMoving deðiþkenini dýþarýdan ayarlayabilmek için bir yöntem
    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
    }
}
