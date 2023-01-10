using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchLanguage : MonoBehaviour
{
    public bool translate;
    private GameObject gameController;
    // Start is called before the first frame update
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController");
    }
    public void Language_PT()
    {
        VariablesSave.translate = true;
    }
    public void Language_EN()
    {
        VariablesSave.translate = false;
    }
}
