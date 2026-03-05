using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;

public class MostrarMensajes : MonoBehaviour
{
    public TextMeshProUGUI mensajesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                EscucharMensaje();
            }
            else
            {
                Debug.LogError("Error en la conexión con la base de datos.");
            }
        });
    }

    void EscucharMensaje()
    {
        DatabaseReference referencia = FirebaseDatabase.DefaultInstance.GetReference("Mensaje");

        referencia.ValueChanged += (sender, args) =>
        {
            if (args.DatabaseError != null) return;
            if (args.Snapshot.Exists)
            {
                mensajesText.text = args.Snapshot.Value.ToString();
            }
        };
    }
}
