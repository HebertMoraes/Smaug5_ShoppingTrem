using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class validateMissionSales : MonoBehaviour
{
    public Button buttonSteps;
    // Start is called before the first frame update
    void Start()
    {
        buttonSteps = GetComponent<Button>();
        if (VariablesSave.countOfSalesRecord >= 100)
        {
            buttonSteps.interactable = true;
        }
        else
        {
            buttonSteps.interactable = false;
        }
    }
}
