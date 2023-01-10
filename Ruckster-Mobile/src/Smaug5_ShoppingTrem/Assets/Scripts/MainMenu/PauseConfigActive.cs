using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseConfigActive : MonoBehaviour
{
    public GameObject pauseConfig;

    public void pauseActiveDesactive() {

        if (pauseConfig.activeSelf) {
            
            pauseConfig.SetActive(false);
        } else {

            pauseConfig.SetActive(true);
        }
    }
}
