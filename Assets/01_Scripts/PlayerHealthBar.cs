using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
   [SerializeField] private UnityEngine.UI.Image _healthBarFill;
   public PlayerVariables playerVariables;
   public void UpdatePlayerHealth(float damage)
   {
        playerVariables.playerCurrentLife += damage;
        UpdatePlayerHealthBar();
   }
   private void UpdatePlayerHealthBar()
   {
        float targetFillAmount = playerVariables.playerCurrentLife / 
        playerVariables.playerMaxLife;
        _healthBarFill.fillAmount = targetFillAmount;
   }
}
