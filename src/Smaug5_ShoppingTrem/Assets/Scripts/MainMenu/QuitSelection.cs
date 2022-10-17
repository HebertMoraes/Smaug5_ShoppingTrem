using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitSelection : MonoBehaviour
{
    public GameObject menuSelectionStation;
    private GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    public void GoToMainMenu()
    {
        menuSelectionStation.SetActive(false);
    }
}
