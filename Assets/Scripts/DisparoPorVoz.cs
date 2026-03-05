using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
public class DisparoPorVoz : MonoBehaviour
{
    public GameObject proyectil;
    public Transform puntoDisparo;

    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> acciones = new Dictionary<string, System.Action>();

    void Start()
    {
        Debug.Log("Micrófonos disponibles: " + Microphone.devices.Length);
        acciones.Add("Fuego", Disparar);
        keywordRecognizer = new KeywordRecognizer(acciones.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += Reconocido;
        keywordRecognizer.Start();
    }

    void Reconocido(PhraseRecognizedEventArgs e)
    {
        acciones[e.text].Invoke();
    }

    
    void Disparar()
    {
        Instantiate(proyectil, puntoDisparo.position, puntoDisparo.rotation);
        Debug.Log("FUEEEEEGOOOOOO");

    }
}