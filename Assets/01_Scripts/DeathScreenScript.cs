using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject ratingScreen;
    public GameObject winScreen;
    public bool isOn;

    private AudioSourceManager _audioSourceManager;
    private ControlRivalStates _controlRivalState;
    public ControlPlayerState _controlPlayerState;

    private void Awake()
    {
        _audioSourceManager = FindObjectOfType<AudioSourceManager>();
        _controlRivalState = FindObjectOfType<ControlRivalStates>();       
    }
    public void TriggerDeathScreen()
    {        
        if(!isOn)
        {
            isOn = true;
            deathScreen.SetActive(true);
            _audioSourceManager.derrota.Play();
            _audioSourceManager.ringbell.Play();
            _audioSourceManager.crowdLoop.mute = true;
            _audioSourceManager.bgmSource.mute = true;

            _controlPlayerState.canMove = false;
            _controlRivalState.canMove = false;
            _controlRivalState.StopCoroutine(_controlRivalState.ChangeStateRandomly());
        }
        else
        {
            return;
        }
    }
    public void TriggerRatingScreen()
    {   
        if(!isOn)
        {
            isOn = true;
            ratingScreen.SetActive(true);
            _audioSourceManager.derrota.Play();
            _audioSourceManager.ringbell.Play();
            _audioSourceManager.crowdLoop.mute = true;
            _audioSourceManager.bgmSource.mute = true;

            _controlRivalState.StopCoroutine(_controlRivalState.ChangeStateRandomly());
            _controlPlayerState.canMove = false;
        }
        else
        {
            return;
        }
    }
    public void TriggerWinScreen()
    {
        if(!isOn)
        {
            isOn = true;
            winScreen.SetActive(true);
            _audioSourceManager.taunt.Play();
            _audioSourceManager.ringbell.Play();
            _audioSourceManager.crowdLoop.mute = true;
            _audioSourceManager.bgmSource.mute = true;

            _controlRivalState.StopCoroutine(_controlRivalState.ChangeStateRandomly());
            _controlPlayerState.canMove = false;
        }
        else
        {
            return;
        }       
    } 
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
