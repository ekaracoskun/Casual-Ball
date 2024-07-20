using System.Collections;
using UnityEngine;

public class WallVisibility : MonoBehaviour
{
    public float toggleInterval = 3f;  // Duvarýn görünür ve görünmez olma süresi

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }
}
