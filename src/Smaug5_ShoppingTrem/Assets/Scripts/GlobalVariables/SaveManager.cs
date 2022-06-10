using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    private Inventory playerInventory;
    private ScoreCount playerScoreCount;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        playerScoreCount = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCount>();
        NewLoad();
    }

    public void NewSave() {

        //salvando record steps
        if (playerScoreCount.currentScoreSteps > VariablesSave.stepsScoreRecord) {

            VariablesSave.stepsScoreRecord = playerScoreCount.currentScoreSteps;
        }

        //salvando record de vendas
        if (playerInventory.totalItemSale > VariablesSave.countOfSalesRecord) {

            VariablesSave.countOfSalesRecord = playerInventory.totalItemSale;
        }

        //salvando dinheiro
        VariablesSave.countMoney += playerInventory.moneyEarned;

        //zerando o estoque do produto da partida pois o guarda roubou
        if (playerInventory.currentTypeOfProductInInventory == allProductsToSell.Candy) {
            VariablesSave.countCandy = 0;
        }
        if (playerInventory.currentTypeOfProductInInventory == allProductsToSell.Choco) {
            VariablesSave.countChoco = 0;
        }
        if (playerInventory.currentTypeOfProductInInventory == allProductsToSell.Fone) {
            VariablesSave.countFone = 0;
        }
    }

    public void NewLoad() {
              
        switch (playerInventory.currentTypeOfProductInInventory)
        {
            case allProductsToSell.Candy:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyCandy;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceCandy;
                playerInventory.currentProductsInInventory = VariablesSave.countCandy;
                break;
            case allProductsToSell.Choco:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyChoco;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceChoco;
                playerInventory.currentProductsInInventory = VariablesSave.countChoco;
                break;
            case allProductsToSell.Fone:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyFone;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceFone;
                playerInventory.currentProductsInInventory = VariablesSave.countFone;
                break;
            default:
                playerInventory.chancePassengerInterestBuy = GameProductsBalanceVariables.chancePassengerInterestBuyCandy;
                playerInventory.sellPrice = GameProductsBalanceVariables.sellPriceCandy;
                break;
        }
    }
}
