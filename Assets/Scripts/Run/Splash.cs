using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetActiveSplashKey()
    {
        text.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (Input.anyKeyDown == true)
        {
            SceneManagement.instance.LoadSceneMgr(Cscene.MainMenu);
        }
    }
}
