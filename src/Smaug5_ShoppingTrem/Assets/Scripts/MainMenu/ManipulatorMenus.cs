using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManipulatorMenus : MonoBehaviour
{    
    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.countMoney = 1;
        GlobalVariables.countCash = 2;
        GlobalVariables.countCandy = 3;
        GlobalVariables.countChoco = 4;
        GlobalVariables.countFone = 5;
        /* GlobalVariables.countItemSold = 1;
         GlobalVariables.countSoldAmount = 1;
         GlobalVariables.countStepsDistance = 1;*/
        RefreshHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneToLoadGameplay() {
        SceneManager.LoadScene("LoadingTrainGameplay");
    }

    public void RefreshHUD()
    {
        RefreshMoney();
        RefreshCash();
        RefreshCandy();
        RefreshChoco();
        RefreshFone();
    }

    public void RefreshMoney()
    {
        TextMeshProUGUI ctMoney = transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctMoney.text = "R$" + GlobalVariables.countMoney.ToString();
    }

    public void RefreshCash()
    {
        TextMeshProUGUI ctCash = transform.GetChild(0).GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctCash.text = "x" + GlobalVariables.countCash.ToString();
    }
    public void RefreshCandy()
    {
        TextMeshProUGUI ctCandy = transform.GetChild(0).GetChild(3).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctCandy.text = "x" + GlobalVariables.countCandy.ToString();
    }
    public void RefreshChoco()
    {
        TextMeshProUGUI ctChoco = transform.GetChild(0).GetChild(4).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctChoco.text = "x" + GlobalVariables.countChoco.ToString();
    }
    public void RefreshFone()
    {
        TextMeshProUGUI ctFone = transform.GetChild(0).GetChild(5).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctFone.text = "x" + GlobalVariables.countFone.ToString();
    }


    /*public void RefreshItemSold()
    {
        TextMeshProUGUI ctItemSold = transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void RefreshSoldAmount()
    {
        TextMeshProUGUI ctSoldAmount = transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void RefreshStepsDistance()
    {
        TextMeshProUGUI ctStepsDistance = transform.GetChild(0).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
    }*/

}
