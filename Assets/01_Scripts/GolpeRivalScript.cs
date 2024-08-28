using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeRivalScript : MonoBehaviour
{

    private InteractionPlayerRival interactionPlayerRival;
    public int da�o = 25;
    public int da�oReducido = 10;

    private void Awake()
    {
        // Busca el objeto que tiene el script InteractionPlayerRival
        interactionPlayerRival = FindObjectOfType<InteractionPlayerRival>();

        // Verifica si se encontr� el script
        if (interactionPlayerRival == null)
        {
            Debug.LogError("No se encontr� ning�n objeto con el script 'InteractionPlayerRival'. Aseg�rate de que el script est� en un objeto en la escena.");
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
                // Ajusta el da�o seg�n el estado del rival
                switch (playerStates.currentState)
                {
                    case ControllPlayerState.PlayerState.Blocking:
                        interactionPlayerRival.playerHealth -= da�oReducido;
                        Debug.Log("El rival est� bloqueando. Se restaron " + da�oReducido + " puntos de vida. Vida actual: " + interactionPlayerRival.playerHealth);
                        break;

                    default:
                        interactionPlayerRival.playerHealth -= da�o;
                        Debug.Log("Se restaron " + da�o + " puntos de vida al rival. Vida actual: ");
                        break;
                }
            }
            else
            {
                Debug.LogError("No se encontr� el script 'ControlRivalStates' en el objeto Rival.");
            }
        }
    }
}

