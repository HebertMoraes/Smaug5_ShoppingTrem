using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public AudioMixer mixer;

    private void Start()
    {
        mixer.SetFloat("MusicVol", -18);
    }
    // Start is called before the first frame update
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVol", (-20 + Mathf.Log10(sliderValue * 20)));
    }
}
