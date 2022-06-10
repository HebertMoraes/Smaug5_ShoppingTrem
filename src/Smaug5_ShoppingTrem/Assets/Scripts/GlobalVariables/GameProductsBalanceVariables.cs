using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum allProductsToSell {
    Candy, 
    Choco, 
    Fone
}

public static class GameProductsBalanceVariables {
    public static float chancePassengerInterestBuyCandy = 0.1f;
    public static float chancePassengerInterestBuyChoco = 0.2f;
    public static float chancePassengerInterestBuyFone = 0.25f;

    public static float sellPriceCandy = 1.2f;
    public static float sellPriceChoco = 3.6f;
    public static float sellPriceFone = 6f;

    public static float buyPricePlayerCandy = 1;
    public static float buyPricePlayerChoco = 3;
    public static float buyPricePlayerFone = 5;
}

