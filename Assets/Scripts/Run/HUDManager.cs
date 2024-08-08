using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class HUDManager : MonoBehaviour
{
    public GameObject[] HUD;
    public GameObject[] pauseMenu; 
    public GameObject[] InGameTriggeredPanel;

    private void Start()
    {
        //InGameTriggeredPanel[0] = GameObject.Find("GameOver");
        //InGameTriggeredPanel[1] = GameObject.Find("FinishLevel");

        //playerEventUI = new GameObject[] { "GameOver", };
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
