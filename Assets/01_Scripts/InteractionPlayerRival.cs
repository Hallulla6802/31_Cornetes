using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPlayerRival : MonoBehaviour
{
    public int rivalHealth = 100;

    
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
        }   
    }

}
