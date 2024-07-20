using UnityEngine;

public class DiamondController : MonoBehaviour
{
    private bool top1In = false;
    private bool top2In = false;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Top1"))
        {
            top1In = true;
        }
        else if (other.gameObject.CompareTag("Top2"))
        {
            top2In = true;
        }

        gameManager.CheckWinCondition(top1In, top2In);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Top1"))
        {
            top1In = false;
        }
        else if (other.gameObject.CompareTag("Top2"))
        {
            top2In = false;
        }
    }
}
