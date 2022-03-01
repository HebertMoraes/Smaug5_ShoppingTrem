using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToLoadingTrainGameplay() {
        SceneManager.LoadScene("LoadingTrainGameplay");
    }

    public void ToTrainGameplay() {
        SceneManager.LoadScene("TrainGameplay");
    }
}
