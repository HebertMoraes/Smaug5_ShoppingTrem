using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMusicAndSound : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource[] soundEfectsSource;
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    public void Start()
    {
        // AdjustSoundsInStart();
    }

    public void AdjustSoundsInStart()
    {
        musicSource.volume = VariablesSave.musicVolume;
        musicVolumeSlider.value = VariablesSave.musicVolume;

        foreach (AudioSource efectSound in soundEfectsSource)
        {
            efectSound.volume = VariablesSave.soundsVolume;
            soundVolumeSlider.value = VariablesSave.soundsVolume;
        }
    }

    public void updateMusicVolume()
    {
        VariablesSave.musicVolume = musicVolumeSlider.value;
        musicSource.volume = VariablesSave.musicVolume;
    }

    public void updateSoundVolume()
    {
        foreach (AudioSource efectSound in soundEfectsSource)
        {
            VariablesSave.soundsVolume = soundVolumeSlider.value;
            efectSound.volume = VariablesSave.soundsVolume;
        }
    }
}
