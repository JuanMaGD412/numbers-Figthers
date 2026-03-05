using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class FadeTransition : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    Image img;
    CanvasGroup cg;

    private void Awake()
    {
        img = GetComponent<Image>();
        cg = GetComponent<CanvasGroup>();

        cg.blocksRaycasts = true;
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float a = 1f;
        while (a > 0f)
        {
            a -= Time.deltaTime * fadeSpeed;
            img.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
        cg.blocksRaycasts = false;  
    }

    public void FAdeToScene(int sceneIndex) 
    { 
        StartCoroutine(FadeOut(sceneIndex));
    }
    IEnumerator FadeOut(int sceneIndex)
    {
        float a = 0f;
        cg.blocksRaycasts = true;
        while (a < 1)
        {
            a += Time.deltaTime * fadeSpeed;
            img.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
        SceneManager.LoadScene(sceneIndex);
    }
}
