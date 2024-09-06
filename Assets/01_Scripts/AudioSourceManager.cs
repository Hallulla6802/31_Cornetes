using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource bgmSource;
    public AudioSource powerupSource;

    [Header("Player & Rival Sounds")]
    [Space]  

    public AudioSource bloqueo;
    public AudioSource golpeRecibido;
    public AudioSource golpe;
    public AudioClip healingPowerUp;
    public AudioClip resurrectPowerUp;
    public AudioClip speedPowerUp;
    public AudioClip strenghtPowerUp;
    public AudioSource taunt;

    [Header("Background Sounds")]
    [Space]
    public AudioSource crowdLoop;
    public AudioSource derrota; 
    public AudioSource ringbell;
    
    [Header("Music Sounds")]
    [Space]
    public AudioClip battleMusic;
}
