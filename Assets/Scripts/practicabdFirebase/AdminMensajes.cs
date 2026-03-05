using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;


public class AdminMensajes : MonoBehaviour
{
    public TMP_InputField inputMensaje;
    public TextMeshProUGUI estadoTexto;

    private DatabaseReference referencia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                referencia = FirebaseDatabase.DefaultInstance.GetReference("Mensaje");
                estadoTexto.text = "conectado A Firebase";
            }
            else
            {
                Debug.LogError("Error en la conexión con la base de datos.");
            }
        });
    }

   public void ActualizarMensaje()
    {
        if (string.IsNullOrEmpty(inputMensaje.text))
        {
            estadoTexto.text = "Mensaje Vacio";
            return;
        }
        referencia.SetValueAsync(inputMensaje.text).ContinueWithOnMainThread(task=>
        {
            if (task.IsCompleted)
            {
                estadoTexto.text = "Mensaje Actualizado";
            }
            else
            {
                estadoTexto.text = " Error al actualizar";
            }
        });
        
    }
}
