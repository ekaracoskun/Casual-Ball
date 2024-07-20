using UnityEngine;

public class LosePanelController : MonoBehaviour
{
    private ManagerB4 managerB4;

    void Start()
    {
        managerB4 = FindObjectOfType<ManagerB4>();
    }

    public void OnRestartButtonClicked()
    {
        managerB4.RestartGame();
    }
}
