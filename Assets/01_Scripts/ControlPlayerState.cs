using UnityEngine;
//using TMPro;
using System.Collections;

public class ControlPlayerState : MonoBehaviour
{
    [Header("Debug Text")]
    [Space]

    //public TextMeshProUGUI debugText;
    public RatingScript ratingScript;
    public GameObject golpePlayer;

    [SerializeField] private int antiSpamKey = 0;
    private AudioSourceManager _audioSourceMan;

    public enum PlayerState
    {
        Idle,
        Punching,
        Blocking,
        Taunting
    }

    public PlayerState currentState = PlayerState.Idle;

    public Coroutine returnToIdleCoroutine;

    private void Start()
    {
        currentState = PlayerState.Idle;

        _audioSourceMan = FindObjectOfType<AudioSourceManager>();
    }

    private void Update()
    {
        //Blocking 
        if (Input.GetKey(KeyCode.L) && currentState == PlayerState.Idle) 
        {
            currentState = PlayerState.Blocking;
            _audioSourceMan.bloqueo.Play();
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
            _audioSourceMan.golpe.Play();
            Debug.Log("Punching");
        }
        if(currentState == PlayerState.Idle && Input.GetKeyDown(KeyCode.J)&& antiSpamKey == 0)
        {
            ratingScript.GiveRating(20);
            _audioSourceMan.taunt.Play();
            SetState(PlayerState.Taunting);
            Debug.Log("Tauting");
        }




        // Update the debug text
        //debugText.SetText(currentState.ToString());

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

            case PlayerState.Taunting:
                golpePlayer.SetActive(false);
                //Implement Sprite Taunt Logic
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
            returnToIdleCoroutine = StartCoroutine(ReturnToIdleAfterDelay(1)); // Adjust the delay as needed
        }
        else if(newState == PlayerState.Taunting)
        {
            antiSpamKey++;
            returnToIdleCoroutine = StartCoroutine(ReturnToIdleAfterDelay(4)); // Adjust the delay as needed
        }
    }
    public void InterrumptTaunt()
    {
        if(currentState == PlayerState.Taunting)
        {
            antiSpamKey++;
            returnToIdleCoroutine = StartCoroutine(ReturnToIdleAfterDelay(.5f)); // Adjust the delay as needed
            //Interrrumpt Sprite Taunt
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


