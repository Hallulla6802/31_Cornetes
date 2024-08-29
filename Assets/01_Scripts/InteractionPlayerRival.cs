using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayerRival : MonoBehaviour
{
    public GameObject player;
    public GameObject rival;
    public PlayerVariables playerVariables;
    public ControllPlayerState playerStateController;
    public ControlRivalStates rivalStateController;
    

    /* private void TakeDamage(float damage)
    {
        Rival1Variables.rival1CurrentLife -= damage;
        Debug.Log("Rival Health: " + Rival1Variables.rival1CurrentLife);


        if (Rival1Variables.rival1CurrentLife <= 0)
        {
            Debug.Log("Rival is defeated!");
            Rival1Variables.rival1CurrentLife = 0;
            Destroy(rival);
        }

        if (playerVariables.playerCurrentLife <= 0)
        {
            Debug.Log("Player is defeated!");
            playerVariables.playerCurrentLife = 0;
            Destroy(player);
        }
    } */

}
