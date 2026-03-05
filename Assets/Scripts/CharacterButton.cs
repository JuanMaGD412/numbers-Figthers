using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButton : MonoBehaviour
{
    public int idPersonaje;


    public void SeleccionarPersonaje()
    {
        GameManager.instance.personajeElegido = idPersonaje;
        SceneManager.LoadScene("Mapa1");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
