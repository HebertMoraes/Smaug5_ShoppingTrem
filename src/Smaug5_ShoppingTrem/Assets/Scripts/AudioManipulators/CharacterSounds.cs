using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    public AudioSource JumpAudioSource;

    public AudioSource slideHorizontalAudioSource;
    public AudioClip slideHorizontal1Sound;
    public AudioClip slideHorizontal2Sound;

    public AudioSource HitAudioSource;
    public AudioClip hitSound;
    public AudioClip hitHardSound;
    
    public void activeJumpSound () {
        JumpAudioSource.Play();
    }
    public void activeSlideHorizontalSound () {
        
        if (Random.value < 0.5) {
            slideHorizontalAudioSource.clip = slideHorizontal1Sound;
        } else {
            slideHorizontalAudioSource.clip = slideHorizontal2Sound;
        }

        slideHorizontalAudioSource.Play();
    }
    public void activeHitSound () {
        HitAudioSource.clip = hitSound;
        HitAudioSource.Play();
    }
    public void activeHitHardSound () {
        HitAudioSource.clip = hitHardSound;
        HitAudioSource.Play();
    }
}
