using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject leftWall;
    public GameObject rightWall;

    private Camera mainCamera;
    private float wallThickness = 1f;

    void Start()
    {
        mainCamera = Camera.main;

        Vector3 cameraPosition = mainCamera.transform.position;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // �st duvar
        topWall.transform.position = new Vector3(cameraPosition.x, cameraPosition.y + cameraHeight / 2 + wallThickness / 2, 0);
        topWall.transform.localScale = new Vector3(cameraWidth, wallThickness, 1);

        // Alt duvar
        bottomWall.transform.position = new Vector3(cameraPosition.x, cameraPosition.y - cameraHeight / 2 - wallThickness / 2, 0);
        bottomWall.transform.localScale = new Vector3(cameraWidth, wallThickness, 1);

        // Sol duvar
        leftWall.transform.position = new Vector3(cameraPosition.x - cameraWidth / 2 - wallThickness / 2, cameraPosition.y, 0);
        leftWall.transform.localScale = new Vector3(wallThickness, cameraHeight, 1);

        // Sa� duvar
        rightWall.transform.position = new Vector3(cameraPosition.x + cameraWidth / 2 + wallThickness / 2, cameraPosition.y, 0);
        rightWall.transform.localScale = new Vector3(wallThickness, cameraHeight, 1);
    }
}
