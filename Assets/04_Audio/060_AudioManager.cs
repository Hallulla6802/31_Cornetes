using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region VARIABLES

    [Header("MIXER")]
    [Space]

    [SerializeField] private AudioMixer mainMixer;

    [Header("SLIDERS")]
    [Space]

    [SerializeField] private Slider generalSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;

    #endregion

    private void Start()
    {
        LoadValues();
    }


    #region VOLUME SETTINGS

    #region General Volume

    public void SetGeneralVolume(float sliderValue)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    #endregion

    #region BG Volume
    public void SetMusicVolume(float sliderValue)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }


        #endregion

        #region SFX Volume

    public void SetSFXVolume(float sliderValue)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }


    #endregion

    #endregion

    #region SAVE & LOAD VOLUME

    public void SaveVolumeButton()
    {
        float GeneralValue = generalSlider.value;
        PlayerPrefs.SetFloat("GeneralValue", GeneralValue);

        float MusicValue = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MusicValue", MusicValue);

        float sfxValue = sfxVolumeSlider.value;
        PlayerPrefs.SetFloat("SFXValue", sfxValue);

        LoadValues();
    }
    void LoadValues()
    {
        float GeneralValue = PlayerPrefs.GetFloat("GeneralValue");
        generalSlider.value = GeneralValue;
        AudioListener.volume = GeneralValue;

        float MusicValue = PlayerPrefs.GetFloat("MusicValue");
        musicVolumeSlider.value = MusicValue;
        AudioListener.volume = MusicValue;

        float sfxValue = PlayerPrefs.GetFloat("SFXValue");
        sfxVolumeSlider.value = sfxValue;
        AudioListener.volume = sfxValue;
    }
    #endregion
}
