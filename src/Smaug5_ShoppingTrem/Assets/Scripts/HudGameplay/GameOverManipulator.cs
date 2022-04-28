using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManipulator : MonoBehaviour
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

    public void PutRecordsOnUI() {

        transform.GetChild(indexGameOverInCanvas).gameObject.SetActive(true);

        transform.GetChild(indexDebuggtestInCanvas).gameObject.SetActive(false);
        transform.GetChild(indexTopHudInCanvas).gameObject.SetActive(false);
        transform.GetChild(indexBottomHudInCanvas).gameObject.SetActive(false);


        backgroundGameOver.GetChild(indexScoreSteps).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
            System.Math.Round(playerScoreCount.currentScoreSteps, 2).ToString();

        backgroundGameOver.GetChild(indexSalesMade).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
            playerScoreCount.currentScoreSales.ToString();

        backgroundGameOver.GetChild(indexMoneyEarned).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = 
            "$ " + playerInventory.moneyEarned;
    }

    //esse método está sendo usado ao clicar no botão de return to Manu ao dar o gameOver
    public void FinishGameplay() {
        SceneManager.LoadScene("MainMenu");
    }
}
