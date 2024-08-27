using UnityEngine;
using TMPro;
using System.Collections;

public class ControllPlayerState : MonoBehaviour
{
    [Header("Debug Text")]
    [Space]
    public TextMeshProUGUI debugText;
    public float returnToIdleTimer;

    public enum PlayerState
    {
        Idle,
        PreparingPunch,
        Punching,
        Blocking
    }

    public PlayerState currentState = PlayerState.Idle;

    private Coroutine returnToIdleCoroutine;

    private void Start()
    {
        currentState = PlayerState.Idle;
    }

    private void Update()
    {
        // Handle Blocking state based on key press and release
        if (Input.GetKey(KeyCode.L) && !(currentState == PlayerState.Punching) && !(currentState == PlayerState.PreparingPunch))
        {
            currentState = PlayerState.Blocking;
            Debug.Log("Blocking");
        }
        else if (currentState == PlayerState.Blocking && !Input.GetKey(KeyCode.L))
        {
            SetState(PlayerState.Idle);
            Debug.Log("Returning to Idle from Blocking");
        }

        // Handle PreparingPunch and Punching state transitions
        if (currentState == PlayerState.Idle && Input.GetKeyDown(KeyCode.H))
        {
            SetState(PlayerState.PreparingPunch);
            Debug.Log("Preparing Punch");
        }
        else if (currentState == PlayerState.PreparingPunch && Input.GetKeyDown(KeyCode.H))
        {
            SetState(PlayerState.Punching);
            Debug.Log("Punching");
        }

        // Update the debug text
        debugText.SetText(currentState.ToString());
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                // Whatever Idle does, does nothin-
                break;

            case PlayerState.PreparingPunch:
                // does nothin-
                break;

            case PlayerState.Punching:
                // Implement the logic of hitting and taking life from the Rival
                break;

            case PlayerState.Blocking:
                // Implement the logic of blocking the damage from the Rival
                break;
        }
    }

    private void SetState(PlayerState newState)
    {
        // Stop any coroutine to return to idle and avoid errors or overkaping coroutunes
        if (returnToIdleCoroutine != null)
        {
            StopCoroutine(returnToIdleCoroutine);
        }

        currentState = newState;

        // If transitioning to PreparingPunch or Punching, start coroutine to return to Idle
        if (newState == PlayerState.PreparingPunch || newState == PlayerState.Punching)
        {
            returnToIdleCoroutine = StartCoroutine(ReturnToIdleAfterDelay(returnToIdleTimer)); // Adjust the delay as needed
        }
    }

    private IEnumerator ReturnToIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetState(PlayerState.Idle);
        Debug.Log("Returning to Idle");
    }
}


