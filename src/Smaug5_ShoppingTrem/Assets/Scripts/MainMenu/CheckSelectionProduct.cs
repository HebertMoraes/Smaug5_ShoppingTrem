using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckSelectionProduct : MonoBehaviour
{
    [HideInInspector]
    public bool alreadySelectedOne;
    private Button buttonStart;
    private bool waitToGoTrainGameplay;
    public float timeWaitToGotrainGameplay;
    private float currentTimeWait;

    private void Start() {
        buttonStart = gameObject.GetComponent<Button>();
    }

    private void Update() {

        if (alreadySelectedOne) {
            buttonStart.enabled = true;

            if (waitToGoTrainGameplay) {

                //aqui poderia colocar um fade na tela

                if (currentTimeWait > timeWaitToGotrainGameplay) {
                    SceneManager.LoadScene("LoadingTrainGameplay");
                }
            }
            currentTimeWait += Time.deltaTime;

        } else {
            buttonStart.enabled = false;
        }
    }

    public void GoToLoadingTrainGameplay() {

        if (alreadySelectedOne) {
            GameObject.Find("TrainCar1").GetComponent<AudioSource>().Play();
            waitToGoTrainGameplay = true;
        }
    }
}
