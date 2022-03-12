using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManipulatorMenus : MonoBehaviour
{
    public static SaveManager instance;
    // Start is called before the first frame update
    void Start()
    {
        OnGameEnter();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshHUD();
    }

    public void SceneToLoadGameplay()
    {
        SceneManager.LoadScene("LoadingTrainGameplay");
    }

    public void OnGameEnter()
    {
        GameObject shop = gameObject.transform.Find("ShopLayout").gameObject;
        shop.SetActive(false);

        GameObject mission = gameObject.transform.Find("MissionsLayout").gameObject;
        mission.SetActive(false);

        GameObject candy = gameObject.transform.Find("CandyLayout").gameObject;
        candy.SetActive(false);

        GameObject choco = gameObject.transform.Find("ChocoLayout").gameObject;
        choco.SetActive(false);

        GameObject fone = gameObject.transform.Find("FoneLayout").gameObject;
        fone.SetActive(false);
    }

    #region RefreshHud
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
        ctMoney.text = "R$" + SaveManager.instance.activeSave.countMoney.ToString();
    }

    public void RefreshCash()
    {
        TextMeshProUGUI ctCash = transform.GetChild(0).GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctCash.text = "x" + SaveManager.instance.activeSave.countCash.ToString();
    }
    public void RefreshCandy()
    {
        TextMeshProUGUI ctCandy = transform.GetChild(0).GetChild(3).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctCandy.text = "x" + SaveManager.instance.activeSave.countCandy.ToString();
    }
    public void RefreshChoco()
    {
        TextMeshProUGUI ctChoco = transform.GetChild(0).GetChild(4).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctChoco.text = "x" + SaveManager.instance.activeSave.countChoco.ToString();
    }
    public void RefreshFone()
    {
        TextMeshProUGUI ctFone = transform.GetChild(0).GetChild(5).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctFone.text = "x" + SaveManager.instance.activeSave.countFone.ToString();
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
    #endregion

    #region OpenPopUP
    public void OpenShop()
    {
        GameObject shop = gameObject.transform.Find("ShopLayout").gameObject;
        shop.SetActive(true);
    }

    public void OpenMission()
    {
        GameObject mission = gameObject.transform.Find("MissionsLayout").gameObject;
        mission.SetActive(true);
    }

    public void OpenCandy()
    {
        GameObject candy = gameObject.transform.Find("CandyLayout").gameObject;
        candy.SetActive(true);
    }

    public void OpenChoco()
    {
        GameObject choco = gameObject.transform.Find("ChocoLayout").gameObject;
        choco.SetActive(true);
    }

    public void OpenFone()
    {
        GameObject fone = gameObject.transform.Find("FoneLayout").gameObject;
        fone.SetActive(true);
    }
    #endregion


}
