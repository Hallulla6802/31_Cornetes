using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject ratingScreen;
    public GameObject winScreen;

    private AudioSourceManager _audioSourceManager;
    private ControlRivalStates _controlRivalState;

    private void Awake()
    {
        _audioSourceManager = FindObjectOfType<AudioSourceManager>();
        _controlRivalState = FindObjectOfType<ControlRivalStates>();
    }
    public void TriggerDeathScreen()
    {
        _controlRivalState.StopCoroutine(_controlRivalState.ChangeStateRandomly());
        deathScreen.SetActive(true);

        
        _audioSourceManager.derrota.Play();
        _audioSourceManager.ringbell.Play();
        _audioSourceManager.crowdLoop.Stop();

    }
    public void TriggerRatingScreen()
    {     
        ratingScreen.SetActive(true);
        _audioSourceManager.derrota.Play();
        _audioSourceManager.ringbell.Play();
        _audioSourceManager.crowdLoop.Stop();

        _controlRivalState.StopCoroutine(_controlRivalState.ChangeStateRandomly());
    }
    public void TriggerWinScreen()
    {
        winScreen.SetActive(true);
        _audioSourceManager.taunt.Play();
        _audioSourceManager.ringbell.Play();
        _audioSourceManager.crowdLoop.Stop();

        _controlRivalState.StopCoroutine(_controlRivalState.ChangeStateRandomly());
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
