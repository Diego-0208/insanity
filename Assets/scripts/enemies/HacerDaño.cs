using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerDaño : MonoBehaviour
{
    public float CantidadDaño; // Cantidad de daño a aplicar

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisionamos es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Intenta obtener el componente Codigo_Salud en el objeto del jugador
            Codigo_Salud salud = collision.gameObject.GetComponent<Codigo_Salud>();
            if (salud != null)
            {
                // Aplica el daño al jugador
                salud.RecibirDaño(CantidadDaño);
                Debug.Log("Daño aplicado: " + CantidadDaño);
            }
            else
            {
                Debug.Log("El objeto no tiene un componente Codigo_Salud");
            }
        }
    }
}
