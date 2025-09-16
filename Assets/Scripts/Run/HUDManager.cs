using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance { private set; get; }
    public GameObject[] HUD;
    public GameObject[] pauseMenu;
    public GameObject[] InGameTriggeredPanel;

    public Button[] GameOverButtons;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void LoadPauseMenu()
    {
        pauseMenu[0].SetActive(false);
        Time.timeScale = 0f;
        pauseMenu[1].SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu[1].SetActive(false);
        pauseMenu[0].SetActive(false);

    }

    public void LoadSettingsPanel()
    {
        pauseMenu[2].SetActive(true);
    }

    public void LoadMainMenuScene()
    {
        SceneManagement.instance.LoadSceneMgr(Cscene.MainMenu);
        Time.timeScale = 1f;
    }
    public void LoadQuitPanel()
    {
        pauseMenu[3].SetActive(true);
    }
    public void LoadPauseMenuFromOptions()
    {
        pauseMenu[2].SetActive(false);
        pauseMenu[3].SetActive(false);
    }

    public void QuitYes()
    {
        SceneManagement.instance.QuitYes();
    }
    public void Restart()
    {
        SceneManagement.instance.Restart();
        Time.timeScale = 1f;
    }
    public void LoadNextLevelScene()
    {
        SceneManagement.instance.NextLevelScene();
    }
}
