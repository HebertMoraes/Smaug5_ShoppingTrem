using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCash : MonoBehaviour
{
    public GameObject menuProducts;
    private GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    public void GoToMainMenu()
    {
        menuProducts.SetActive(false);
    }
}
