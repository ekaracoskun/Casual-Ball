using UnityEngine;

public class GravityWall : MonoBehaviour
{
    public float gravityStrength = 10f;  // Çekim kuvvetinin gücü
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
            // Oyuncu ve duvar arasýndaki yönü hesapla
            Vector2 direction = transform.position - player.transform.position;

            // Oyuncuya doðru kuvvet uygula
            player.GetComponent<Rigidbody2D>().AddForce(direction.normalized * gravityStrength);
        }
    }
}
