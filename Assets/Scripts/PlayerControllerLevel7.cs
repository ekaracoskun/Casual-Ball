using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickL1 : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Baþlangýç pozisyonunu sakla
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
            transform.position = startPosition; // Baþlangýç pozisyonuna dön
            rb.velocity = Vector2.zero; // Hýzý sýfýrla
        }
    }
}
