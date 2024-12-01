using System.Collections;
using UnityEngine;

public class HongoDurmiente : MonoBehaviour
{
    [Header("Configuración del Hongo")]
    public float rangoAtaque = 5f; // Distancia en la que el hongo detecta al jugador
    public float tiempoParaAtacar = 2f; // Tiempo que debe permanecer el jugador en rango para ser atacado
    public GameObject esporaPrefab; // Prefab de la espora tóxica
    public Transform puntoDisparo; // Lugar desde donde se disparan las esporas
    public float velocidadEspora = 5f; // Velocidad de las esporas

    private Transform jugador;
    private bool jugadorEnRango = false;
    private float tiempoEnRango = 0f;

    void Update()
    {
        if (jugador != null)
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);

            if (distancia <= rangoAtaque)
            {
                jugadorEnRango = true;
                tiempoEnRango += Time.deltaTime;

                if (tiempoEnRango >= tiempoParaAtacar)
                {
                    Atacar();
                    tiempoEnRango = 0f; // Reinicia el temporizador
                }
            }
            else
            {
                jugadorEnRango = false;
                tiempoEnRango = 0f; // Reinicia el temporizador si el jugador sale del rango
            }
        }
    }

    private void Atacar()
    {
        if (esporaPrefab != null && puntoDisparo != null)
        {
            GameObject espora = Instantiate(esporaPrefab, puntoDisparo.position, Quaternion.identity);
            Rigidbody rb = espora.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector2 direccion = (jugador.position - puntoDisparo.position).normalized;
                rb.velocity = direccion * velocidadEspora;
            }
            Destroy(espora, 5f); // Destruye la espora después de 5 segundos
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugador = collision.transform; // Guarda la referencia del jugador
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugador = null; // El jugador ya no está en rango
            jugadorEnRango = false;
            tiempoEnRango = 0f; // Reinicia el temporizador
        }
    }
}
