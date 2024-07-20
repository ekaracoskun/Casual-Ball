using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBenja : MonoBehaviour
{
    public float speed;
    public float distance;
    public LineRenderer lineRenderer;

    public Vector2 safeArea;

    private void Start()
    {


        lineRenderer = GetComponent<LineRenderer>();

        // LineRenderer bileþeninin çizgi özelliklerini ayarla
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.positionCount = 2; // Ýki noktalý bir çizgi olacak
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hit.collider != null)
        {
            Debug.Log("Hit: " + hit.collider.name);
            if (hit.collider.CompareTag("Player"))
            {
                GameObject.FindWithTag("Player").transform.position = safeArea;

            }

            // LineRenderer için çizgi noktalarýný ve rengini ayarla
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

        }
        else
        {


            // LineRenderer için çizgi noktalarýný ve rengini ayarla
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.right * distance);

        }
    }
}
