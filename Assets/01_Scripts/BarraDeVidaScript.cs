using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaScript : MonoBehaviour
{
    public Image barraDeVida;

    public PlayerVariables playervariables;
 
 
    void Update()
    {
        barraDeVida.fillAmount = playervariables.playerCurrentLife / playervariables.playerMaxLife;
    }
}
