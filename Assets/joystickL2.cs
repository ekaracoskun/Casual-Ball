using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMoveL2 : MonoBehaviour
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
        if (movementJoystick.Direction.y != 0)
        {
            rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") // Duvara çarpma kontrolü
        {
            transform.position = startPosition; // Baþlangýç pozisyonuna dön
            rb.velocity = Vector2.zero; // Hýzý sýfýrla
        }
    }
}
