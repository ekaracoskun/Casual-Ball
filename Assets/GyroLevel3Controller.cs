using UnityEngine;

public class GyroLevel3 : MonoBehaviour
{
    public float speedMultiplier = 10.0f;
    public float maxSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private Vector3 startPosition;

    void Start()
    {
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Ba�lang�� pozisyonunu kaydet

        // Kamera s�n�rlar�n� hesapla
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        // Ekran�n e�imine g�re hareket vekt�r� hesaplama
        Vector3 gyroRotation = Input.gyro.gravity;
        Vector2 movement = new Vector2(gyroRotation.x, gyroRotation.y) * speedMultiplier;

        // Topa kuvvet uygulama
        rb.AddForce(movement);

        // Topun h�z�n� s�n�rla
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Topun kamera s�n�rlar� d���na ��kmas�n� �nle
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // Duvara �arparsa ba�lang�� pozisyonuna d�n
            transform.position = startPosition;
            rb.velocity = Vector2.zero; // Hareketi durdur
        }
    }
}
