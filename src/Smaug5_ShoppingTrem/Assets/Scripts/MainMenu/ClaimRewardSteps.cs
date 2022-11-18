using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClaimRewardSteps : MonoBehaviour
{
    private GameObject gameController;
    public Button buttonSteps;
    public Button buttonSales;
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    public void claimSteps()
    {
        if(VariablesSave.claimedSales == false)
        {
            buttonSteps = GetComponent<Button>();
            VariablesSave.countMoney = VariablesSave.countMoney + 100;
            buttonSteps.interactable = false;
            VariablesSave.claimedSales = true;
        }
    }
    public void claimSales()
    {
        if (VariablesSave.claimedSales == false)
        {
            buttonSales = GetComponent<Button>();
            VariablesSave.countMoney = VariablesSave.countMoney + 1000;
            buttonSales.interactable = false;
            VariablesSave.claimedSteps = true;
        }            
    }
}
