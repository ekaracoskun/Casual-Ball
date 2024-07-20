using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 startDragPosition;
    private Vector2 endDragPosition;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endDragPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 force = (endDragPosition - startDragPosition) * 10; // Kuvvet çarpaný
            rb.AddForce(force, ForceMode2D.Impulse);
            isDragging = false;
        }
    }
}
