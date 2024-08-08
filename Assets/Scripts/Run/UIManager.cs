using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{   
    public GameObject[] mainMenuPanel;
    private GameManager gameManager;
    private SceneManagement sceneManagement;

    private void Start()
    {
        gameManager = GameManager.instance;
        sceneManagement = SceneManagement.instance;
    }
    public void LoadMainMenuScene(){
        sceneManagement.LoadSceneMgr(Cscene.MainMenu);
    }
    public void LoadCustomizeScene(){
        sceneManagement.LoadSceneMgr(Cscene.Customize);
    }
    public void LoadEasy_Level1Scene()
    {
        sceneManagement.LoadSceneMgr(Cscene.Easy_Level1);
    }
    public void LoadEasy_Level2Scene()
    {
        sceneManagement.LoadSceneMgr(Cscene.Easy_Level2);
    }
    public void LoadNormal_Level1()
    {
        sceneManagement .LoadSceneMgr(Cscene.Normal_Level1);
    }
    public void LoadNormal_Level2()
    {
        sceneManagement.LoadSceneMgr(Cscene.Normal_Level2);
    }
    public void LoadHard_Level1()
    {
        sceneManagement.LoadSceneMgr(Cscene.Hard_Level1);
    }
    public void LoadHard_Level2()
    {
        sceneManagement.LoadSceneMgr(Cscene.Hard_Level2);
    }
    public void LoadChooseLevelPanel()
    {
        mainMenuPanel[1].SetActive(true);
    }
    public void LoadMainMenuPanelFromDifferentPanel()
    {
        mainMenuPanel[2].SetActive(false);
        mainMenuPanel[1].SetActive(false);
    }
    public void LoadSettingsPanel()
    {
        mainMenuPanel[2].SetActive(true);
    }
    public void LoadExitPanel()
    {
        //mainMenuPanel[0].SetActive(false);
        mainMenuPanel[3].SetActive(true);
    }
    public void QuitYes()
    {
        sceneManagement.QuitYes();
    }
    public void QuitNo()
    {
        mainMenuPanel[3].SetActive(false);
    }







    
}
