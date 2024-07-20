using UnityEngine;

public class BendableLineController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    private Vector3[] linePoints;

    void Start()
    {
        // Baþlangýçta iki nokta
        linePoints = new Vector3[2];
        linePoints[0] = new Vector3(-5, 0, 0);
        linePoints[1] = new Vector3(5, 0, 0);

        lineRenderer.positionCount = linePoints.Length;
        lineRenderer.SetPositions(linePoints);

        UpdateCollider();
    }

    void Update()
    {
        // Fare pozisyonunu al
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // Fareye en yakýn noktayý bul
            int closestIndex = 0;
            float closestDistance = Vector3.Distance(mousePos, linePoints[0]);
            for (int i = 1; i < linePoints.Length; i++)
            {
                float distance = Vector3.Distance(mousePos, linePoints[i]);
                if (distance < closestDistance)
                {
                    closestIndex = i;
                    closestDistance = distance;
                }
            }

            // Fareyi en yakýn noktaya ayarla
            linePoints[closestIndex] = mousePos;
            lineRenderer.SetPositions(linePoints);

            UpdateCollider();
        }
    }

    void UpdateCollider()
    {
        Vector2[] colliderPoints = new Vector2[linePoints.Length];
        for (int i = 0; i < linePoints.Length; i++)
        {
            colliderPoints[i] = linePoints[i];
        }
        edgeCollider.points = colliderPoints;
    }
}
