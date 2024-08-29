using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPerkScript : MonoBehaviour
{
    public GameObject canvasPerk;

    public PlayerVariables playerVariables;
    public GolpePlayerScript golpeplayer;
    public GameObject player;

    public int seLeAgregaSalud;
    public int seLeAgregaDaño;
    public int seLeAgregaDañoDelBlockeo;
    void Update()
    {
        if (DataManager.perkElegido == 0)
        {
            canvasPerk.SetActive(false);
        }  else {
           canvasPerk.SetActive(true);
        }

        





        if (Input.GetKey(KeyCode.X))
        {
            switch (DataManager.perkElegido)
            {
                case 1:
                    playerVariables.playerCurrentLife += seLeAgregaSalud;
                    DataManager.perkElegido = 0;
                    break;

                case 2:
                    golpeplayer.damage += seLeAgregaDaño;
                    golpeplayer.damageBlocked += seLeAgregaDañoDelBlockeo;
                    DataManager.perkElegido = 0;
                    break;

              

                        

                    

            }

        }

        if (Input.GetKey(KeyCode.X) && (playerVariables.playerCurrentLife == 0) && DataManager.perkElegido == 4)
        {
            playerVariables.playerCurrentLife = playerVariables.playerMaxLife;
            player.SetActive(true);
            DataManager.perkElegido = 0;
        }


    }
}
