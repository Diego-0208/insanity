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
            GameManager.Instance.PlayerDied(); // Llama al método PlayerDied del GameManager
        }
    }

    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud / SaludMaxima;       
        TextoSalud.text = "+" + Salud.ToString("f0");
    }
}
