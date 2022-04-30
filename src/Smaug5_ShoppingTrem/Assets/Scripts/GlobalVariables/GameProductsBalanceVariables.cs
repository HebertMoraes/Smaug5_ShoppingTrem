using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum allProductsToSell {
    Candy, 
    Choco, 
    Fone
}

public static class GameProductsBalanceVariables {
    public static float chancePassengerInterestBuyCandy = (float)0.5;
    public static float chancePassengerInterestBuyChoco = (float)0.7;
    public static float chancePassengerInterestBuyFone = (float)0.9;

    public static float sellPriceCandy = 2;
    public static float sellPriceChoco = 5;
    public static float sellPriceFone = 10;

    public static float buyPricePlayerCandy = 1;
    public static float buyPricePlayerChoco = 3;
    public static float buyPricePlayerFone = 5;
}

