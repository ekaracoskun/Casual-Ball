using UnityEngine;

public class DragAndShootforBilardo2 : MonoBehaviour
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
    private bool hasThrown = false;
    private bool gameOver = false; // Oyun bitiþ durumu
    private bool isPaused = false; // Oyun duraklatma durumu

    void Start()
    {
        // LineRenderer bileþeninin ayarlarý
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false; // Baþlangýçta gizli

        // Sürtünme kuvvetlerini ayarla
        rb.drag = drag;
        rb.angularDrag = angularDrag;

        // Topun baþlangýç pozisyonunu kaydet
        startPos = rb.position;
    }

    void Update()
    {
        // Oyunun duraklatýlýp duraklatýlmadýðýný kontrol et
        if (isPaused)
        {
            return; // Oyunun duraklatýldýðýný kontrol et
        }

        // Topun hareket edip etmediðini kontrol et
        if (rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Oyun bittiðinde veya atýþ yapýldýktan sonra topu çekilemez hale getir
        if (gameOver || hasThrown)
        {
            return; // Oyunun sonlandýðýný kontrol et
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

                hasThrown = true; // Topu fýrlattýðýmýzý iþaretle
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

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.position = startPos;
        gameOver = false;
        hasThrown = false;
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // Oyunu duraklat
        hasThrown = false; // Duraklatýldýðýnda atýþ durumunu sýfýrla
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // Oyunu devam ettir
    }
}
