using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeRivalScript : MonoBehaviour
{
    public float damage = 25;  //daño
    public float damageBlocked = 10; //dañoBloqueando
    public PlayerHealthBar playerHealthBar; //Imagen de barra de vida
    public PlayerVariables playerVariables;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica el estado actual del rival
            ControllPlayerState playerStates = collision.gameObject.GetComponent<ControllPlayerState>();

            if (playerStates != null)
            {
                // Ajusta el dano segun el estado del rival
                switch (playerStates.currentState)
                {
                    case ControllPlayerState.PlayerState.Blocking:
                        playerVariables.playerCurrentLife -= damageBlocked;
                        //playerHealthBar.UpdatePlayerHealth(damageBlocked);
                        Debug.Log("El rival esta bloqueando. Se restaron " + damageBlocked + " puntos de vida. Vida actual: " + playerVariables.playerCurrentLife);
                        break;
                    default:
                        playerVariables.playerCurrentLife -= damage;
                        //playerHealthBar.UpdatePlayerHealth(damage);
                        Debug.Log("Se restaron " + damage + " puntos de vida al rival. Vida actual: " + playerVariables.playerCurrentLife);
                        break;
                }
            }
            else
            {
                Debug.LogError("No se encontro el script 'ControlRivalStates' en el objeto Rival.");
            }
        }
    }
}

