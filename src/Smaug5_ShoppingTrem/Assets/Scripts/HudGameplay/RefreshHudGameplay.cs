using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshHudGameplay : MonoBehaviour
{
    public int indexTopHud;
    public int indexBottomHud;
    private TMPro.TextMeshProUGUI txtProductsInInventory;
    private TMPro.TextMeshProUGUI txtMoneyEarned;
    private TMPro.TextMeshProUGUI txtCurrentSteps;
    private Inventory playerInventory;
    private ScoreCount scorePlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        scorePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreCount>();

        txtProductsInInventory = transform.GetChild(indexTopHud).GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
        txtMoneyEarned = transform.GetChild(indexTopHud).GetChild(0).GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
        
        txtCurrentSteps = transform.GetChild(indexBottomHud).GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        txtProductsInInventory.text = playerInventory.currentProductsInInventory.ToString();
        txtMoneyEarned.text = "$ " + playerInventory.moneyEarned;

        txtCurrentSteps.text = System.Math.Round(scorePlayer.currentScoreSteps, 2).ToString();
    }
}
