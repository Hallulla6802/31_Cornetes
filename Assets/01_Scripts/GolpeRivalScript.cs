using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeRivalScript : MonoBehaviour
{

    private InteractionPlayerRival interactionPlayerRival;
    public int daño = 25;
    public int dañoReducido = 10;

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
        // Verifica si el objeto colisionado tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica el estado actual del rival
            ControllPlayerState playerStates = collision.gameObject.GetComponent<ControllPlayerState>();

            if (playerStates != null)
            {
                // Ajusta el daño según el estado del rival
                switch (playerStates.currentState)
                {
                    case ControllPlayerState.PlayerState.Blocking:
                        interactionPlayerRival.playerHealth -= dañoReducido;
                        Debug.Log("El rival está bloqueando. Se restaron " + dañoReducido + " puntos de vida. Vida actual: " + interactionPlayerRival.playerHealth);
                        break;

                    default:
                        interactionPlayerRival.playerHealth -= daño;
                        Debug.Log("Se restaron " + daño + " puntos de vida al rival. Vida actual: ");
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

