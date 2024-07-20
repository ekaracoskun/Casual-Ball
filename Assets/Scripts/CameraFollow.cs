using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Takip edilecek hedef (oyuncu)
    public float smoothSpeed = 0.125f;  // Kameran�n takip h�z�
    public Vector3 offset;  // Kameran�n oyuncuya g�re ofseti

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
