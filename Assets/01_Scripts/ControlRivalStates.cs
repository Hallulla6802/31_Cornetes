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

    private Animator _anim;
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
        _anim = GetComponent<Animator>();
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
            
            yield return new WaitForSeconds(Random.Range(tiempoMinimo, tiempoMaximo));  // original 0.5f, 1f

            // Random state
            currentRivalState = (RivalState)Random.Range(0, System.Enum.GetValues(typeof(RivalState)).Length);
            
            Debug.Log("Rival State: " + currentRivalState);
            //debugRivalText.text = currentRivalState.ToString();

        }
    }
}
