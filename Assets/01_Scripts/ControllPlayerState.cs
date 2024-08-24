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
        else if (Input.GetKeyDown(KeyCode.J))
        {
            currentstate = PlayerState.Punching;
            Debug.Log("Punching");
            debugText.SetText("Punching");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            currentstate = PlayerState.Idle;
            Debug.Log("Idle");
            debugText.SetText("Idle");
        }
    }
}


