using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables: MonoBehaviour
{
    [Header("Player Variables")]
    [Space]
    public float playerCurrentLife;
    public float playerMaxLife = 500;
    public float playerSpeed;
    public float playerDamage;

    public GameObject player;

    void Update()
    {
        if (playerCurrentLife < 0)
        {
            playerCurrentLife = 0;
        }

        if (playerCurrentLife == 0)
        {
            player.SetActive(false);
        }
        else if (DataManager.perkElegido != 0)
        {
            player.SetActive(true);
        }
       

            if (playerCurrentLife > playerMaxLife)
        {
            playerCurrentLife = playerMaxLife;
        }
    }
}
