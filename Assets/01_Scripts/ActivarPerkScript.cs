using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivarPerkScript : MonoBehaviour
{
    public GameObject canvasPerk;
    public PlayerVariables playerVariables;
    public GolpePlayerScript golpeplayer;
    public ControlRivalStates controlRivalStates;
    public GameObject player;
    public TMP_Text perkNameText;

    public int seLeAgregaSalud;
    public int seLeAgregaDamage;
    public int seLeAgregaDamageoDelBlockeo;
    public float seLeAgregaTiempoMaximo;
    public float seLeAgregaTiempoMinimo;
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
                    if(playerVariables.playerCurrentLife <= 0)
                    {
                        return;
                    }
                    else
                    {
                        playerVariables.playerCurrentLife += seLeAgregaSalud;
                        DataManager.perkElegido = 0;
                    }
                    break;
                    

                case 2:
                    golpeplayer.damage += seLeAgregaDamage;
                    golpeplayer.damageBlocked += seLeAgregaDamageoDelBlockeo;
                    DataManager.perkElegido = 0;
                    break;

                case 3:
                    controlRivalStates.tiempoMinimo += seLeAgregaTiempoMinimo;
                    controlRivalStates.tiempoMaximo += seLeAgregaTiempoMaximo;
                    DataManager.perkElegido = 0;
                    break;
            }

        }

        if (Input.GetKey(KeyCode.X) && (playerVariables.playerCurrentLife == 0) && DataManager.perkElegido == 4)
        {
            playerVariables.playerCurrentLife = 80f;
            player.SetActive(true);
            DataManager.perkElegido = 0;
        }
        

    }
    public void UpdatePerkName(string perkName)
    {   
        perkNameText.text = perkName;      
    }
}
