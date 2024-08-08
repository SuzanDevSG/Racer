using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public static AudioManagement instance;

    public AudioSource audioSource;


    public void Awake()
    {
        if( instance == null )
            instance = this;

        else if( instance != null && instance != this)
            Destroy(instance);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
