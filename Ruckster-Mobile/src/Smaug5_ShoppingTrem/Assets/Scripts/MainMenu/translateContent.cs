using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class translateContent : MonoBehaviour
{
    private RawImage bgImage;

    public Texture2D bgImageOriginal;
    public Texture2D bgImageTraslated;

    // Start is called before the first frame update
    private void Start()
    {
        bgImage = GetComponent<RawImage>();
    }
    void Update()
    {
        if (VariablesSave.translate == true)
        {
            bgImage.texture = bgImageTraslated;
        } 
        else if (VariablesSave.translate == false)
        {
            bgImage.texture = bgImageOriginal;
        }
    }
}
