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
        //estou setando para true abaixo porque agora o Candy sempre estará setado no inicio, 
        //se não setar true aqui no start, a verificação de ter que selecionar algum produto antes 
        //passa a valer. Também setado o currentProductSelectedToSell para o Candy.
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Candy;
        alreadySelectedOne = true;
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
