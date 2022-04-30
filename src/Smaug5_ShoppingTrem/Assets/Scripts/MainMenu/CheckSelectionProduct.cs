using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckSelectionProduct : MonoBehaviour
{
    public bool alreadySelectedOne;
    private Button buttonStart;

    private void Start() {
        buttonStart = gameObject.GetComponent<Button>();
    }

    private void Update() {

        if (alreadySelectedOne) {
            buttonStart.enabled = true;
        } else {
            buttonStart.enabled = false;
        }
    }
    public void GoToLoadingTrainGameplay() {

        if (alreadySelectedOne) {
            SceneManager.LoadScene("LoadingTrainGameplay");
        }
    }
}
