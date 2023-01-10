using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManipulator : MonoBehaviour
{
    public int indexBtnActivePause;
    public int indexPauseUi;
    public int indexTopHud;
    public int indexBottomHud;
    private MovimentationCharacter playerMovimentation;
    private float lastVelOfMovimentation;
    private float lastVelOfMovimentationLeftRight;
    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        playerMovimentation = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimentationCharacter>();
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }
    
    private void Update() {

        if (gameState.currentState == GameState.states.GameOver) {
            transform.GetChild(indexBtnActivePause).gameObject.SetActive(false);
        }

        else if (gameState.currentState == GameState.states.Paused) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
                ResumeGameplay();
            }
        }

        else if (gameState.currentState == GameState.states.Running) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
                ActivePause();
            }
        }
    }

    public void ActivePause () {

        gameState.currentState = GameState.states.Paused;

        lastVelOfMovimentation = playerMovimentation.velOfMovimentation;
        lastVelOfMovimentationLeftRight = playerMovimentation.velOfMovimentationLeftRight;

        playerMovimentation.velOfMovimentation = 0;
        playerMovimentation.velOfMovimentationLeftRight = 0;

        transform.GetChild(indexBtnActivePause).gameObject.SetActive(false);
        transform.GetChild(indexPauseUi).gameObject.SetActive(true);

        transform.GetChild(indexTopHud).gameObject.SetActive(false);
        transform.GetChild(indexBottomHud).gameObject.SetActive(false);
    }

    public void ResumeGameplay () {

        playerMovimentation.velOfMovimentation = lastVelOfMovimentation;
        playerMovimentation.velOfMovimentationLeftRight = lastVelOfMovimentationLeftRight;

        transform.GetChild(indexPauseUi).gameObject.SetActive(false);
        transform.GetChild(indexBtnActivePause).gameObject.SetActive(true);

        transform.GetChild(indexTopHud).gameObject.SetActive(true);
        transform.GetChild(indexBottomHud).gameObject.SetActive(true);

        gameState.currentState = GameState.states.Running;
    }

    public void ExitGameplay () {
        SceneManager.LoadScene("MainMenu");
    }
}
