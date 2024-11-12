using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToOptionsMenu : MonoBehaviour
{
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("opciones" ); // Cambia "NombreDeLaEscenaOpciones" por el nombre exacto de la escena de opciones
    }
}
