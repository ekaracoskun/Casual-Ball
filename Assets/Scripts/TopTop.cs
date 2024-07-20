using UnityEngine;

public class DragAndShootB5 : MonoBehaviour
{
    public float shootForce = 10f;
    private Vector2 startPos;
    private Vector2 endPos;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private int shotsRemaining = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = (startPos - endPos).normalized;
            rb.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
            isDragging = false;
            shotsRemaining--;
            FindObjectOfType<GameManagerB5>().UpdateShotsRemaining(shotsRemaining);

            if (shotsRemaining <= 0)
            {
                FindObjectOfType<GameManagerB5>().GameOver();
            }
        }
    }
}
