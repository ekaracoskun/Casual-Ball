using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;
    public Button level6Button;
    public Button level7Button;
    public Button level8Button;
    public Button level9Button; 

    void Start()
    {
        level1Button.onClick.AddListener(() => LoadLevel("Level1"));
        level2Button.onClick.AddListener(() => LoadLevel("Level2"));
        level3Button.onClick.AddListener(() => LoadLevel("Level3"));
        level4Button.onClick.AddListener(() => LoadLevel("Level4"));
        level5Button.onClick.AddListener(() => LoadLevel("Level5"));
        level6Button.onClick.AddListener(() => LoadLevel("Level6"));
        level7Button.onClick.AddListener(() => LoadLevel("Level7"));
        level8Button.onClick.AddListener(() => LoadLevel("Level8"));
        level9Button.onClick.AddListener(() => LoadLevel("Level9"));
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
