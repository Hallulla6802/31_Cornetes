using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    [Header("Player & Rival Sounds")]
    [Space]

    public AudioSource bloqueo;
    public AudioSource golpeRecibido;
    public AudioSource golpe;
    public AudioSource healingPowerUp;
    public AudioSource resurrectPowerUp;
    public AudioSource speedPowerUp;
    public AudioSource strenghtPowerUp;
    public AudioSource taunt;

    [Header("Background Sounds")]
    [Space]

    public AudioSource crowdLoop;
    public AudioSource derrota; 
    public AudioSource ringbell;
    
}
