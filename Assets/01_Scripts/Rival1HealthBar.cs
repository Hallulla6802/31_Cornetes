using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rival1HealthBar : MonoBehaviour
{
   [SerializeField] private UnityEngine.UI.Image _healthBarFill;
   public Rival1Variables rival1Variables;
   public void UpdatePlayerHealth(float damage)
   {
        rival1Variables.rival1CurrentLife += damage;
        UpdatePlayerHealthBar();
   }
   private void UpdatePlayerHealthBar()
   {
        float targetFillAmount = rival1Variables.rival1CurrentLife / 
        rival1Variables.rival1MaxLife;
        _healthBarFill.fillAmount = targetFillAmount;
   }
}
