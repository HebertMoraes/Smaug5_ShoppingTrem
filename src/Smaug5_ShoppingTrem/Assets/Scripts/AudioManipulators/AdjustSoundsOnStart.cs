using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustSoundsOnStart : MonoBehaviour
{
    public VolumeMusicAndSound soundsManipulator; 

    // Start is called before the first frame update
    void Start()
    {
        soundsManipulator.AdjustSoundsInStart();
    }
}
