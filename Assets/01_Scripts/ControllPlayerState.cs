using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllPlayerState : MonoBehaviour
{
    [Header("Debug Text")]
    [Space]

    public TextMeshProUGUI debugText;

    public enum PlayerState
    {
        Idle,
        PreparingPunch,
        Punching,
        Blocking
    }

    public PlayerState currentstate = PlayerState.Idle;

    private void Update()
    {
        if(currentstate == PlayerState.PreparingPunch)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                currentstate = PlayerState.Punching;
                Debug.Log("Punching");
                debugText.SetText("Punching");
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                currentstate = PlayerState.PreparingPunch;
                Debug.Log("Preparing Punch");
                debugText.SetText("Preparing Punch");
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                currentstate = PlayerState.Blocking;
                Debug.Log("Blocking");
                debugText.SetText("Blocking");
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                currentstate = PlayerState.Idle;
                Debug.Log("Idle");
                debugText.SetText("Idle");
            }
        }

        
    }

    private void FixedUpdate()
    {
        switch (currentstate)
        {
            case PlayerState.Idle:
                //Whatever Idle does
                break;

            case PlayerState.PreparingPunch:
                //whatever preparing punch does
                break;

            case PlayerState.Punching:
                //Whatever Punching does
                break;

            case PlayerState.Blocking:
                //Whatever Blocking does
                break;
        }
    }
}


