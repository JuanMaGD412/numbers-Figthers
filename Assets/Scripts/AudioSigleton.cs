using UnityEngine;

public class AudioSigleton : MonoBehaviour
{
    public static AudioSigleton Instance;
   public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
