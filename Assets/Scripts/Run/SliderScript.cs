using UnityEngine;
using UnityEngine.UI;


public class SliderScript : MonoBehaviour
{
    public Toggle toggle;
    private AudioSource source;

    void Start()
    {
        source = AudioManagement.instance.audioSource;
    }
    void Update()
    {
        ChangeValue(toggle.isOn);
    }
    public void ChangeValue(bool value){
        source.mute = !value;
    }

}
