using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManipulatorMenus : MonoBehaviour
{
    public GameObject StartTrainGameplaybtn;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void SelectCandy()
    {
        source.Play();
        StartTrainGameplaybtn.GetComponent<CheckSelectionProduct>().alreadySelectedOne = true;
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Candy;
    }
    public void SelectChoco()
    {
        source.Play();
        StartTrainGameplaybtn.GetComponent<CheckSelectionProduct>().alreadySelectedOne = true;
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Choco;
    }
    public void SelectFone()
    {
        source.Play();
        StartTrainGameplaybtn.GetComponent<CheckSelectionProduct>().alreadySelectedOne = true;
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Fone;
    }
}
