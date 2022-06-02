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

    public GameObject chanceInterestBuyCandy;
    public GameObject chanceInterestBuyChoco;
    public GameObject chanceInterestBuyFone;

    public GameObject salesPriceCandy;
    public GameObject salesPriceChoco;
    public GameObject salesPriceFone;

    private TMPro.TextMeshProUGUI txtQuantityCandy;
    private TMPro.TextMeshProUGUI txtQuantityChoco;
    private TMPro.TextMeshProUGUI txtQuantityFone;

    // Start is called before the first frame update
    void Start()
    {
        txtQuantityCandy = quantityCandy.GetComponent<TMPro.TextMeshProUGUI>();
        txtQuantityChoco = quantityChoco.GetComponent<TMPro.TextMeshProUGUI>();
        txtQuantityFone = quantityFone.GetComponent<TMPro.TextMeshProUGUI>();

        //preço pro jogador comprar o produto
        pricePlayerBuyCandy.GetComponent<TMPro.TextMeshProUGUI>().text = "$" +
            GameProductsBalanceVariables.buyPricePlayerCandy.ToString();

        pricePlayerBuyChoco.GetComponent<TMPro.TextMeshProUGUI>().text = "$" +
            GameProductsBalanceVariables.buyPricePlayerChoco.ToString();

        pricePlayerBuyFone.GetComponent<TMPro.TextMeshProUGUI>().text = "$" +
            GameProductsBalanceVariables.buyPricePlayerFone.ToString();

        //chance de comprar
        //FALTA CONVERTER DE 0-1 COMO É A VARIAVEL PARA PORCENTAGEM
        chanceInterestBuyCandy.GetComponent<TMPro.TextMeshProUGUI>().text = "Interest: " +
            GameProductsBalanceVariables.chancePassengerInterestBuyCandy.ToString() + "%";

        chanceInterestBuyChoco.GetComponent<TMPro.TextMeshProUGUI>().text = "Interest: " +
            GameProductsBalanceVariables.chancePassengerInterestBuyChoco.ToString() + "%";

        chanceInterestBuyFone.GetComponent<TMPro.TextMeshProUGUI>().text = "Interest: " +
            GameProductsBalanceVariables.chancePassengerInterestBuyFone.ToString() + "%";

        //preço de venda
        salesPriceCandy.GetComponent<TMPro.TextMeshProUGUI>().text = "Sell for: $" +
            GameProductsBalanceVariables.sellPriceCandy.ToString();

        salesPriceChoco.GetComponent<TMPro.TextMeshProUGUI>().text = "Sell for: $" +
            GameProductsBalanceVariables.sellPriceChoco.ToString();
        
        salesPriceFone.GetComponent<TMPro.TextMeshProUGUI>().text = "Sell for: $" +
            GameProductsBalanceVariables.sellPriceFone.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        txtQuantityCandy.text = "Candy: " + VariablesSave.countCandy.ToString();
        txtQuantityChoco.text = "Choco: " + VariablesSave.countChoco.ToString();
        txtQuantityFone.text = "Fone: " + VariablesSave.countFone.ToString();
    }
}
