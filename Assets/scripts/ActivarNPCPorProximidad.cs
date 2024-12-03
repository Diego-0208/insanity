using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarNPCPorProximidad : MonoBehaviour
{
    public float radioActivacion = 5f; // Radio de activación en unidades
    public Transform jugador; // Referencia al jugador
    public GameObject npc; // Objeto o componentes que se activarán/desactivarán

    private bool jugadorDentroDelRadio = false;

    void Update()
    {
        VerificarDistancia();
    }

    void VerificarDistancia()
    {
        if (jugador != null)
        {
            float distancia = Vector3.Distance(transform.position, jugador.position);
            bool estaCerca = distancia <= radioActivacion;

            if (estaCerca && !jugadorDentroDelRadio)
            {
                jugadorDentroDelRadio = true;
                ActivarNPC(); // Activa el NPC
            }
            else if (!estaCerca && jugadorDentroDelRadio)
            {
                jugadorDentroDelRadio = false;
                DesactivarNPC(); // Desactiva el NPC
            }
        }
    }

    void ActivarNPC()
    {
        if (npc != null)
        {
            npc.SetActive(true); // Activa el NPC
            Debug.Log("NPC Activado");
        }
    }

    void DesactivarNPC()
    {
        if (npc != null)
        {
            npc.SetActive(false); // Desactiva el NPC
            Debug.Log("NPC Desactivado");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el radio de activación en la escena para facilitar la configuración
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioActivacion);
    }
}
