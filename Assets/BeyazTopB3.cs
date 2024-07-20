using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMoveB3beyaz : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;
    public GameManager gameManager; // GameManager referansý
    private Vector2 screenBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Kamera sýnýrlarýný hesapla
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
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

        // Kamera sýnýrlarýna çarpma kontrolü
        if (transform.position.x <= screenBounds.x * -1 || transform.position.x >= screenBounds.x ||
            transform.position.y <= screenBounds.y * -1 || transform.position.y >= screenBounds.y)
        {
            gameManager.ResetBalls();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameManager.ResetBalls();
        }
    }
}
