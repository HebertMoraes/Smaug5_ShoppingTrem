using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManipulatorMenus : MonoBehaviour
{
    //public static SaveManager instance;
    // Start is called before the first frame update
    void Start()
    {
        //OnGameEnter();
        RefreshHUD();
    }

    // Update is called once per frame
    void Update()
    {
        //comentado abaixo por hebert porque tava dando bug
        //RefreshHUD();
    }

    public void SceneToLoadGameplay()
    {
        SceneManager.LoadScene("LoadingTrainGameplay");
    }

    // public void OnGameEnter()
    // {
    //     GameObject shop = gameObject.transform.Find("ShopLayout").gameObject;
    //     shop.SetActive(false);

    //     GameObject mission = gameObject.transform.Find("MissionsLayout").gameObject;
    //     mission.SetActive(false);

    //     GameObject candy = gameObject.transform.Find("CandyLayout").gameObject;
    //     candy.SetActive(false);

    //     GameObject choco = gameObject.transform.Find("ChocoLayout").gameObject;
    //     choco.SetActive(false);

    //     GameObject fone = gameObject.transform.Find("FoneLayout").gameObject;
    //     fone.SetActive(false);

    //     GameObject options = gameObject.transform.Find("OptionLayout").gameObject;
    //     options.SetActive(false);
    // }

    //#region RefreshHud
    public void RefreshHUD()
    {
        /*
        RefreshMoney();
        RefreshCash();
        RefreshCandy();
        RefreshChoco();
        RefreshFone();
        RefreshMissionMeters();
        RefreshMissionSoldItem();
        RefreshMissionSalesAmount();
        */
    }
    /*
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
    public void RefreshMissionMeters()
    {
        TextMeshProUGUI ctMeters = transform.GetChild(4).GetChild(4).GetChild(0).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctMeters.text = SaveManager.instance.activeSave.countStepsDistance.ToString() + "/1000";
    }
    public void RefreshMissionSoldItem()
    {
        TextMeshProUGUI ctSoldItem = transform.GetChild(4).GetChild(4).GetChild(1).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctSoldItem.text = SaveManager.instance.activeSave.countItemSold.ToString() + "/100";
    }
    public void RefreshMissionSalesAmount()
    {
        TextMeshProUGUI ctSalesAmount = transform.GetChild(4).GetChild(4).GetChild(2).GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ctSalesAmount.text = SaveManager.instance.activeSave.countSalesAmount.ToString() + "/1000";
    }
    */
    //#endregion
    
    
    // #region OpenPopUP
    // public void OpenShop()
    // {
    //     GameObject shop = gameObject.transform.Find("ShopLayout").gameObject;
    //     shop.SetActive(true);
    // }

    // public void OpenMission()
    // {
    //     GameObject mission = gameObject.transform.Find("MissionsLayout").gameObject;
    //     mission.SetActive(true);
    // }

    // public void OpenCandy()
    // {
    //     GameObject candy = gameObject.transform.Find("CandyLayout").gameObject;
    //     candy.SetActive(true);
    // }

    // public void OpenChoco()
    // {
    //     GameObject choco = gameObject.transform.Find("ChocoLayout").gameObject;
    //     choco.SetActive(true);
    // }

    // public void OpenFone()
    // {
    //     GameObject fone = gameObject.transform.Find("FoneLayout").gameObject;
    //     fone.SetActive(true);
    // }

    // public void OpenOptions()
    // {
    //     GameObject option = gameObject.transform.Find("OptionLayout").gameObject;
    //     option.SetActive(true);
    // }
    // #endregion

    // #region Rewards
    

    
    // #endregion

}
