using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codigo_Salud : MonoBehaviour
{
    public float Salud = 100;
    public float SaludMaxima = 100;

    [Header("Interfaz")]
    public Image BarraSalud;
    public Text TextoSalud;

    void Update()
    {
        ActualizarInterfaz();
    }

    public void RecibirDaño(float daño)
    {
        Salud -= daño;

        // Verifica si la salud es menor o igual a cero
        if (Salud <= 0)
        {
            Salud = 0; // Asegúrate de que la salud no sea negativa
            RespawnAtCheckpoint(); // Llama al método para reaparecer en el checkpoint
        }
    }

    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud / SaludMaxima;
        TextoSalud.text = "+" + Salud.ToString("f0");
    }

    private void RespawnAtCheckpoint()
    {
        if (Checkpoint.GetCheckpointPosition() != Vector3.zero)
        {
            transform.position = Checkpoint.GetCheckpointPosition(); // Reaparece en el checkpoint
            Salud = SaludMaxima; // Restaura la salud al máximo
            Debug.Log("Reapareciendo en el último checkpoint...");
        }
        else
        {
            Debug.LogWarning("No hay checkpoints activados. Reapareciendo en el punto inicial.");
            transform.position = Vector3.zero; // Por defecto, reaparece en (0, 0, 0) si no hay checkpoint
        }
    }
}
