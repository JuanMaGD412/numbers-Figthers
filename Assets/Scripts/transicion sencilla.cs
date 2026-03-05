using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class transicionsencilla : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(int indexScene)
    {
        StartCoroutine(FadeOut(indexScene));
    }


IEnumerator FadeIn()
    {
        float t = 0f;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = 1 - (t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }
        color.a = 0;
        fadeImage.color = color;
    }

    IEnumerator FadeOut(int indexScene)
    {
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
