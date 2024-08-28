using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlRivalStates : MonoBehaviour
{
    [Header("Debug Rival Text")]
    [Space]

    public TextMeshProUGUI debugRivalText;

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
        stateChangeCoroutine = StartCoroutine(ChangeStateRandomly());
    }

    private void FixedUpdate()
    {
        

        switch (currentRivalState)
        {
            case RivalState.Idle:
                break;

            case RivalState.PreparingPunch:
                break;
            
            case RivalState.Punching:
                break;
            
            case RivalState.Blocking:
                break;
        }
    }

    private IEnumerator ChangeStateRandomly()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));

            // Random state
            currentRivalState = (RivalState)Random.Range(0, System.Enum.GetValues(typeof(RivalState)).Length);
            
            Debug.Log("Rival State: " + currentRivalState);
            debugRivalText.text = currentRivalState.ToString();

        }
    }
}
