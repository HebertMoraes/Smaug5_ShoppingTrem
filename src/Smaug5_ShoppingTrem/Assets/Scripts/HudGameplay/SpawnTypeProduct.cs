using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTypeProduct : MonoBehaviour
{
    public GameObject boxCandy;
    public GameObject boxChoco;
    public GameObject boxPhone;

    // Start is called before the first frame update
    void Start()
    {
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Candy) {
            Instantiate(boxCandy);
        }
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Choco) {
            Instantiate(boxChoco);
        }
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Fone) {
            Instantiate(boxPhone);
        }
    }
}
