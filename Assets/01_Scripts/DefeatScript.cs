using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ControlPlayerState;

public class DefeatScript : MonoBehaviour
{
    public PlayerVariables playerVariables;
    public GameObject player;
    public DeathScreenScript deathScreenScript;
    public ControlPlayerState controlPlayerState;

    void Update()
    {
        if (playerVariables.playerCurrentLife < 0)
        {
            playerVariables.playerCurrentLife = 0;
        }

        if (playerVariables.playerCurrentLife > playerVariables.playerMaxLife)
        {
            playerVariables.playerCurrentLife = playerVariables.playerMaxLife;
        }

        if (playerVariables.playerCurrentLife <= 0 & DataManager.perkElegido == 4)
        {
            player.SetActive(false); //Fall - Can Activate 4th Perk
            controlPlayerState.currentState = PlayerState.Idle;
        }        
        else if(playerVariables.playerCurrentLife <= 0 & DataManager.perkElegido != 4)
        {   
            player.SetActive(false);
            deathScreenScript.TriggerDeathScreen(); //Fall - Used 4th Perk
        }
    }
}
