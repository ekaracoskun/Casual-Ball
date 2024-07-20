using UnityEngine;

public class GyroControlB3new : MonoBehaviour
{
    public float speedMultiplier = 10.0f;
    public float maxSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public GameManager gameManager; // GameManager referans�

    void Start()
    {
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody2D>();

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

        // Kamera s�n�rlar�na �arpma kontrol�
        if (transform.position.x <= screenBounds.x * -1 || transform.position.x >= screenBounds.x ||
            transform.position.y <= screenBounds.y * -1 || transform.position.y >= screenBounds.y)
        {
            gameManager.ResetBalls();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameManager.ResetBalls();
        }
    }
}

