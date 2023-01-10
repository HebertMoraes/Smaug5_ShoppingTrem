using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsStation : MonoBehaviour
{
    public float alphaMinHitClick = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = alphaMinHitClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
