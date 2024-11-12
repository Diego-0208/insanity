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

    public void RecibirDa�o(float da�o)
    {
        Salud -= da�o;

        // Verifica si la salud es menor o igual a cero
        if (Salud <= 0)
        {
            Salud = 0; // Aseg�rate de que la salud no sea negativa
            GameManager.Instance.PlayerDied(); // Llama al m�todo PlayerDied del GameManager
        }
    }

    void ActualizarInterfaz()
    {
        BarraSalud.fillAmount = Salud / SaludMaxima;       
        TextoSalud.text = "+" + Salud.ToString("f0");
    }
}
