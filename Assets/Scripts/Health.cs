using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int vidaMaxima = 100;
    public int vidaActual;

    public Image barraVida;

    float vidaSuavizada;
    Color colorOriginal;
    void Start()
    {
        vidaActual = vidaMaxima;
        vidaSuavizada = 1f;

        colorOriginal = barraVida.color;
    }

    // Update is called once per frame
    void Update()
    {
        float target = (float)vidaActual / vidaMaxima;
        vidaSuavizada = Mathf.Lerp(vidaSuavizada, target, Time.deltaTime * 5f);
        barraVida.fillAmount = vidaSuavizada;
    }

    public void RecibirDano(int dmg)
    {
        vidaActual -= dmg;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        barraVida.color = Color.red;
        Invoke(nameof(VolverColor), 0.5f);
    }

    void VolverColor()
    {
        barraVida.color = colorOriginal;
    }
}
