using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBuyProducts : MonoBehaviour
{

    public GameObject notMoney;
    public void BuyAddCandyX5() {
        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerCandy * 5) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerCandy * 5;
            VariablesSave.countCandy += 5;
        }
        else
        {
            notMoney.SetActive(true);
        }
    }
    public void BuyAddChocoX5() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerChoco * 5) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerChoco * 5;
            VariablesSave.countChoco += 5;
        }
        else
        {
            notMoney.SetActive(true);
        }
    }
    public void BuyAddFoneX5() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerFone * 5) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerFone * 5;
            VariablesSave.countFone += 5;
        }
        else
        {
            notMoney.SetActive(true);
        }
    }
    public void BuyAddCandyX10() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerCandy * 10) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerCandy * 10;
            VariablesSave.countCandy += 10;
        }
        else
        {
            notMoney.SetActive(true);
        }
    }
    public void BuyAddChocoX10() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerChoco * 10) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerChoco * 10;
            VariablesSave.countChoco += 10;
        }
        else
        {
            notMoney.SetActive(true);
        }
    }
    public void BuyAddFoneX10() {

        if (VariablesSave.countMoney >= GameProductsBalanceVariables.buyPricePlayerFone * 10) {
            VariablesSave.countMoney -= GameProductsBalanceVariables.buyPricePlayerFone * 10;
            VariablesSave.countFone += 10;
        }
        else
        {
            notMoney.SetActive(true);
        }
    }
}
