using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAlpha : MonoBehaviour
{
    public Image[] buttons;
    public int numberButtons;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i< numberButtons; i++)
        {
            buttons[i].alphaHitTestMinimumThreshold = 1f;
        }
    }
}
