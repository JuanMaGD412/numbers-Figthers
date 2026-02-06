using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterButton1V2 : MonoBehaviour
{
    public int idPersonaje;
    public void Seleccionar()
    {
        GameManager.Instance.personajeSeleccionado = idPersonaje;
        VSManager.Instance.MostrarVS();
    }
}