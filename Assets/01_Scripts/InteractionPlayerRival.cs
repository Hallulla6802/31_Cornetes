using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayerRival : MonoBehaviour
{
    public int rivalHealth = 600;
    public int playerHealth = 500;

    public GameObject player;
    public GameObject rival;

    
    public ControllPlayerState playerStateController;
    public ControlRivalStates rivalStateController;

    private void Update()
    {
        // Check if the player is punching
        if (playerStateController.currentState == ControllPlayerState.PlayerState.Punching)
        {
            // Check if the rival is idle or preparing to punch
            if (rivalStateController.currentRivalState == ControlRivalStates.RivalState.Idle ||
                rivalStateController.currentRivalState == ControlRivalStates.RivalState.PreparingPunch)
            {
                TakeDamage(PlayerVariables.playerStrenght);
            }
        }
    }

    private void TakeDamage(int damage)
    {
        rivalHealth -= damage;
        Debug.Log("Rival Health: " + rivalHealth);


        if (rivalHealth <= 0)
        {
            Debug.Log("Rival is defeated!");
            rivalHealth = 0;
            Destroy(rival);
        }

        if (playerHealth <= 0)
        {
            Debug.Log("Player is defeated!");
            playerHealth = 0;
            Destroy(player);
        }
    }

}
