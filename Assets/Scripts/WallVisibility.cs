using System.Collections;
using UnityEngine;

public class WallVisibility : MonoBehaviour
{
    public float toggleInterval = 3f;  // Duvar�n g�r�n�r ve g�r�nmez olma s�resi

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
