using UnityEngine;
public class Customize : MonoBehaviour
{
    public MaterialChanger carMenu;
    public void ChangeMaterial(){
        GameManager.instance.activeMaterial = carMenu.body.material;
        
        SceneManagement.instance.LoadSceneMgr(Cscene.MainMenu);
    }
}
