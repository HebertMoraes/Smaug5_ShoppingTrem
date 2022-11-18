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
        buttonSteps = GetComponent<Button>();
        VariablesSave.countMoney = VariablesSave.countMoney + 100;
        buttonSteps.interactable = false;
    }
    public void claimSales()
    {
        buttonSales = GetComponent<Button>();
        VariablesSave.countMoney = VariablesSave.countMoney + 1000;
        buttonSales.interactable = false;
    }
}
