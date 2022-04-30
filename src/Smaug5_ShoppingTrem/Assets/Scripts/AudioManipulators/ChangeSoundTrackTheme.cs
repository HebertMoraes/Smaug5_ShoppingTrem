using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundTrackTheme : MonoBehaviour
{
    public AudioClip soundTrack1;
    public AudioClip soundTrack2;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();

        if (Random.value < 0.5) {
            source.clip = soundTrack1;
        } else {
            source.clip = soundTrack2;
        }

        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying) {
            if (source.clip == soundTrack1) {
                source.clip = soundTrack2;
                source.Play();
            }
            if (source.clip == soundTrack2) {
                source.clip = soundTrack1;
                source.Play();
            }
        }
    }
}
