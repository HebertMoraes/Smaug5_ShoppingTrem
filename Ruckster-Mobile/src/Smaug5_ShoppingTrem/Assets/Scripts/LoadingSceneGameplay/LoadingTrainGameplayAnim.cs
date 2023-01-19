using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingTrainGameplayAnim : MonoBehaviour
{
    public float timeInLoading;
    public GameObject loadingIconTxt;
    public GameObject backgroundImg;
    public Texture img1English;
    public Texture img2English;
    public Texture img1Portuguese;
    public Texture img2Portuguese;
    public float speedLoadingIconTxt;
    public float loadingIconTxtMaxLeft;
    public RawImage backgroundOfBackgroundImg;

    private float currentTimeInLoad;
    private float loadingIconTxtMaxRight;
    private bool loadingIconTxtIsMovingLeft;

    // Start is called before the first frame update
    void Start()
    {
        loadingIconTxtMaxRight = loadingIconTxt.transform.position.x;

        if (Random.value > 0.5)
        {
            if (VariablesSave.translate) {
                backgroundImg.GetComponent<UnityEngine.UI.RawImage>().texture = img1Portuguese;
            } else {
                backgroundImg.GetComponent<UnityEngine.UI.RawImage>().texture = img1English;
            }
            backgroundOfBackgroundImg.color = new Color(0.98f, 0.81f, 0.06f);
        }
        else
        {
            if (VariablesSave.translate) {
                backgroundImg.GetComponent<UnityEngine.UI.RawImage>().texture = img2Portuguese;
            } else {
                backgroundImg.GetComponent<UnityEngine.UI.RawImage>().texture = img2English;
            }
            backgroundOfBackgroundImg.color = new Color(0.71f, 0.06f, 0.09f);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (loadingIconTxtIsMovingLeft)
        {
            loadingIconTxt.transform.position = new Vector3(
                loadingIconTxt.transform.position.x - (speedLoadingIconTxt * Time.deltaTime),
                loadingIconTxt.transform.position.y,
                loadingIconTxt.transform.position.z
            );

            if (loadingIconTxt.transform.position.x < loadingIconTxtMaxLeft)
            {
                loadingIconTxtIsMovingLeft = false;
            }
        }
        else
        {

            loadingIconTxt.transform.position = new Vector3(
                loadingIconTxt.transform.position.x + (speedLoadingIconTxt * Time.deltaTime),
                loadingIconTxt.transform.position.y,
                loadingIconTxt.transform.position.z
            );

            if (loadingIconTxt.transform.position.x > loadingIconTxtMaxRight)
            {
                loadingIconTxtIsMovingLeft = true;
            }
        }

        if (currentTimeInLoad >= timeInLoading)
        {
            SceneManager.LoadScene("TrainGameplay");
        }
        currentTimeInLoad += Time.deltaTime;
    }
}
