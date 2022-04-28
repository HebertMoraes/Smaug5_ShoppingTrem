using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableRewardItemSold : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        /*
        if (SaveManager.instance.activeSave.countItemSold >= 100 && SaveManager.instance.activeSave.haveClaimedRewardItemSold == false)
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
