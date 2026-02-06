using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void ChangeEscena ( int indiceEscena )
    {
        SceneManager.LoadScene( indiceEscena );
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
