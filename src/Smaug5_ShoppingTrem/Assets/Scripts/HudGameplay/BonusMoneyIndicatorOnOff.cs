using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMoneyIndicatorOnOff : MonoBehaviour
{
    private Inventory playerCharacterInventory;
    private TMPro.TextMeshProUGUI txtBonusOnOff;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacterInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        txtBonusOnOff = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCharacterInventory.valueToMultiplyBonusMoney != 1){
            txtBonusOnOff.alpha = 255;
        } else {
            txtBonusOnOff.alpha = 0;
        }
    }
}
