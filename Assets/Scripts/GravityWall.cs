using UnityEngine;

public class GravityWall : MonoBehaviour
{
    public float gravityStrength = 10f;  // �ekim kuvvetinin g�c�
    private GameObject player;  // Oyuncu nesnesi

    void Start()
    {
        // Oyuncu nesnesini bul
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Oyuncu ve duvar aras�ndaki y�n� hesapla
            Vector2 direction = transform.position - player.transform.position;

            // Oyuncuya do�ru kuvvet uygula
            player.GetComponent<Rigidbody2D>().AddForce(direction.normalized * gravityStrength);
        }
    }
}
