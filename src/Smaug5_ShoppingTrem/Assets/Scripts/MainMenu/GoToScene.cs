using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToScene : MonoBehaviour
{
    private bool waitToGoTrainGameplay;
    public float timeWaitToGotrainGameplay;
    private float currentTimeWait;

    private void Start()
    {
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Candy;
    }

    private void Update()
    {

        if (waitToGoTrainGameplay)
        {
            //aqui poderia colocar um fade na tela

            if (currentTimeWait > timeWaitToGotrainGameplay)
            {
                SceneManager.LoadScene("loadingTrainGameplay");
            }
            currentTimeWait += Time.deltaTime;
        }
    }

    public void GoToLoadingTrainGameplay()
    {
        GameObject.Find("TrainCar1").GetComponent<AudioSource>().Play();
        waitToGoTrainGameplay = true;
    }
}
