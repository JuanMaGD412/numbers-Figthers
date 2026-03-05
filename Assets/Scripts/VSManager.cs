using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class VSManager : MonoBehaviour
{
    public static VSManager Instance;

    [Header("Vs prueba UI")]
    public GameObject vsPanel;
    public Image imgJugador;
    public Image imgRival;

    [Header("Sprites Lista")]
    public Sprite[] sprites;

    [Header("Fade")]
    public Image fade;
    public float fadeDuration = 1f;

    public void Awake()
    {
        Instance = this;
        vsPanel.SetActive(false);
        fade.gameObject.SetActive(false);
    }

    public void MostrarVS()
    {
        StartCoroutine(VSTransition());
    }

    IEnumerator VSTransition()
    {
        GameManager.instance.personajeRival = Random.Range(0, sprites.Length);

        imgJugador.sprite = sprites[GameManager.instance.personajeElegido];
        imgRival.sprite = sprites[GameManager.instance.personajeRival];

        vsPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        fade.gameObject.SetActive(true);
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene("Mapa1");
    }

    IEnumerator FadeOut()
    {
       Color c = fade.color;
        c.a = 0; ; 
        fade.color = c;
        while(fade.color.a < 1)
         {
             c.a += Time.deltaTime * fadeDuration;
             fade.color = c;
             yield return null;
          }
    }
}
