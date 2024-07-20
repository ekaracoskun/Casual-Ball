using UnityEngine;
using System.Collections;

public class HoleController : MonoBehaviour
{
    private ManagerB4 managerB4;
    public float delayBeforeLosePanel = 1f;

    void Start()
    {
        managerB4 = FindObjectOfType<ManagerB4>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBall"))
        {
            StartCoroutine(PlayerBallPocketed(other.gameObject));
        }
        else if (other.CompareTag("BlackBall"))
        {
            if (managerB4.totalOtherBalls > 0)
            {
                StartCoroutine(PlayerBallPocketed(other.gameObject)); // Siyah top girerse ve hala diðer toplar varsa oyunu kaybet
            }
            else
            {
                StartCoroutine(BallPocketed(other.gameObject, () => managerB4.BlackBallPocketed())); // Tüm diðer toplar girdiðinde siyah topu sok
            }
        }
        else if (other.CompareTag("OtherBall"))
        {
            StartCoroutine(BallPocketed(other.gameObject, () => managerB4.OtherBallPocketed(other.gameObject)));
        }
    }

    private IEnumerator PlayerBallPocketed(GameObject ball)
    {
        Vector3 holePosition = transform.position;
        float moveDuration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            ball.transform.position = Vector3.Lerp(ball.transform.position, holePosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(delayBeforeLosePanel);

        managerB4.ShowLosePanel();
        Destroy(ball);
    }

    private IEnumerator BallPocketed(GameObject ball, System.Action callback)
    {
        Vector3 holePosition = transform.position;
        float moveDuration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            ball.transform.position = Vector3.Lerp(ball.transform.position, holePosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(delayBeforeLosePanel);

        callback();
        Destroy(ball);
    }
}
