using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToControlsMenu : MonoBehaviour
{
    public void LoadControlsMenu()
    {
        SceneManager.LoadScene("Controles"); // Cambia "NombreDeLaEscenaControles" por el nombre exacto de la escena de controles
    }
}