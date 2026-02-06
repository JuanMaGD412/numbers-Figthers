using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterButton : MonoBehaviour
{
    public int idPersonaje;
    public void Seleccionar()
    {
        GameManager.Instance.personajeSeleccionado = idPersonaje;
        SceneManager.LoadScene("Mapa1");
    }
}