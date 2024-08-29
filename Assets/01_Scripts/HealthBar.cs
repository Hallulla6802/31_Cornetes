using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
   [SerializeField] private UnityEngine.UI.Image _healthBarFill;
   public void UpdatePlayerHealth(float damage)
   {
        PlayerVariables.playerCurrentLife += damage;
        UpdatePlayerHealthBar();
   }
   private void UpdatePlayerHealthBar()
   {
        float targetFillAmount = PlayerVariables.playerCurrentLife / 
        PlayerVariables.playerMaxLife;
        _healthBarFill.fillAmount = targetFillAmount;
   }
}
