using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Takip edilecek hedef (oyuncu)
    public float smoothSpeed = 0.125f;  // Kameranýn takip hýzý
    public Vector3 offset;  // Kameranýn oyuncuya göre ofseti

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
