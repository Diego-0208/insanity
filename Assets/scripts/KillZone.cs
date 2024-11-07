using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Destruye el objeto que tiene el tag "Player"
            Destroy(collision.gameObject);
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
