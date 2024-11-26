using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class Meta : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        // Verifica si el objeto que toca la meta es el jugador
        if (collision.CompareTag("Player"))
        {
            CambiarAlSiguienteNivel();
        }
    }

    private void CambiarAlSiguienteNivel()
    {
        int siguienteEscenaIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Verifica si la siguiente escena existe en el Build Settings
        if (siguienteEscenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscenaIndex); // Carga la siguiente escena
        }
        else
        {
            Debug.LogWarning("No hay más niveles. ¡El juego ha terminado!");
        }
    }
}
