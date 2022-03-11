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

    public void MakeBusinessWithPassenger() {
        currentProductsMerchandise -= 1;
        moneyEarned += sellPrice;
        GetComponent<ScoreCount>().currentScoreSales += 1;
    }
}
