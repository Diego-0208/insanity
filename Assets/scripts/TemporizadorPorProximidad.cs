using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TemporizadorPorProximidad : MonoBehaviour
{
    public float tiempoInicial = 10f; // Tiempo en segundos
    public TMP_Text textoTemporizador; // Referencia al TextMeshPro
    public GameObject objetoADestruir; // Objeto a destruir cuando llegue a 0
    public float radioActivacion = 5f; // Radio en el que se activa el temporizador
    public Transform jugador; // Referencia al jugador (con tag "Player")

    private float tiempoRestante;
    private bool dentroDelRadio = false;

    void Start()
    {
        tiempoRestante = tiempoInicial; // Inicia el temporizador
        ActualizarTexto(); // Actualiza el texto al inicio
    }

    void Update()
    {
        VerificarDistancia();

        if (dentroDelRadio && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime; // Resta tiempo
            ActualizarTexto(); // Actualiza el texto en pantalla

            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0; // Evita valores negativos
                DestruirObjeto(); // Llama a la función para destruir el objeto
            }
        }
    }

    void VerificarDistancia()
    {
        if (jugador != null)
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);
            dentroDelRadio = distancia <= radioActivacion; // Verifica si está en el radio
        }
    }

    void ActualizarTexto()
    {
        textoTemporizador.text = tiempoRestante.ToString("F1") + "s"; // Muestra el tiempo con 1 decimal
    }

    void DestruirObjeto()
    {
        if (objetoADestruir != null)
        {
            Destroy(objetoADestruir); // Destruye el objeto
        }
    }
}
