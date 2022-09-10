using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckSelectionProduct : MonoBehaviour
{
    public GameObject menuSelectionStation;
    private GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    public void GoToLoadingTrainGameplay()
    {
        menuSelectionStation.SetActive(true);
    }
}
