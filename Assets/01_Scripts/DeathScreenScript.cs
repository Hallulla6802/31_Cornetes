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

    private AudioSourceManager _audioSourceManager;

    private void Awake()
    {
        _audioSourceManager = FindObjectOfType<AudioSourceManager>();
    }
    public void TriggerDeathScreen()
    {
        controlRivalStates.StopCoroutine(controlRivalStates.ChangeStateRandomly());
        deathScreen.SetActive(true);

        
        _audioSourceManager.derrota.Play();
    }
    public void TriggerRatingScreen()
    {     
        ratingScreen.SetActive(true);
        _audioSourceManager.derrota.Play();
    }
    public void TriggerWinScreen()
    {
        winScreen.SetActive(true);
        _audioSourceManager.taunt.Play();
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
