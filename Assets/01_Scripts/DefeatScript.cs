using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatScript : MonoBehaviour
{
    public PlayerVariables playerVariables;
    public GameObject player;
    public DeathScreenScript deathScreenScript;

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
        }        
        else if(playerVariables.playerCurrentLife <= 0 & DataManager.perkElegido != 4)
        {
            player.SetActive(false);
            deathScreenScript.TriggerDeathScreen(); //Fall - Used 4th Perk
        }
    }
}
