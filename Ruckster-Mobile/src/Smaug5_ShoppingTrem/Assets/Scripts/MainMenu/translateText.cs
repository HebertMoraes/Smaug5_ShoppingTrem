using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class translateText : MonoBehaviour
{
    public string textOriginal;
    public string textTranslated;
    private TMPro.TextMeshProUGUI textBox;
    // Start is called before the first frame update
    private void Start()
    {
        textBox = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {
        if (VariablesSave.translate == true)
        {
            textBox.text = textTranslated;
        }
        else if(VariablesSave.translate == false)
        {
            textBox.text = textOriginal;
        }
    }
}
