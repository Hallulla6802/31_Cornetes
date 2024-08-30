using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpePlayerScript : MonoBehaviour
{
    public RatingScript ratingScript;
    public int damage = 20;
    public int damageBlocked = 5;
    public Rival1Variables rival1Variables;


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
                        ratingScript.GiveRating(20);
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

