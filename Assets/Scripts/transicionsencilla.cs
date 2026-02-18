using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class transicionsencilla : MonoBehaviour
{
    public CanvasGroup cg;
    public Image fadeImage;
    public float fadeDuration = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void fadeToScene(int indexScene)
    {
        StartCoroutine(FadeOut(indexScene));
    }

    IEnumerator FadeIn()
    {
        cg.blocksRaycasts = true;
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = 1 - t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0f;
        fadeImage.color = color;
        cg.blocksRaycasts = false;
    }

    IEnumerator FadeOut(int indexScene)
    {
        cg.blocksRaycasts = true;
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(indexScene);
    }
}
