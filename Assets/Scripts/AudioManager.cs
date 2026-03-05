using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance= this;
        DontDestroyOnLoad(gameObject);
    } 
}
