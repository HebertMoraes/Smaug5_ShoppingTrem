using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTypeProduct : MonoBehaviour
{
    public GameObject boxCandy;
    public GameObject boxChoco;
    public GameObject boxPhone;

    public GameState gameState;

    private GameObject currentProductGameObj;

    // Start is called before the first frame update
    void Start()
    {
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Candy) {
            currentProductGameObj = Instantiate(boxCandy);
        }
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Choco) {
            currentProductGameObj = Instantiate(boxChoco);
        }
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Fone) {
            currentProductGameObj = Instantiate(boxPhone);
        }
    }

    private void Update() {
        if (gameState.currentState == GameState.states.GameOver) {
            Destroy(currentProductGameObj);
        } else if (gameState.currentState == GameState.states.Paused) {
            currentProductGameObj.SetActive(false);
        } else {
            currentProductGameObj.SetActive(true);
        }
    }
}
