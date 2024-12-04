using UnityEngine;

public class DisparoAleatorio : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform[] puntosDisparo;
    public float intervaloDisparo = 2f; // Intervalo de tiempo entre cada disparo
    public float velocidadBala = 10f;   // Velocidad de la bala
    private float tiempoUltimoDisparo;

    private void Start()
    {
        tiempoUltimoDisparo = Time.time;
    }

    private void Update()
    {
        // Verifica si es tiempo de disparar
        if (Time.time >= tiempoUltimoDisparo + intervaloDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void Disparar()
    {
        if (prefabBala == null)
        {
            Debug.LogError("El prefab de la bala no está asignado en el inspector.");
            return;
        }

        if (puntosDisparo == null || puntosDisparo.Length == 0)
        {
            Debug.LogError("No se han asignado puntos de disparo.");
            return;
        }

        // Elige un punto de disparo aleatorio
        int indicePunto = Random.Range(0, puntosDisparo.Length);
        Transform puntoDisparo = puntosDisparo[indicePunto];

        // Instancia el prefab de bala en el punto de disparo seleccionado
        GameObject balaInstanciada = Instantiate(prefabBala, puntoDisparo.position, Quaternion.identity);

        // Accede al componente Rigidbody de la bala instanciada y aplica una velocidad
        Rigidbody rbBala = balaInstanciada.GetComponent<Rigidbody>();
        if (rbBala != null)
        {
            // Aplica una velocidad hacia adelante (en el eje local del punto de disparo)
            rbBala.velocity = puntoDisparo.forward * velocidadBala;
        }
        else
        {
            Debug.LogWarning("La bala instanciada no tiene un Rigidbody. Asegúrate de añadir uno si quieres aplicar velocidad.");
        }
    }
}
