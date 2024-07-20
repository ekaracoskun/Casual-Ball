using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class JoyL1 : MonoBehaviour
{
    public Joystick movementJoystick; // Joystick bileþeni
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Baþlangýç pozisyonunu sakla

        // Joystick'in atanýp atanmadýðýný kontrol et
        if (movementJoystick == null)
        {
            Debug.LogError("Joystick atamasý yapýlmamýþ!");
        }
    }

    private void FixedUpdate()
    {
        // Joystick'in hareket yönünü al
        Vector2 joystickDirection = movementJoystick.Direction;

        // Joystick býrakýldýðýnda hýzý sýfýrla
        if (joystickDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = joystickDirection * playerSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // Duvara çarpma kontrolü
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden yükle
        }
    }
}
