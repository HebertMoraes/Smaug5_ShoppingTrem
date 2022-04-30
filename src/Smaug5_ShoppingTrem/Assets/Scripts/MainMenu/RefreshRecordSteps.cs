using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshRecordSteps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Record Steps: " + 
            System.Math.Round(VariablesSave.stepsScoreRecord, 2).ToString();
    }
}
