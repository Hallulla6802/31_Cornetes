using UnityEngine;
using TMPro;
using System.Collections;

public class ControllPlayerState : MonoBehaviour
{
    [Header("Debug Text")]
    [Space]
    public TextMeshProUGUI debugText;
    public float returnToIdleTimer;

    public GameObject golpePlayer;

    [SerializeField] private int antiSpamKey = 0;
    public enum PlayerState
    {
        Idle,
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
        //Blocking 
        if (Input.GetKey(KeyCode.L) && !(currentState == PlayerState.Punching))
        {
            currentState = PlayerState.Blocking;
            Debug.Log("Blocking");
        }
        else if (currentState == PlayerState.Blocking && !Input.GetKey(KeyCode.L))
        {
            SetState(PlayerState.Idle);
            Debug.Log("Returning to Idle from Blocking");
        }

        if (currentState == PlayerState.Idle && Input.GetKeyDown(KeyCode.H) && antiSpamKey == 0)
        {
            SetState(PlayerState.Punching);
            Debug.Log("Preparing Punch");
        }

        // Update the debug text
        debugText.SetText(currentState.ToString());

        if(antiSpamKey > 1)
        {
            antiSpamKey = 1;
        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                golpePlayer.SetActive(false);
                // Whatever Idle does, does nothin-
                break;

            case PlayerState.Punching:
                golpePlayer.SetActive(true);
                // Implement the logic of hitting and taking life from the Rival
                break;

            case PlayerState.Blocking:
                golpePlayer.SetActive(false);
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

        // Start coroutine to return to Idle
        if (newState == PlayerState.Punching)
        {
            antiSpamKey++;
            returnToIdleCoroutine = StartCoroutine(ReturnToIdleAfterDelay(returnToIdleTimer)); // Adjust the delay as needed
        }
    }

    private IEnumerator ReturnToIdleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetState(PlayerState.Idle);
        antiSpamKey = 0;
        Debug.Log("Returning to Idle");
    }
}


