using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPause : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject gameController;
    private GameState gameState;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    public void resumeGameplay()
    {
        gameState.currentState = GameState.states.Running;
        pauseMenu.SetActive(false);
    }
}
