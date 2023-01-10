using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ManipulatorMenus : MonoBehaviour
{
    public GameObject gameController;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        gameController = GameObject.FindWithTag("GameController");
    }

    public void SelectCandy()
    {
        source.Play();
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Candy;
    }
    public void SelectChoco()
    {
        source.Play();
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Choco;
    }
    public void SelectFone()
    {
        source.Play();
        VariablesSave.currentProductSelectedToSell = allProductsToSell.Fone;
    }
}
