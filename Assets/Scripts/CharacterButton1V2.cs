using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterButton1V2 : MonoBehaviour
{
    public int idPersonaje;
    public void Seleccionar()
    {
        GameManager.instance.personajeElegido = idPersonaje;
        VSManager.Instance.MostrarVS();
    }
}