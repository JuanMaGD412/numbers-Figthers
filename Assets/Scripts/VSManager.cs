using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class VSManager : MonoBehaviour
{
    public static VSManager Instance;

    [Header("VS UI")]
    public GameObject vsCanvas;
    public Image imgJugador;
    public Image imgRival;

    [Header("Sprites VS")]
    public Sprite[] spritesVS;

    [Header("Fade")]
    public Image fade;
    public float fadeSpeed = 1.5f;

    private void Awake()
    {
        Instance = this;

        vsCanvas.SetActive(false);
        fade.gameObject.SetActive(false);
    }

    public void MostrarVS()
    {
        StartCoroutine(VSTransition());
    }

    IEnumerator VSTransition()
    {
        
        GameManager.Instance.personajeRival =
            Random.Range(0, spritesVS.Length);

        
        imgJugador.sprite =
            spritesVS[GameManager.Instance.personajeSeleccionado];

        imgRival.sprite =
            spritesVS[GameManager.Instance.personajeRival];

        vsCanvas.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        fade.gameObject.SetActive(true);
        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene("Mapa1");

    }

    IEnumerator FadeOut()
    {
        Color c = fade.color;
        c.a = 0;
        fade.color = c;

        while (fade.color.a < 1)
        {
            c.a += Time.deltaTime * fadeSpeed;
            fade.color = c;
            yield return null;
        }
    }
}
