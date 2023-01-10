using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshRecordSteps : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (VariablesSave.translate)
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "PASSOS: " + System.Math.Round(VariablesSave.stepsScoreRecord, 2).ToString();
        }
        else
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "STEPS: " + System.Math.Round(VariablesSave.stepsScoreRecord, 2).ToString();
        }
    }
}
