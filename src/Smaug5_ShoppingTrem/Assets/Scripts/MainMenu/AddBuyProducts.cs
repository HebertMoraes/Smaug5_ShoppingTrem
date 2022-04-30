using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBuyProducts : MonoBehaviour
{
    public void BuyAddCandyX5() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerCandy * 5) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerCandy * 5;
            VariablesSave.countCandy += 5;
        }
    }
    public void BuyAddChocoX5() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerChoco * 5) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerChoco * 5;
            VariablesSave.countChoco += 5;
        }
    }
    public void BuyAddFoneX5() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerFone * 5) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerFone * 5;
            VariablesSave.countFone += 5;
        }
    }

    public void BuyAddCandyX10() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerCandy * 10) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerCandy * 10;
            VariablesSave.countCandy += 10;
        }
    }
    public void BuyAddChocoX10() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerChoco * 10) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerChoco * 10;
            VariablesSave.countChoco += 10;
        }
    }
    public void BuyAddFoneX10() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerFone * 10) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerFone * 10;
            VariablesSave.countFone += 10;
        }
    }
}
