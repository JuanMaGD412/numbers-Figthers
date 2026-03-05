using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena2 : MonoBehaviour
{
    public void CambiarEscena (int indiceEscena)
    {
        SceneManager.LoadScene(indiceEscena);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
