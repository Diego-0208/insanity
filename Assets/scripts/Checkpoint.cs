using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Vector3 lastCheckpointPosition; // Guarda la última posición del checkpoint activado.

    private void OnTriggerEnter(Collider collision)
    {
        // Verifica si el jugador toca el checkpoint.
        if (collision.CompareTag("Player"))
        {
            // Guarda la posición del checkpoint actual.
            lastCheckpointPosition = transform.position;
            Debug.Log("Checkpoint activado en: " + lastCheckpointPosition);
        }
    }

    public static Vector3 GetCheckpointPosition()
    {
        // Devuelve la última posición del checkpoint.
        return lastCheckpointPosition;
    }
}
