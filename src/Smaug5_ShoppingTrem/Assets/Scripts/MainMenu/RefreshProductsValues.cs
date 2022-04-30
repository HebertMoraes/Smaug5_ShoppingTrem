using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RefreshProductsValues : MonoBehaviour
{
    public GameObject quantityCandy;
    public GameObject quantityChoco;
    public GameObject quantityFone;

    public GameObject pricePlayerBuyCandy;
    public GameObject pricePlayerBuyChoco;
    public GameObject pricePlayerBuyFone;

    private TMPro.TextMeshProUGUI txtQuantityCandy;
    private TMPro.TextMeshProUGUI txtQuantityChoco;
    private TMPro.TextMeshProUGUI txtQuantityFone;

    // Start is called before the first frame update
    void Start()
    {
        txtQuantityCandy = quantityCandy.GetComponent<TMPro.TextMeshProUGUI>();
        txtQuantityChoco = quantityChoco.GetComponent<TMPro.TextMeshProUGUI>();
        txtQuantityFone = quantityFone.GetComponent<TMPro.TextMeshProUGUI>();

        pricePlayerBuyCandy.GetComponent<TMPro.TextMeshProUGUI>().text = "$ " +
            GameProductsBalanceVariables.buyPricePlayerCandy.ToString();
        
        pricePlayerBuyChoco.GetComponent<TMPro.TextMeshProUGUI>().text = "$ " +
            GameProductsBalanceVariables.buyPricePlayerChoco.ToString();
        
        pricePlayerBuyFone.GetComponent<TMPro.TextMeshProUGUI>().text = "$ " +
            GameProductsBalanceVariables.buyPricePlayerFone.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txtQuantityCandy.text = "Quantity: \n" + VariablesSave.countCandy.ToString();
        txtQuantityChoco.text = "Quantity: \n" + VariablesSave.countChoco.ToString();
        txtQuantityFone.text = "Quantity: \n" + VariablesSave.countFone.ToString();
    }
}
