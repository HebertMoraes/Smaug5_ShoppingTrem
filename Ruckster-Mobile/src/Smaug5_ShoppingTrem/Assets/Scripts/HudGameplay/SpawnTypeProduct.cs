using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTypeProduct : MonoBehaviour
{
    public GameObject boxCandy;
    public GameObject boxChoco;
    public GameObject boxPhone;
    public GameObject hudCandy;
    public GameObject hudChoco;
    public GameObject hudPhone;

    public GameState gameState;

    private GameObject currentProductGameObj;

    // Start is called before the first frame update
    void Start()
    {
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Candy) {
            currentProductGameObj = Instantiate(boxCandy);
            hudCandy.SetActive(true);
        }
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Choco) {
            currentProductGameObj = Instantiate(boxChoco);
            hudChoco.SetActive(true);
        }
        if (VariablesSave.currentProductSelectedToSell == allProductsToSell.Fone) {
            currentProductGameObj = Instantiate(boxPhone);
            hudPhone.SetActive(true);
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
