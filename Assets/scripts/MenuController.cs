using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Nombre de la escena del juego principal
    public string gameSceneName = "GameScene"; // Cambia esto por el nombre de la escena de tu juego
    // Nombre de la escena de opciones
    public string optionsSceneName = "OpcionesScene"; // Cambia esto por el nombre de tu escena de opciones

    // Funci�n para el bot�n de "Start"
    public void StartGame()
    {
        // Carga la escena del juego
        SceneManager.LoadScene(gameSceneName);
    }

    // Funci�n para el bot�n de "Opciones"
    public void GoToOptions()
    {
        // Carga la escena de opciones
        SceneManager.LoadScene(optionsSceneName);
    }

    // Funci�n para el bot�n de "Salir"
    public void ExitGame()
    {
        // Sale del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
     