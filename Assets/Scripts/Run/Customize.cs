using UnityEngine;

public class Customize : MonoBehaviour
{
    public CarMenu carMenu;
    public void ChangeMaterial(){
        GameManager.instance.activeMaterial = carMenu.body.material;
        
        SceneManagement.instance.LoadSceneMgr(Cscene.MainMenu);
        //playerMovement.meshRenderer.material = carMenu.body.material;
    }
}
