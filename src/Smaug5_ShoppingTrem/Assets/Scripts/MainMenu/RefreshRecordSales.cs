using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshRecordSales : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Record Sales: " + VariablesSave.countOfSalesRecord;
    }
}
