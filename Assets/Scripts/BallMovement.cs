using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 2f;
    public float minY = -5f;
    public float maxY = 5f;

    private Vector3 direction = Vector3.up;
    private bool isMoving = true;

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);

            if (transform.position.y >= maxY)
            {
                direction = Vector3.down;
            }
            else if (transform.position.y <= minY)
            {
                direction = Vector3.up;
            }
        }
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    public void StartMovement()
    {
        isMoving = true;
    }
}
