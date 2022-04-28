using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableRewardMetragem : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = false; 
    }

    private void Update()
    {
        /*
        if (SaveManager.instance.activeSave.countStepsDistance >= 1000 && SaveManager.instance.activeSave.haveClaimedRewardMetragem == false)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        */
    }
}
