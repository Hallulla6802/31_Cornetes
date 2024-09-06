using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolpeRivalScript : MonoBehaviour
{
    public float damage = 25;  //daño
    public float damageBlocked = 10; //dañoBloqueando
    public PlayerVariables playerVariables;
    public Animator playerPortAnim;
    public Animator playerSpriteAnim;
    private AudioSourceManager _audioSourceManager;
    void Awake()
    {
         _audioSourceManager = FindObjectOfType<AudioSourceManager>();
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto colisionado tiene la etiqueta "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica el estado actual del rival
            ControlPlayerState playerStates = collision.gameObject.GetComponent<ControlPlayerState>();

            if (playerStates != null)
            {
                // Ajusta el dano segun el estado del rival
                switch (playerStates.currentState)
                {
                    case ControlPlayerState.PlayerState.Blocking:
                        playerVariables.playerCurrentLife -= damageBlocked;
                        Debug.Log("El rival esta bloqueando. Se restaron " + damageBlocked + " puntos de vida. Vida actual: " + playerVariables.playerCurrentLife);
                        break;
                    default:
                        playerVariables.playerCurrentLife -= damage;
                        playerPortAnim.Play("Punched");
                        playerSpriteAnim.Play("Punched");
                        _audioSourceManager.golpeRecibido.Play();
                        if(playerStates.currentState == ControlPlayerState.PlayerState.Taunting)
                        {
                            playerStates.InterrumptTaunt();
                            playerPortAnim.Play("Punched");
                            playerSpriteAnim.Play("Punched");
                            _audioSourceManager.golpeRecibido.Play();
                        }
                        Debug.Log("Se restaron " + damage + " puntos de vida al rival. Vida actual: " + playerVariables.playerCurrentLife);
                        break;
                }
            }
            else
            {
                Debug.LogError("No se encontro el script 'ControlRivalStates' en el objeto Rival.");
            }
        }
    }
}

