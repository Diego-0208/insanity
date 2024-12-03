using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instancia;

    void Awake()
    {
        // Verifica si ya existe una instancia de este objeto
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // No destruye este objeto al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruye duplicados
        }
    }
}
