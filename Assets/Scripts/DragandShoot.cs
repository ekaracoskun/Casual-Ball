using UnityEngine;

public class DragAndShoot : MonoBehaviour
{
    public float maxPower = 20f; // Maksimum �ekme g�c�
    public float minPower = 5f; // Minimum �ekme g�c�
    public float maxDragDistance = 5f; // Maksimum �ekme mesafesi
    public float drag = 2f; // Lineer s�rt�nme kuvveti
    public float angularDrag = 2f; // A��sal s�rt�nme kuvveti
    [SerializeField] private Rigidbody2D rb; // Rigidbody2D bile�eninin atanmas�
    [SerializeField] private LineRenderer lineRenderer; // �izgi g�rseli i�in LineRenderer bile�eni

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 direction;
    private bool isDragging = false;
    private bool isMoving = false;

    void Start()
    {
        // LineRenderer bile�eninin ayarlar�
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false; // Ba�lang��ta gizli

        // S�rt�nme kuvvetlerini ayarla
        rb.drag = drag;
        rb.angularDrag = angularDrag;
    }

    void Update()
    {
        // Topun hareket edip etmedi�ini kontrol et
        if (rb.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        // Top hareket halindeyken �ekilemez
        if (isMoving)
        {
            isDragging = false;
            lineRenderer.enabled = false; // �izgiyi gizle
            return; // Top hareketliyken geriye kalan kodu �al��t�rma
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Dokunma ba�lang�c�
                startPos = Camera.main.ScreenToWorldPoint(touch.position);
                isDragging = true;
                lineRenderer.enabled = true; // �izgiyi g�r�n�r yap
            }

            if (touch.phase == TouchPhase.Ended && isDragging)
            {
                // Dokunma b�rak�ld�
                endPos = Camera.main.ScreenToWorldPoint(touch.position);
                direction = startPos - endPos;

                // �ekme mesafesini s�n�rla
                float magnitude = direction.magnitude;
                float clampedMagnitude = Mathf.Clamp(magnitude, 0f, maxDragDistance);

                // G�� hesaplama
                float powerFactor = clampedMagnitude / maxDragDistance;
                float power = Mathf.Lerp(minPower, maxPower, powerFactor);

                // Y�nlendirilmi� g�� uygula
                rb.velocity = Vector2.zero; // �nceki hareketi durdur
                rb.AddForce(direction.normalized * power, ForceMode2D.Impulse);
                isDragging = false;
                lineRenderer.enabled = false; // �izgiyi gizle
            }

            // �izim ve g�rsel geribildirim i�in
            if (isDragging && touch.phase == TouchPhase.Moved)
            {
                Vector2 currentPos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 drawDirection = (startPos - currentPos).normalized * Mathf.Min((startPos - currentPos).magnitude, maxDragDistance);

                // �izgi g�rselini g�ncelle
                lineRenderer.SetPosition(0, startPos);
                lineRenderer.SetPosition(1, startPos - drawDirection);
            }
        }
    }

    // isMoving de�i�kenini d��ar�dan ayarlayabilmek i�in bir y�ntem
    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
    }
}
