using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f; // Velocidad a la que seguirá al jugador
    public float stoppingDistance = 2f; // Distancia a la que dejará de seguir al jugador

    private Transform target; // Referencia al transform del jugador

    void Start()
    {
        // Al iniciar, obtenemos la referencia al jugador (asumiendo que tiene una etiqueta "Player")
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculamos la distancia entre el enemigo y el jugador
        float distance = Vector2.Distance(transform.position, target.position);

        // Si el jugador está dentro del radio de detección
        if (distance < stoppingDistance)
        {
            // Movemos al enemigo hacia el jugador
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
