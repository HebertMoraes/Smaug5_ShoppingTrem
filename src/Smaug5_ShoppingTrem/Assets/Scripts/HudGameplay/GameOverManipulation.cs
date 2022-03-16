using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManipulation : MonoBehaviour
{
    public int indexGameOverInCanvas;
    public int indexDebuggtestInCanvas;
    public int indexTopHudInCanvas;
    public int indexBottomHudInCanvas;
    public int indexScoreSteps;
    public int indexSalesMade;
    public int indexMoneyEarned;
    private MovimentationCharacter playerMovimentation;
    private Inventory playerInventory;
    private ScoreCount playerScoreCount;
    private Transform backgroundGameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerCharacter = GameObject.FindGameObjectWithTag("Player");
        playerMovimentation = playerCharacter.GetComponent<MovimentationCharacter>();
        playerInventory = playerCharacter.GetComponent<Inventory>();
        playerScoreCount = playerCharacter.GetComponent<ScoreCount>();

        backgroundGameOver = transform.GetChild(indexGameOverInCanvas).GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovimentation.velOfMovimentation <= 0) {

            transform.GetChild(indexGameOverInCanvas).gameObject.SetActive(true);

            transform.GetChild(indexDebuggtestInCanvas).gameObject.SetActive(false);
            transform.GetChild(indexTopHudInCanvas).gameObject.SetActive(false);
            transform.GetChild(indexBottomHudInCanvas).gameObject.SetActive(false);

            PutRecordsOnUI();
        }
    }

    public void PutRecordsOnUI() {

        backgroundGameOver.GetChild(indexScoreSteps).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
            System.Math.Round(playerScoreCount.currentScoreSteps, 2).ToString();

        backgroundGameOver.GetChild(indexSalesMade).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
            playerScoreCount.currentScoreSales.ToString();

        backgroundGameOver.GetChild(indexMoneyEarned).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
            "$ " + playerInventory.moneyEarned;
    }

    public void FinishGameplay() {
        SceneManager.LoadScene("MainMenu");
    }
}
