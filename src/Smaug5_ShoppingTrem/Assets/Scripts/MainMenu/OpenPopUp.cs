using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenPopUp : MonoBehaviour
{
    public GameObject menuPopUpToOpen;
    private GameObject gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }

    public void openPopUp()
    {
        menuPopUpToOpen.SetActive(true);
    }
}
