using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpePlayerScript : MonoBehaviour
{

    private InteractionPlayerRival interactionPlayerRival;
    public int damage = 20;
    public int damageBlocked = 5;
    public Rival1Variables rival1Variables;

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
        // Verifica si el objeto colisionado tiene la etiqueta "Rival"
        if (collision.gameObject.CompareTag("Rival"))
        {
            // Verifica el estado actual del rival
            ControlRivalStates rivalStates = collision.gameObject.GetComponent<ControlRivalStates>();

            if (rivalStates != null)
            {
                // Ajusta el da�o seg�n el estado del rival
                switch (rivalStates.currentRivalState)
                {
                    case ControlRivalStates.RivalState.Blocking:
                        rival1Variables.rival1CurrentLife -= damageBlocked;
                        Debug.Log("El rival est� bloqueando. Se restaron " + damageBlocked + " puntos de vida. Vida actual: " + rival1Variables.rival1CurrentLife);
                        break;

                    default:
                        rival1Variables.rival1CurrentLife -= damage;
                        Debug.Log("Se restaron " + damage + " puntos de vida al rival. Vida actual: " + rival1Variables.rival1CurrentLife);
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

