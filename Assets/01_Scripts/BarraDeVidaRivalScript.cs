using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaRivalScript : MonoBehaviour
{
    public Image barraDeVida;

    public Rival1Variables rivalvariables;
 
 
    void Update()
    {
        barraDeVida.fillAmount = rivalvariables.rival1CurrentLife / rivalvariables.rival1MaxLife;
    }
}
