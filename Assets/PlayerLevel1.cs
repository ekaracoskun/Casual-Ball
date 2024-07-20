using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli

public class JoyL1 : MonoBehaviour
{
    public Joystick movementJoystick; // Joystick bile�eni
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Ba�lang�� pozisyonunu sakla

        // Joystick'in atan�p atanmad���n� kontrol et
        if (movementJoystick == null)
        {
            Debug.LogError("Joystick atamas� yap�lmam��!");
        }
    }

    private void FixedUpdate()
    {
        // Joystick'in hareket y�n�n� al
        Vector2 joystickDirection = movementJoystick.Direction;

        // Joystick b�rak�ld���nda h�z� s�f�rla
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
        if (collision.gameObject.CompareTag("Wall")) // Duvara �arpma kontrol�
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Mevcut sahneyi yeniden y�kle
        }
    }
}
