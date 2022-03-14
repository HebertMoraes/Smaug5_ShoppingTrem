using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentProductsMerchandise;//quantos produtos o player tem para vender, quantos tem no inventario
    [Range(0,1)]
    public float chancePassengerInterestBuy;//setada no começo de cada partida de acordo com o produto escolhido para venda
    public float sellPrice; //setada no começo de cada partida de acordo com o produto escolhido para venda
    [HideInInspector]
    public float moneyEarned;//dinheiro de vendas feitas em cada partida
    private float valueToMultiplyBonusMoney = 1;
    private float timeTotalInBonus;
    private float currentTimeInBonusMoneySales;

    public void MakeBusinessWithPassenger() {

        currentProductsMerchandise -= 1;

        moneyEarned += (float)System.Math.Round((sellPrice * valueToMultiplyBonusMoney), 0);
        
        GetComponent<ScoreCount>().currentScoreSales += 1;
    }

    private void Update() {
        if (valueToMultiplyBonusMoney != 1) {
            currentTimeInBonusMoneySales += Time.deltaTime;

            if (currentTimeInBonusMoneySales >= timeTotalInBonus) {
                currentTimeInBonusMoneySales = 0;
                valueToMultiplyBonusMoney = 1;
            }
        }
    }

    public void BonusMoneyOfSales(float valueToBonus, float timeInBonus) {
        valueToMultiplyBonusMoney = valueToBonus;
        timeTotalInBonus = timeInBonus;
        currentTimeInBonusMoneySales = 0;
    }
}
