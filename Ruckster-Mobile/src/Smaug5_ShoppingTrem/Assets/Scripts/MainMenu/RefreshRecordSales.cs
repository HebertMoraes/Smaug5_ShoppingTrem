using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshRecordSales : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        if (VariablesSave.translate)
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "VENDAS: " + VariablesSave.countOfSalesRecord;
        }
        else
        {
            gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "SALES: " + VariablesSave.countOfSalesRecord;
        }
    }
}
