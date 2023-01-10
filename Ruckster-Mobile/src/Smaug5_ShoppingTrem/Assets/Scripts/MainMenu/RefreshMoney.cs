using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshMoney : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = VariablesSave.countMoney.ToString();
    }
}
