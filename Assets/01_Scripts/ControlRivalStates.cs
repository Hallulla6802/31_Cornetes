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

            // If the rival is in PreparingPunch, transition to Punching after a short delay
            if (currentRivalState == RivalState.PreparingPunch)
            {
                yield return new WaitForSeconds(Random.Range(0.5f, 1.5f)); // Short delay before punching
                currentRivalState = RivalState.Punching;
            }
            else
            {
                // Randomly select a new state, excluding Punching
                RivalState newState;
                do
                {
                    newState = (RivalState)Random.Range(0, System.Enum.GetValues(typeof(RivalState)).Length);
                } while (newState == RivalState.Punching);

                // Set the new state
                currentRivalState = newState;

                // If the new state is PreparingPunch, ensure the next state will be Punching
                if (currentRivalState == RivalState.PreparingPunch)
                {
                    // Log the transition to PreparingPunch (for debugging)
                    Debug.Log("Rival State: Preparing Punch");

                    // Wait for another random interval before transitioning to Punching
                    yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
                    currentRivalState = RivalState.Punching;
                }
            }

            // Log the current state (for debugging purposes)
            Debug.Log("Rival State: " + currentRivalState);

        }
    }
}
