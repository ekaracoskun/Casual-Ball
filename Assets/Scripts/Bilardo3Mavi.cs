using UnityEngine;

public class GyroControl : MonoBehaviour
{
    public float speedMultiplier = 10.0f;
    public float maxSpeed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        Input.gyro.enabled = true;
        rb = GetComponent<Rigidbody2D>();

        // Kamera sýnýrlarýný hesapla
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        // Ekranýn eðimine göre hareket vektörü hesaplama
        Vector3 gyroRotation = Input.gyro.gravity;
        Vector2 movement = new Vector2(gyroRotation.x, gyroRotation.y) * speedMultiplier;

        // Topa kuvvet uygulama
        rb.AddForce(movement);

        // Topun hýzýný sýnýrla
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Topun kamera sýnýrlarý dýþýna çýkmasýný önle
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewPos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Eðer collider ile çarpýþma olursa, hareketi durdur
        rb.velocity = Vector2.zero;
    }
}
