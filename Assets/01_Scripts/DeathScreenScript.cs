using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    public ControlRivalStates controlRivalStates;
    public GameObject deathScreen;
    public GameObject ratingScreen;
    public GameObject winScreen;
    public void TriggerDeathScreen()
    {
        controlRivalStates.StopCoroutine(controlRivalStates.ChangeStateRandomly());
        deathScreen.SetActive(true);
    }
    public void TriggerRatingScreen()
    {     
        ratingScreen.SetActive(true);
    }
    public void TriggerWinScreen()
    {
        winScreen.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
