using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string currentLevel; // Almacena el nivel actual

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Destruir la nueva instancia si ya existe
        }
    }

    public void PlayerDied()
    {
        currentLevel = SceneManager.GetActiveScene().name; // Guardar el nivel actual
        LoadGameOverScene();
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene"); // Aseg�rate de que el nombre coincide
        Cursor.visible = true; // Aseg�rate de que el cursor sea visible
        Cursor.lockState = CursorLockMode.None; // Aseg�rate de que el cursor no est� bloqueado
    }

    public void RestartLevel()
    {
        Debug.Log("El bot�n de reiniciar fue presionado.");
        Debug.Log("Reiniciando la escena: " + currentLevel); // Imprime el nombre del nivel guardado
        Cursor.visible = true; // Aseg�rate de que el cursor sea visible
        Cursor.lockState = CursorLockMode.None; // Aseg�rate de que el cursor no est� bloqueado
        SceneManager.LoadScene(currentLevel); // Reinicia el nivel guardado
    }

    public void ResetGame()
    {
        Cursor.visible = true; // Aseg�rate de que el cursor sea visible
        Cursor.lockState = CursorLockMode.None; // Aseg�rate de que el cursor no est� bloqueado
        SceneManager.LoadScene("MainMenu"); // Cambia al men� principal
    } 
 }