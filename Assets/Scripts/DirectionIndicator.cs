using UnityEngine;
using UnityEngine.UI;

public class DirectionIndicator : MonoBehaviour
{
    public Transform player;  // Oyuncu transformu
    public Transform target;  // Hedef transformu
    public Image indicator;  // Ok göstergesi
    public float edgeBuffer = 50f;  // Ekran kenarlarý için tampon alan

    private RectTransform canvasRect;

    void Start()
    {
        canvasRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(target.position);
        Vector3 direction = target.position - player.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        indicator.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (screenPoint.z < 0)
        {
            screenPoint *= -1;
        }

        screenPoint.x = Mathf.Clamp(screenPoint.x, edgeBuffer, Screen.width - edgeBuffer);
        screenPoint.y = Mathf.Clamp(screenPoint.y, edgeBuffer, Screen.height - edgeBuffer);

        indicator.rectTransform.position = screenPoint;
    }
}

