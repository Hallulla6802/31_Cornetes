using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpePlayerScript : MonoBehaviour
{

    private InteractionPlayerRival interactionPlayerRival;
    public int daño = 20;
    public int dañoReducido = 5;

    private void Awake()
    {
        // Busca el objeto que tiene el script InteractionPlayerRival
        interactionPlayerRival = FindObjectOfType<InteractionPlayerRival>();

        // Verifica si se encontró el script
        if (interactionPlayerRival == null)
        {
            Debug.LogError("No se encontró ningún objeto con el script 'InteractionPlayerRival'. Asegúrate de que el script esté en un objeto en la escena.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Rival"
        if (collision.gameObject.CompareTag("Rival"))
        {
            // Verifica el estado actual del rival
            ControlRivalStates rivalStates = collision.gameObject.GetComponent<ControlRivalStates>();

            if (rivalStates != null)
            {
                // Ajusta el daño según el estado del rival
                switch (rivalStates.currentRivalState)
                {
                    case ControlRivalStates.RivalState.Blocking:
                        interactionPlayerRival.rivalHealth -= dañoReducido;
                        Debug.Log("El rival está bloqueando. Se restaron " + dañoReducido + " puntos de vida. Vida actual: " + interactionPlayerRival.rivalHealth);
                        break;

                    default:
                        interactionPlayerRival.rivalHealth -= daño;
                        Debug.Log("Se restaron " + daño + " puntos de vida al rival. Vida actual: " + interactionPlayerRival.rivalHealth);
                        break;
                }
            }
            else
            {
                Debug.LogError("No se encontró el script 'ControlRivalStates' en el objeto Rival.");
            }
        }
    }
}

