using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI estadoTexto;

    private FirebaseAuth auth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                estadoTexto.text = "conectado A Firebase";
            }
            else
            {
                Debug.LogError("Error en la conexión con la base de datos.");
            }
        });
    }

    public void IniciarSesion()
    {
        auth.SignInWithEmailAndPasswordAsync(
            emailInput.text,
            passwordInput.text
        ).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                estadoTexto.text = "Login correcto";
                SceneManager.LoadScene("Inicio");
            }
            else
            {
                estadoTexto.text = "Credenciales incorrectas";
            }
        });
    }
}
