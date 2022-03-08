using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentProductsMerchandise;
    [Range(0,1)]
    public float chancePassengerInterestBuy;
    public float sellPrice;
}
