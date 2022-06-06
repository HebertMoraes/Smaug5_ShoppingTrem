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

    public void updateMusicVolume () {
        musicSource.volume = musicVolumeSlider.value;
    }

    public void updateSoundVolume () {
        foreach(AudioSource efectSound in soundEfectsSource) {
            efectSound.volume = soundVolumeSlider.value;
        }
    }
}
