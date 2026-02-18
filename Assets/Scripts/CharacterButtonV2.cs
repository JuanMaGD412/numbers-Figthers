using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButtonV2 : MonoBehaviour
{
    public int idPersonaje;


    public void SeleccionarPersonajeV2()
    {
        GameManager.instance.personajeElegido = idPersonaje;
        VSManager.Instance.MostrarVS();
    }
}
