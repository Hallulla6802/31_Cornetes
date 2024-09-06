using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class ControlRivalStates : MonoBehaviour
{
   // [Header("Debug Rival Text")]
    //[Space]

    //public TextMeshProUGUI debugRivalText;

    public GameObject golpeRival;

    public float tiempoMinimo;
    public float tiempoMaximo;
    public bool canMove = true;
    private Animator rivalSpriteAnim;
    private AudioSourceManager _audioSourceManager;

    public enum RivalState
    {
        Idle,
        PreparingPunch,
        Punching,
        Blocking
    }

    public RivalState currentRivalState = RivalState.Idle;

    private Coroutine stateChangeCoroutine;

    private void Start()
    {
        _audioSourceManager = FindObjectOfType<AudioSourceManager>();
    }

    public void StartStateCourutine()
    {
        stateChangeCoroutine = StartCoroutine(ChangeStateRandomly());
    }

    private void FixedUpdate()
    {
        
        switch (currentRivalState)
        {
            case RivalState.Idle:
                golpeRival.SetActive(false);
                //_anim.PlayIdle

                break;

            case RivalState.PreparingPunch:
                golpeRival.SetActive(false);
                //_anim.PlayPreparingPunch
                
                break;
            
            case RivalState.Punching:
                golpeRival.SetActive(true);
                _audioSourceManager.golpe.Play();
                break;
            
            case RivalState.Blocking:
                golpeRival.SetActive(false);
               _audioSourceManager.bloqueo.Play();
                break;
        }
    }

    public IEnumerator ChangeStateRandomly()
    {
        while (true)
        {
            if(canMove)
            {
                yield return new WaitForSeconds(Random.Range(tiempoMinimo, tiempoMaximo));  // original 0.5f, 1f

                // Random state
                currentRivalState = (RivalState)Random.Range(0, System.Enum.GetValues(typeof(RivalState)).Length);
                CambiarRivalSprite();
                Debug.Log("Rival State: " + currentRivalState);
                //debugRivalText.text = currentRivalState.ToString();
            }
            else
            {
                yield break;
            }

        }
    }

    private void CambiarRivalSprite()
    {
        switch (currentRivalState)
        {
            case RivalState.Idle:
                rivalSpriteAnim.Play("Idle");
                //_anim.PlayIdle
                break;

            /* case RivalState.PreparingPunch:
                rivalSpriteAnim.Play("");
                //_anim.PlayPreparingPunch             
                break; */
            
            case RivalState.Punching:
                rivalSpriteAnim.Play("Punching");
                break;
            
            case RivalState.Blocking:
                rivalSpriteAnim.Play("Block");
                break;
        }
    }
}
